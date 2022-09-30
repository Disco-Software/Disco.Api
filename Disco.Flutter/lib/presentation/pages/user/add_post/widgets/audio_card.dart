import 'dart:async';
import 'dart:io';

import 'package:disco_app/presentation/providers/add_post_provider.dart';
import 'package:disco_app/res/colors.dart';
import 'package:disco_app/res/strings.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:just_audio/just_audio.dart';
import 'package:provider/provider.dart';

import '../select_files_page.dart';

class AudioCard extends StatefulWidget {
  const AudioCard({
    Key? key,
    required this.title,
    required this.singer,
    required this.onTap,
    required this.onThreeDotsTap,
    required this.songImage,
    required this.editMode,
    required this.onPlay,
    required this.onSaved,
  }) : super(key: key);

  final String title;
  final String songImage;
  final String singer;
  final bool editMode;
  final VoidCallback onTap;
  final VoidCallback onThreeDotsTap;
  final Function(String, String) onSaved;
  final Function(AudioPlayer) onPlay;

  @override
  State<AudioCard> createState() => _AudioCardState();
}

class _AudioCardState extends State<AudioCard> {
  final Widget _switchedPause = Padding(
    key: const ValueKey(1),
    padding: const EdgeInsets.all(4.0),
    child: Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Image.asset('assets/ic_rectangle.png'),
        Image.asset('assets/ic_rectangle.png'),
      ],
    ),
  );
  Timer? _debounce;

  final Widget _switchedPlay = Padding(
    padding: const EdgeInsets.all(4.0),
    child: Image.asset(
      'assets/ic_play.png',
      color: const Color(0xffDE9237),
    ),
  );
  final AudioPlayer _currentAudio = AudioPlayer();
  final _nameController = TextEditingController();
  final _singerController = TextEditingController();

  @override
  void initState() {
    super.initState();
  }

  @override
  void dispose() {
    _debounce?.cancel();
    _currentAudio.dispose();
    _nameController.dispose();
    _singerController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Stack(
      children: [
        Container(
          color: DcColors.dark,
          height: 160.0,
          padding: const EdgeInsets.all(12.0),
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: [
              InkWell(
                child: Consumer<AddPostProvider>(
                  builder: (ctx, data, child) {
                    return Stack(
                      alignment: Alignment.center,
                      children: [
                        Image.file(
                          File(widget.songImage),
                          height: 105,
                          width: 110,
                          errorBuilder: (ctx, obj, trace) => Image.asset(
                            widget.songImage,
                            height: 105,
                            width: 110,
                            fit: BoxFit.cover,
                          ),
                          fit: BoxFit.cover,
                        ),
                        if (widget.songImage == Strings.defaultSongImage) child!,
                      ],
                    );
                  },
                  child: SvgPicture.asset('assets/ic_picture_front.svg'),
                ),
                onTap: () => widget.onTap(),
              ),
              Stack(
                children: [
                  Container(
                    height: 55.0,
                    width: 55.0,
                    decoration: const BoxDecoration(
                      shape: BoxShape.circle,
                      gradient: LinearGradient(colors: [
                        Color(0xffDE9237),
                        Color(0xFFF6EA7D),
                      ]),
                    ),
                    child: InkWell(
                      onTap: () => widget.onPlay(_currentAudio),
                      child: Center(
                        child: Container(
                          height: 50.0,
                          width: 50.0,
                          decoration: const BoxDecoration(
                            shape: BoxShape.circle,
                            color: DcColors.bottomBarLeft,
                          ),
                          child: AnimatedSwitcher(
                            duration: const Duration(milliseconds: 300),
                            transitionBuilder: (child, animation) => FadeTransition(
                              opacity: animation,
                              child: child,
                            ),
                            child: _currentAudio.playing ? _switchedPause : _switchedPlay,
                          ),
                        ),
                      ),
                    ),
                  ),
                ],
              ),
              if (widget.editMode)
                SizedBox(
                  width: 100.0,
                  child: Padding(
                    padding: const EdgeInsets.symmetric(vertical: 10.0),
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        TextFormField(
                          controller: _nameController,
                          textInputAction: TextInputAction.next,
                          style: const TextStyle(color: DcColors.darkWhite),
                          onChanged: (value) {
                            if (_debounce?.isActive ?? false) _debounce?.cancel();
                            _debounce = Timer(const Duration(milliseconds: 500), () {
                              context.read<AddPostProvider>().currentCreatedPost.description =
                                  value;
                            });
                          },
                          decoration: InputDecoration(
                            hintText: 'Name',
                            border: UnderlineInputBorder(
                                borderRadius: BorderRadius.circular(10.0),
                                borderSide: const BorderSide(color: DcColors.darkWhite)),
                          ),
                        ),
                        TextFormField(
                          controller: _singerController,
                          textInputAction: TextInputAction.done,
                          onEditingComplete: () =>
                              widget.onSaved(_nameController.text, _singerController.text),
                          style: const TextStyle(color: DcColors.darkWhite),
                          onChanged: (value) {
                            if (_debounce?.isActive ?? false) _debounce?.cancel();
                            _debounce = Timer(const Duration(milliseconds: 500), () {
                              context.read<AddPostProvider>().currentCreatedPost.description =
                                  value;
                            });
                          },
                          decoration: InputDecoration(
                            hintText: 'Performer',
                            border: UnderlineInputBorder(
                                borderRadius: BorderRadius.circular(10.0),
                                borderSide: const BorderSide(color: DcColors.darkWhite)),
                          ),
                        ),
                      ],
                    ),
                  ),
                )
              else
                ConstrainedBox(
                  constraints: const BoxConstraints(maxWidth: 110),
                  child: Column(
                    mainAxisSize: MainAxisSize.min,
                    children: [
                      Text(
                        widget.title,
                        style: GoogleFonts.aBeeZee(fontSize: 26.0, color: Colors.white),
                        overflow: TextOverflow.ellipsis,
                      ),
                      Text(
                        widget.singer,
                        style: GoogleFonts.textMeOne(fontSize: 24.0, color: Colors.white),
                        overflow: TextOverflow.ellipsis,
                      ),
                    ],
                  ),
                ),
            ],
          ),
        ),
        Align(
          alignment: Alignment.topRight,
          child: ThreeDots(onTap: widget.onThreeDotsTap),
        )
      ],
    );
  }
}
