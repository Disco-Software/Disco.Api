import 'package:disco_app/res/colors.dart';
import 'package:flutter/material.dart';

import 'bottom_bar_item.dart';

class CustomBottomBar extends StatelessWidget {
  const CustomBottomBar(
      {Key? key, required this.activeTab, required this.items, required this.onTap})
      : super(key: key);
  final int activeTab;
  final List<BottomBarItem> items;
  final Function({required int index, required String label}) onTap;
  @override
  Widget build(BuildContext context) {
    return Container(
        padding: const EdgeInsets.symmetric(vertical: 20.0, horizontal: 40.0),
        child: Row(
          children: [
            InkWell(
              child: items[0],
              onTap: () => onTap(index: 0, label: items[0].label),
            ),
            InkWell(
              child: items[1],
              onTap: () => onTap(index: 1, label: items[1].label),
            ),
            InkWell(
              child: items[2],
              onTap: () => onTap(index: 2, label: items[2].label),
            ),
            InkWell(
              child: items[3],
              onTap: () => onTap(index: 3, label: items[3].label),
            ),
          ],
        ),
        decoration: const BoxDecoration(
          gradient: LinearGradient(colors: [DcColors.bottomBarLeft, DcColors.bottomBarRight]),
          borderRadius: BorderRadius.only(
            topRight: Radius.circular(27),
            topLeft: Radius.circular(27),
          ),
        ));
  }
}
