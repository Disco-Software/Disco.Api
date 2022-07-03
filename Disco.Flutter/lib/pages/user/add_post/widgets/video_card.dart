import 'dart:io';

import 'package:disco_app/res/colors.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:video_player/video_player.dart';

import '../select_files_page.dart';
import 'disco_video_player.dart';

class VideoCard extends StatefulWidget {
  const VideoCard({Key? key, required this.source, required this.onThreeDotsTap}) : super(key: key);
  final String source;
  final VoidCallback onThreeDotsTap;

  @override
  State<VideoCard> createState() => _VideoCardState();
}

class _VideoCardState extends State<VideoCard> {
  late VideoPlayerController _controller;

  @override
  void initState() {
    super.initState();
    _controller = VideoPlayerController.file(File(widget.source));
  }

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
              child: DiscoVideoPlayer(
                controller: _controller,
                source: widget.source,
              )),
        ],
      ),
    );
  }
}
