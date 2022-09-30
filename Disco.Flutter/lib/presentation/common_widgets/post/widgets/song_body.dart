import 'dart:async';

import 'package:cached_network_image/cached_network_image.dart';
import 'package:carousel_slider/carousel_slider.dart';
import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/data/network/network_models/song_network.dart';
import 'package:disco_app/presentation/providers/post_provider.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:just_audio/just_audio.dart';
import 'package:provider/provider.dart';
import 'package:provider/src/provider.dart';

class SongBody extends StatefulWidget {
  const SongBody({
    Key? key,
    required this.postSong,
    required this.userName,
    required this.songSources,
    required this.songTitles,
    required this.carouselController,
    required this.post,
    required this.currentPageIndex,
  }) : super(key: key);
  final String userName;
  final PostSong postSong;
  final List<String> songSources;
  final List<String> songTitles;
  final CarouselController carouselController;
  final Post post;
  final int currentPageIndex;

  @override
  State<SongBody> createState() => _SongBodyState();
}

class _SongBodyState extends State<SongBody> {
  late StreamSubscription subscription;

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

  final Widget _switchedPlay = Padding(
    padding: const EdgeInsets.all(4.0),
    child: Image.asset(
      'assets/ic_play.png',
      color: const Color(0xffDE9237),
    ),
  );

  @override
  void initState() {
    super.initState();

    subscription =
        context.read<PostProvider>().player.playerStateStream.listen((PlayerState state) async {
      final provider = Provider.of<PostProvider>(context, listen: false);
      if (state.processingState == ProcessingState.completed) {
        await provider.player.stop();
        setState(() {});
      }
    });
  }

  @override
  void dispose() {
    super.dispose();
    subscription.cancel();
  }

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.start,
      children: [
        if (widget.postSong.imageUrl != null && widget.postSong.imageUrl!.isNotEmpty)
          CachedNetworkImage(
            imageBuilder: (context, imageProvider) => Container(
              height: 105,
              width: 110,
              decoration: BoxDecoration(
                image: DecorationImage(image: imageProvider, fit: BoxFit.fill),
                borderRadius: BorderRadius.circular(12),
                boxShadow: const [
                  BoxShadow(color: Color(0xFFB2A044FF), offset: Offset(0, 4), blurRadius: 7),
                ],
              ),
            ),
            fit: BoxFit.cover,
            imageUrl: widget.postSong.imageUrl ?? '',
            errorWidget: (context, url, error) => const SizedBox(),
          )
        else
          Container(
            color: Colors.green,
            height: 105,
            width: 110,
          ),
        //const Spacer(),
        const SizedBox(
          width: 14,
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
              child: Material(
                color: Colors.transparent,
                borderRadius: BorderRadius.circular(360),
                child: InkWell(
                  onTap: () {
                    final provider = Provider.of<PostProvider>(context, listen: false);

                    final oldPost = provider.oldPost;
                    if (widget.postSong.id != oldPost.id) {
                      provider.setSongIndex(0);
                    }
                    provider.setUrl(widget.postSong.source ?? '');
                    provider.setPostSong(widget.postSong);
                    provider.setSinger(widget.userName);
                    provider.setAudioSources(widget.songSources);
                    provider.setAudioTitles(widget.songTitles);
                    provider.setSongIndex(widget.currentPageIndex);
                    provider.setCarouselController(widget.carouselController);
                    if (provider.player.playing) {
                      provider.player.pause();
                    } else {
                      provider.player.play();
                    }
                  },
                  borderRadius: BorderRadius.circular(360),
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
                        child: Consumer<PostProvider>(
                          builder: (BuildContext context, value, Widget? child) {
                            if (value.songSources[value.currentSongIndex] ==
                                    widget.postSong.source &&
                                value.player.playing) {
                              return _switchedPause;
                            } else {
                              return _switchedPlay;
                            }
                          },
                        ),
                      ),
                    ),
                  ),
                ),
              ),
            ),
          ],
        ),
        const Spacer(),
        ConstrainedBox(
          constraints: BoxConstraints(maxWidth: MediaQuery.of(context).size.width * 0.3),
          child: Padding(
            padding: const EdgeInsets.only(bottom: 10.0, left: 13),
            child: Consumer<PostProvider>(
              builder: (context, data, child) => Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                mainAxisSize: MainAxisSize.min,
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: [
                  Text(
                    widget.postSong.name ?? "",
                    maxLines: 1,
                    style: GoogleFonts.aBeeZee(
                      color: DcColors.darkWhite,
                      fontWeight: FontWeight.w400,
                      fontSize: 24,
                    ),
                    overflow: TextOverflow.ellipsis,
                  ),
                  Text(
                    widget.userName,
                    maxLines: 1,
                    textAlign: TextAlign.start,
                    overflow: TextOverflow.ellipsis,
                    style: GoogleFonts.textMeOne(
                      color: DcColors.white,
                      fontWeight: FontWeight.w400,
                      fontSize: 24,
                    ),
                  ),
                ],
              ),
            ),
          ),
        ),
        const Spacer(flex: 3),
      ],
    );
  }
}
