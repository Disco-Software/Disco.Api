import 'package:carousel_slider/carousel_controller.dart';
import 'package:carousel_slider/carousel_slider.dart';
import 'package:disco_app/pages/user/add_post/widgets/add_post_appbar.dart';
import 'package:disco_app/providers/add_post_provider.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:provider/src/provider.dart';

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

  final textController = TextEditingController();
  final CarouselController carouselController = CarouselController();

  int _songIndex = 0;

  @override
  void initState() {
    super.initState();
  }

  @override
  void dispose() {
    textController.dispose();
    super.dispose();
  }

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
          onTap: () => FocusScope.of(context).unfocus(),
          child: ListView(
            children: [
              const SizedBox(height: 30.0),
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 48.0),
                child: TextFormField(
                  controller: textController,
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
              CarouselSlider(
                items: [
                  Padding(
                    padding: const EdgeInsets.symmetric(horizontal: 35.0),
                    child: Stack(
                      children: [
                        Container(
                          color: DcColors.dark,
                          height: 160.0,
                          padding: const EdgeInsets.all(12.0),
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                            children: [
                              Stack(
                                alignment: Alignment.center,
                                children: [
                                  Image.asset(
                                    'assets/default_audio_image.png',
                                    height: 105,
                                    width: 110,
                                    fit: BoxFit.cover,
                                  ),
                                  SvgPicture.asset('assets/ic_picture_front.svg')
                                ],
                              ),
                              Stack(
                                fit: StackFit.loose,
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
                                          print(
                                              'lol1 ${context.read<AddPostProvider>().currentCreatedPost.postSongs.length}');
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
                                              transitionBuilder: (child, animation) =>
                                                  FadeTransition(
                                                opacity: animation,
                                                child: child,
                                              ),
                                              child: _switchedPlay,
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
                                    style:
                                        GoogleFonts.textMeOne(fontSize: 24.0, color: Colors.white),
                                  ),
                                ],
                              ),
                            ],
                          ),
                        ),
                        Align(
                          alignment: Alignment.topRight,
                          child: InkWell(
                            onTap: () {},
                            child: Padding(
                              padding: const EdgeInsets.all(8.0),
                              child: Row(
                                mainAxisSize: MainAxisSize.min,
                                children: [
                                  for (int i = 0; i < 3; i++)
                                    Container(
                                        width: 4,
                                        height: 4,
                                        margin: const EdgeInsets.symmetric(horizontal: 1.0),
                                        decoration: const BoxDecoration(
                                          shape: BoxShape.circle,
                                          color: DcColors.darkWhite,
                                        ))
                                ],
                              ),
                            ),
                          ),
                        )
                      ],
                    ),
                  ),
                ],
                options: CarouselOptions(
                  viewportFraction: 1.0,
                  enableInfiniteScroll: false,
                  onPageChanged: (index, reason) {
                    setState(() {
                      _songIndex = index;
                    });
                  },
                ),
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                mainAxisSize: MainAxisSize.min,
                children: [
                  for (int i = 0; i < 3; i++)
                    const Padding(
                      padding: EdgeInsets.symmetric(horizontal: 3.0),
                      child: ProgressCircle(
                        colors: [Color(0xFFE08D11), Color(0xFFF6EA7D)],
                      ),
                    ),
                ],
              ),
            ],
          ),
        ),
      ),
    );
  }
}

class ProgressCircle extends StatelessWidget {
  final List<Color> colors;

  const ProgressCircle({
    Key? key,
    required this.colors,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      width: 12.0,
      height: 12.0,
      decoration: BoxDecoration(
        shape: BoxShape.circle,
        gradient: LinearGradient(colors: colors),
      ),
    );
  }
}
