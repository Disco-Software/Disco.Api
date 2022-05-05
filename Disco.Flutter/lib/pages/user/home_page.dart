import 'package:auto_route/auto_route.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/core/widgets/unicorn_outline_button.dart';
import 'package:disco_app/data/network/repositories/post_repository.dart';
import 'package:disco_app/data/network/repositories/stories_repository.dart';
import 'package:disco_app/injection.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:just_audio/just_audio.dart';
import 'package:provider/provider.dart';

import 'main/bloc/main_bloc.dart';
import 'main/bloc/stories_bloc.dart';

class HomePage extends StatefulWidget {
  const HomePage({Key? key}) : super(key: key);

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> with SingleTickerProviderStateMixin {
  late AnimationController animationController;

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
  late Widget _switchedWidget = _switchedPlay;

  @override
  void initState() {
    _switchedWidget = _switchedPlay;
    animationController = AnimationController(vsync: this, duration: const Duration(seconds: 1));
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    final audioPlayer = getIt.get<AudioPlayer>();
    return MultiBlocProvider(
      providers: [
        BlocProvider<MainPageBloc>(
            create: (_) => MainPageBloc(
                postRepository: getIt.get<PostRepository>(),
                storiesRepository: getIt.get<StoriesRepository>())),
        BlocProvider<StoriesBloc>(
            create: (_) => StoriesBloc(
                postRepository: getIt.get<PostRepository>(),
                storiesRepository: getIt.get<StoriesRepository>())),
      ],
      child: AutoTabsScaffold(
          extendBody: true,
          backgroundColor: Colors.indigo,
          bottomNavigationBuilder: (context, tabsRouter) {
            return GestureDetector(
              onPanUpdate: (details) {
                if (details.delta.dy > 0) {
                  animationController.reverse();
                }
              },
              child: Stack(
                alignment: Alignment.bottomCenter,
                children: [
                  AnimatedBuilder(
                    child: Container(
                      margin: const EdgeInsets.symmetric(horizontal: 10.0),
                      height: 200.0,
                      decoration: const BoxDecoration(
                        color: Color(0xFF543388),
                        borderRadius: BorderRadius.only(
                          topLeft: Radius.circular(25.0),
                          topRight: Radius.circular(25.0),
                        ),
                      ),
                      child: Padding(
                        padding: const EdgeInsets.only(top: 7.0),
                        child: Row(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            const Spacer(),
                            Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                Text(
                                  'Tinyleopard',
                                  style:
                                      GoogleFonts.aBeeZee(fontSize: 24.0, color: Color(0xFFE6E0D2)),
                                ),
                                Text(
                                  'Guy Flores',
                                  style: GoogleFonts.textMeOne(
                                    fontSize: 18.0,
                                    color: Colors.white,
                                  ),
                                ),
                              ],
                            ),
                            const Spacer(),
                            Padding(
                              padding: const EdgeInsets.only(top: 8.0),
                              child: SvgPicture.asset('assets/ic_arrows_left.svg'),
                            ),
                            const Spacer(),
                            InkWell(
                              onTap: () {
                                if (audioPlayer.playing) {
                                  setState(() {
                                    _switchedWidget = _switchedPlay;
                                  });
                                  audioPlayer.pause();
                                } else {
                                  setState(() {
                                    _switchedWidget = _switchedPause;
                                  });
                                  audioPlayer.play();
                                }
                              },
                              child: Container(
                                width: 55.0,
                                height: 55.0,
                                decoration: const BoxDecoration(
                                  gradient: LinearGradient(colors: [
                                    Color(0xFFDE8820),
                                    Color(0xFFF6EA7D),
                                  ]),
                                  shape: BoxShape.circle,
                                ),
                                child: Center(
                                  child: Container(
                                    width: 50.0,
                                    height: 50.0,
                                    decoration: const BoxDecoration(
                                      color: Color(0xFF543388),
                                      shape: BoxShape.circle,
                                    ),
                                    child: AnimatedSwitcher(
                                      duration: const Duration(milliseconds: 300),
                                      transitionBuilder: (child, animation) => FadeTransition(
                                        opacity: animation,
                                        child: child,
                                      ),
                                      child: Consumer(builder: (BuildContext context, value, Widget? child) {return _  },
                                      child: _switchedWidget),
                                    ),
                                  ),
                                ),
                              ),
                            ),
                            const Spacer(),
                            Padding(
                              padding: const EdgeInsets.only(top: 8.0),
                              child: SvgPicture.asset('assets/ic_arrows_right.svg'),
                            ),
                            const Spacer(),
                          ],
                        ),
                      ),
                    ),
                    builder: (ctx, child) => Align(
                      alignment: Alignment.topCenter,
                      child: child,
                      heightFactor: animationController.value,
                    ),
                    animation: animationController,
                  ),
                  Container(
                    decoration: const BoxDecoration(
                      gradient: LinearGradient(colors: [
                        DcColors.bottomBarLeft,
                        DcColors.bottomBarRight,
                      ]),
                      borderRadius: BorderRadius.only(
                        topLeft: Radius.circular(25.0),
                        topRight: Radius.circular(25.0),
                      ),
                    ),
                    margin: const EdgeInsets.symmetric(horizontal: 10.0),
                    child: BottomNavigationBar(
                        backgroundColor: Colors.transparent,
                        elevation: 0.0,
                        currentIndex: tabsRouter.activeIndex,
                        onTap: tabsRouter.setActiveIndex,
                        type: BottomNavigationBarType.fixed,
                        items: [
                          BottomNavigationBarItem(
                              label: '',
                              icon: SvgPicture.asset(
                                'assets/ic_home.svg',
                                height: 30,
                                width: 30,
                                color: tabsRouter.activeIndex == 0
                                    ? Colors.orange
                                    : DcColors.darkWhite,
                              )),
                          BottomNavigationBarItem(
                              label: '',
                              icon: SvgPicture.asset(
                                'assets/ic_base.svg',
                                height: 30,
                                width: 30,
                                color: tabsRouter.activeIndex == 1
                                    ? Colors.orange
                                    : DcColors.darkWhite,
                              )),
                          BottomNavigationBarItem(
                            label: '',
                            icon: FloatingActionButton(
                              backgroundColor: Colors.transparent,
                              elevation: 0.0,
                              child: UnicornOutlineButton(
                                  onPressed: () {
                                    print('asdds${audioPlayer.audioSource}');
                                    animationController.value == 1
                                        ? animationController.reverse()
                                        : animationController.forward();
                                  },
                                  gradient: const LinearGradient(colors: [
                                    Color(0xffDE9237),
                                    Color(0xFFF6EA7D),
                                  ]),
                                  radius: 360,
                                  strokeWidth: 3,
                                  child: Padding(
                                    padding: const EdgeInsets.only(top: 5),
                                    child: Center(
                                        child: SvgPicture.asset(
                                      'assets/ic_plus.svg',
                                      width: 40,
                                      height: 40,
                                    )),
                                  )),
                              onPressed: () {},
                            ),
                          ),
                          BottomNavigationBarItem(
                              label: '',
                              icon: SvgPicture.asset(
                                'assets/ic_chat.svg',
                                height: 30,
                                width: 30,
                                color: tabsRouter.activeIndex == 3
                                    ? Colors.orange
                                    : DcColors.darkWhite,
                              )),
                          BottomNavigationBarItem(
                              label: '',
                              icon: SvgPicture.asset(
                                'assets/ic_profile.svg',
                                height: 30,
                                width: 30,
                                color: tabsRouter.activeIndex == 4
                                    ? Colors.orange
                                    : DcColors.darkWhite,
                              )),
                        ]),
                  ),
                ],
              ),
            );
          },
          routes: [
            LineRoute(),
            const SavedItemsRoute(),
            const PostRoute(),
            const ChatRoute(),
            const ProfileRoute(),
          ]),
    );
  }
}
