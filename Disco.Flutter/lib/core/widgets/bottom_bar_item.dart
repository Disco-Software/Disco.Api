import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';

class BottomBarItem extends StatelessWidget {
  const BottomBarItem(
      {Key? key,
      required onTap,
      required imagePath,
      required id,
      required color})
      : _imagePath = imagePath,
        _id = id,
        _color = color,
        _onTap = onTap,
        super(key: key);

  final Function() _onTap;
  final int _id;
  final String _imagePath;
  final Color _color;

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: _onTap,
      child: SvgPicture.asset(
        _imagePath,
        width: 30.0,
        color: _color,
        height: 30.0,
      ),
    );
  }
}
