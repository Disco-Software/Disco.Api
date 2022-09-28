import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';

class BottomBarItem extends StatelessWidget {
  const BottomBarItem(
      {Key? key,
      required this.imagePath,
      required this.id,
      required this.label})
      : super(key: key);

  final int id;
  final String imagePath;
  final String label;
  @override
  Widget build(BuildContext context) {
    return SvgPicture.asset(
      imagePath,
      width: 30.0,
      height: 30.0,
    );
  }
}
