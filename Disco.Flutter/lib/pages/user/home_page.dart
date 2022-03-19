import 'package:auto_route/auto_route.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/core/widgets/bottom_bar_item.dart';
import 'package:disco_app/core/widgets/custom_bottom_bar.dart';
import 'package:flutter/material.dart';

class HomePage extends StatelessWidget {
  const HomePage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return AutoTabsScaffold(
        backgroundColor: const Color(0xFF29193E),
        bottomNavigationBuilder: (context, tabsRouter) {
          return CustomBottomBar(
            items: const [
              BottomBarItem(
                id: 0,
                imagePath: "assets/ic_home.svg",
                label: 'line',
              ),
              BottomBarItem(
                id: 1,
                imagePath: "assets/ic_base.svg",
                label: 'saved',
              ),
              BottomBarItem(
                label: 'chat',
                id: 3,
                imagePath: "assets/ic_chat.svg",
              ),
              BottomBarItem(
                label: 'profile',
                id: 4,
                imagePath: "assets/ic_profile.svg",
              )
            ],
            activeTab: tabsRouter.activeIndex,
            onTap: ({int? index, String? label}) {
              if (index != null) {
                tabsRouter.setActiveIndex(index);
              }
              print(tabsRouter.activeIndex);
            },
          );
        },
        routes: const [
          MainRoute(),
          SavedItemsRoute(),
          ChatRoute(),
          ProfileRoute()
        ]);
  }
}
