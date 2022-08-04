import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';

class PostButton extends StatelessWidget {
  const PostButton({Key? key, required this.onTap, required this.imagePath})
      : super(key: key);

  final VoidCallback onTap;
  final String imagePath;

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: onTap,
      child: SvgPicture.asset(imagePath, width: 18, height: 18),
    );
  }
}
