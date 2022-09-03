import 'package:disco_app/res/colors.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';

class PostButton extends StatelessWidget {
  const PostButton({
    Key? key,
    required this.onTap,
    required this.imagePath,
    this.isSelected = false,
  }) : super(key: key);

  final VoidCallback onTap;
  final String imagePath;
  final bool isSelected;

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: SvgPicture.asset(
        imagePath,
        width: 22,
        height: 22,
        color: isSelected ? DcColors.orange : DcColors.white,
      ),
    );
  }
}
