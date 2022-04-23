import 'package:auto_route/auto_route.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/core/widgets/unicorn_outline_button.dart';
import 'package:disco_app/data/network/repositories/post_repository.dart';
import 'package:disco_app/data/network/repositories/stories_repository.dart';
import 'package:disco_app/injection.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_svg/flutter_svg.dart';

import 'main/bloc/main_bloc.dart';
import 'main/bloc/stories_bloc.dart';

class HomePage extends StatefulWidget {
  const HomePage({Key? key}) : super(key: key);

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  @override
  Widget build(BuildContext context) {
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
          floatingActionButton: Padding(
            padding: const EdgeInsets.only(top: 70),
            child: FloatingActionButton(
              backgroundColor: Colors.transparent,
              elevation: 0.0,
              child: UnicornOutlineButton(
                  onPressed: () {},
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
          floatingActionButtonLocation: FloatingActionButtonLocation.miniCenterDocked,
          extendBody: true,
          backgroundColor: Colors.indigo,
          bottomNavigationBuilder: (context, tabsRouter) {
            return Container(
              decoration: const BoxDecoration(
                gradient: LinearGradient(colors: [
                  DcColors.bottomBarLeft,
                  DcColors.bottomBarRight,
                ]),
                borderRadius: BorderRadius.only(
                  topLeft: Radius.circular(25.0),
                  topRight: Radius.circular(25.0),
                ),
                // boxShadow: [
                //   BoxShadow(
                //       spreadRadius: 5,
                //       offset: const Offset(0, 4),
                //       color: Colors.black.withOpacity(0.25))
                // ],
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
                          color: tabsRouter.activeIndex == 0 ? Colors.orange : DcColors.darkWhite,
                        )),
                    BottomNavigationBarItem(
                        label: '',
                        icon: SvgPicture.asset(
                          'assets/ic_base.svg',
                          height: 30,
                          width: 30,
                          color: tabsRouter.activeIndex == 1 ? Colors.orange : DcColors.darkWhite,
                        )),
                    const BottomNavigationBarItem(
                        label: '',
                        icon: SizedBox(
                          height: 50,
                          width: 50,
                        )),
                    BottomNavigationBarItem(
                        label: '',
                        icon: SvgPicture.asset(
                          'assets/ic_chat.svg',
                          height: 30,
                          width: 30,
                          color: tabsRouter.activeIndex == 3 ? Colors.orange : DcColors.darkWhite,
                        )),
                    BottomNavigationBarItem(
                        label: '',
                        icon: SvgPicture.asset(
                          'assets/ic_profile.svg',
                          height: 30,
                          width: 30,
                          color: tabsRouter.activeIndex == 4 ? Colors.orange : DcColors.darkWhite,
                        )),
                  ]),
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
