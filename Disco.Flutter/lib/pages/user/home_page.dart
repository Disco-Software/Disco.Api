import 'package:auto_route/auto_route.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';

class HomePage extends StatelessWidget {
  const HomePage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    print("run 1 2 3");
    return AutoTabsRouter(
      routes: [
        MainRoute(),
        SavedItemsRoute(),
        AddPostRoute(),
        ChatRoute(),
        ProfileRoute()
      ],
      builder: (context, child, animation) {
        final tabsRouter = AutoTabsRouter.of(context);
        return Scaffold(
          body: child,
          bottomNavigationBar: BottomNavigationBar(
            currentIndex: tabsRouter.activeIndex,
            onTap: (index) => tabsRouter.setActiveIndex(index),
            items: [
              BottomNavigationBarItem(
                  icon: SvgPicture.asset(
                'assets/ic_home.svg',
                height: 30,
                width: 30,
                color: tabsRouter.activeIndex == 0
                    ? Colors.orange
                    : DcColors.darkWhite,
              )),
              BottomNavigationBarItem(
                  icon: SvgPicture.asset(
                'assets/ic_base.svg',
                height: 30,
                width: 30,
                color: tabsRouter.activeIndex == 1
                    ? Colors.orange
                    : DcColors.darkWhite,
              )),
              BottomNavigationBarItem(
                  icon: SvgPicture.asset(
                'assets/ic_plus.svg',
                height: 50,
                width: 50,
                color: tabsRouter.activeIndex == 2
                    ? Colors.orange
                    : DcColors.darkWhite,
              )),
              BottomNavigationBarItem(
                  icon: SvgPicture.asset(
                'assets/ic_chat.svg',
                height: 30,
                width: 30,
                color: tabsRouter.activeIndex == 3
                    ? Colors.orange
                    : DcColors.darkWhite,
              )),
              BottomNavigationBarItem(
                  icon: SvgPicture.asset(
                'assets/ic_profile.svg',
                height: 30,
                width: 30,
                color: tabsRouter.activeIndex == 4
                    ? Colors.orange
                    : DcColors.darkWhite,
              )),
            ],
          ),
        );
      },
    );
    // return AutoTabsScaffold(
    //     backgroundColor: const Color(0xFF29193E),
    //     bottomNavigationBuilder: (context, tabsRouter) {
    //       return BottomNavigationBar(
    //           currentIndex: tabsRouter.activeIndex,
    //           onTap: tabsRouter.setActiveIndex,
    //           items: [
    //             BottomNavigationBarItem(
    //                 icon: SvgPicture.asset(
    //               'assets/ic_home.svg',
    //               height: 30,
    //               width: 30,
    //               color: tabsRouter.activeIndex == 0
    //                   ? Colors.orange
    //                   : DcColors.darkWhite,
    //             )),
    //             BottomNavigationBarItem(
    //                 icon: SvgPicture.asset(
    //               'assets/ic_base.svg',
    //               height: 30,
    //               width: 30,
    //               color: tabsRouter.activeIndex == 1
    //                   ? Colors.orange
    //                   : DcColors.darkWhite,
    //             )),
    //             BottomNavigationBarItem(
    //                 icon: SvgPicture.asset(
    //               'assets/ic_plus.svg',
    //               height: 50,
    //               width: 50,
    //               color: tabsRouter.activeIndex == 2
    //                   ? Colors.orange
    //                   : DcColors.darkWhite,
    //             )),
    //             BottomNavigationBarItem(
    //                 icon: SvgPicture.asset(
    //               'assets/ic_chat.svg',
    //               height: 30,
    //               width: 30,
    //               color: tabsRouter.activeIndex == 3
    //                   ? Colors.orange
    //                   : DcColors.darkWhite,
    //             )),
    //             BottomNavigationBarItem(
    //                 icon: SvgPicture.asset(
    //               'assets/ic_profile.svg',
    //               height: 30,
    //               width: 30,
    //               color: tabsRouter.activeIndex == 4
    //                   ? Colors.orange
    //                   : DcColors.darkWhite,
    //             )),
    //           ]);
    //     },
    //     routes: const [
    //       MainRoute(),
    //       SavedItemsRoute(),
    //       AddPostRoute(),
    //       ChatRoute(),
    //       ProfileRoute()
    //     ]);
  }
}
