import 'package:disco_app/core/widgets/bottom_bar_item.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';

class CustomBottomBar extends StatelessWidget {
  const CustomBottomBar({Key? key}) : super(key: key);
  final int _activeTab = 0;
  @override
  Widget build(BuildContext context) {
    return Container(
        padding: const EdgeInsets.symmetric(vertical: 20.0, horizontal: 40.0),
        child: Row(
          children: [
            BottomBarItem(
              onTap: () {
                if (_activeTab != 0) {
                  Navigator.of(context).pushNamed('/line');
                }
              },
              id: 0,
              imagePath: "assets/ic_home.svg",
              color: _activeTab == 0
                  ? DcColors.tabbarItemSelected
                  : DcColors.darkWhite,
            ),
            const Spacer(),
            BottomBarItem(
              onTap: () {
                if (_activeTab != 1) {
                  Navigator.of(context).pushNamed('/saved');
                }
              },
              id: 1,
              imagePath: "assets/ic_base.svg",
              color: _activeTab == 1
                  ? DcColors.tabbarItemSelected
                  : DcColors.darkWhite,
            ),
            const Spacer(),
            Material(
                type: MaterialType
                    .transparency, //Makes it usable on any background color, thanks @IanSmith
                child: Ink(
                  decoration: BoxDecoration(
                    border: Border.all(
                        color: DcColors.floatingActionButtonColor, width: 4.0),
                    color: Colors.transparent,
                    shape: BoxShape.circle,
                  ),
                  child: InkWell(
                    //This keeps the splash effect within the circle
                    borderRadius: BorderRadius.circular(
                        1000.0), //Something large to ensure a circle
                    child: Padding(
                      padding: const EdgeInsets.all(5),
                      child: SvgPicture.asset('assets/ic_plus.svg'),
                    ),
                  ),
                )),
            const Spacer(),
            BottomBarItem(
              onTap: () {
                if (_activeTab != 3) {
                  Navigator.of(context).pushNamed('/chat');
                }
              },
              id: 3,
              imagePath: "assets/ic_chat.svg",
              color: _activeTab == 3
                  ? DcColors.tabbarItemSelected
                  : DcColors.darkWhite,
            ),
            const Spacer(),
            BottomBarItem(
                onTap: () {
                  if (_activeTab != 4) {
                    Navigator.of(context).pushNamed('/profile');
                  }
                },
                id: 4,
                imagePath: "assets/ic_profile.svg",
                color: _activeTab == 4
                    ? DcColors.tabbarItemSelected
                    : DcColors.darkWhite),
          ],
        ),
        decoration: const BoxDecoration(
          gradient: LinearGradient(
              colors: [DcColors.bottomBarLeft, DcColors.bottomBarRight]),
          borderRadius: BorderRadius.only(
            topRight: Radius.circular(27),
            topLeft: Radius.circular(27),
          ),
        ));
  }
}
