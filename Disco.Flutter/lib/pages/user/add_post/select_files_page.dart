import 'package:disco_app/pages/user/add_post/widgets/add_post_appbar.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:google_fonts/google_fonts.dart';

class SelectFilesPage extends StatefulWidget {
  const SelectFilesPage({
    Key? key,
  }) : super(key: key);

  @override
  State<SelectFilesPage> createState() => _SelectFilesPageState();
}

class _SelectFilesPageState extends State<SelectFilesPage> {
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
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xff1C142E),
      appBar: addPostAppBar(context, () {}),
      body: Container(
        decoration: const BoxDecoration(
          gradient: RadialGradient(
            colors: [Color(0xFF2D2053), Color(0xFF211637)],
          ),
        ),
        child: GestureDetector(
          onTap: () {
            FocusScope.of(context).unfocus();
          },
          child: ListView(
            children: [
              const SizedBox(height: 30.0),
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 48.0),
                child: TextFormField(
                  maxLines: 2,
                  style: const TextStyle(color: DcColors.darkWhite),
                  decoration: InputDecoration(
                    hintText: 'description...',
                    border: OutlineInputBorder(
                        borderRadius: BorderRadius.circular(10.0),
                        borderSide: const BorderSide(color: DcColors.darkWhite)),
                  ),
                ),
              ),
              const SizedBox(height: 40.0),
              Container(
                margin: const EdgeInsets.symmetric(horizontal: 35.0),
                color: DcColors.dark,
                height: 160.0,
                padding: const EdgeInsets.all(12.0),
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                  children: [
                    SvgPicture.asset(
                      'assets/default_audio_image.svg',
                      height: 105,
                      width: 110,
                      fit: BoxFit.cover,
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
                                // final provider = Provider.of<PostProvider>(context, listen: false);
                                //
                                // final oldPost = provider.oldPost;
                                // if (widget.postSong.id != oldPost.id) {
                                //   provider.setSongIndex(0);
                                // }
                                // provider.setUrl(widget.postSong.source ?? '');
                                // provider.setPostSong(widget.postSong);
                                // provider.setSinger(widget.userName);
                                // provider.setAudioSources(widget.songSources);
                                // provider.setAudioTitles(widget.songTitles);
                                // provider.setSongIndex(widget.currentPageIndex);
                                // provider.setCarouselController(widget.carouselController);
                                // if (provider.player.playing) {
                                //   print('lolPAUSE');
                                //   provider.player.pause();
                                // } else {
                                //   print('lolPLAY');
                                //
                                //   provider.player.play();
                                // }
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
                                    child: _switchedPause,
                                  ),
                                ),
                              ),
                            ),
                          ),
                        ),
                      ],
                    ),
                    Column(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        Text(
                          'Game',
                          style: GoogleFonts.aBeeZee(fontSize: 26.0, color: Colors.white),
                        ),
                        Text(
                          'Magic',
                          style: GoogleFonts.textMeOne(fontSize: 24.0, color: Colors.white),
                        )
                      ],
                    ),
                  ],
                ),
              ),
              const SizedBox(height: 12.0),
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 180.0),
                child: Row(
                  children: [
                    Container(
                      width: 12.0,
                      height: 12.0,
                      decoration: const BoxDecoration(
                          shape: BoxShape.circle,
                          gradient: LinearGradient(colors: [
                            Color(0xFFE08D11),
                            Color(0xFFF6EA7D),
                          ])),
                    )
                  ],
                ),
              ),
              const Spacer(),
            ],
          ),
        ),
      ),
    );
  }
}
