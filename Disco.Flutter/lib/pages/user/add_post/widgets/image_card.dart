import 'dart:io';

import 'package:disco_app/res/colors.dart';
import 'package:disco_app/res/strings.dart';
import 'package:flutter/material.dart';

import '../select_files_page.dart';

class ImageCard extends StatelessWidget {
  const ImageCard({
    Key? key,
    required this.source,
    required this.onThreeDotsTap,
  }) : super(key: key);
  final String source;
  final VoidCallback onThreeDotsTap;

  @override
  Widget build(BuildContext context) {
    return Container(
        color: DcColors.dark,
        height: 360.0,
        child: Column(
          children: [
            Expanded(
              child: Row(
                children: [ThreeDots(onTap: () {})],
                mainAxisAlignment: MainAxisAlignment.end,
              ),
            ),
            Expanded(
              flex: 5,
              child: Image.file(
                File(source),
                height: 318,
                errorBuilder: (ctx, obj, trace) => Image.asset(
                  Strings.defaultSongImage,
                  height: 105,
                  width: 110,
                  fit: BoxFit.cover,
                ),
                fit: BoxFit.cover,
              ),
            )
          ],
        ));
  }
}
