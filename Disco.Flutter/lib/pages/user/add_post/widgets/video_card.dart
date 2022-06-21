import 'dart:io';

import 'package:disco_app/providers/add_post_provider.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import 'package:provider/provider.dart';
import 'package:video_player/video_player.dart';

import '../select_files_page.dart';

class VideoCard extends StatefulWidget {
  const VideoCard({Key? key, required this.source, required this.onThreeDotsTap}) : super(key: key);
  final String source;
  final VoidCallback onThreeDotsTap;

  @override
  State<VideoCard> createState() => _VideoCardState();
}

class _VideoCardState extends State<VideoCard> {
  late VideoPlayerController _controller;
  bool _shouldShowPlayButton = true;

  @override
  void initState() {
    super.initState();
    _controller = VideoPlayerController.file(File(widget.source));
  }

  @override
  void dispose() {
    super.dispose();
    _controller.dispose();
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
              child: Consumer<AddPostProvider>(builder: (ctx, data, child) {
                return Stack(
                  children: [
                    Container(
                      decoration: BoxDecoration(
                        color: Colors.black,
                        borderRadius: BorderRadius.circular(12.0),
                      ),
                      child: _controller.value.isInitialized
                          ? Center(
                              child: AspectRatio(
                                aspectRatio: _controller.value.aspectRatio,
                                child: VideoPlayer(_controller),
                              ),
                            )
                          : Container(),
                    ),
                    if (_shouldShowPlayButton)
                      GestureDetector(
                        child: Center(
                          child: SvgPicture.asset(
                            'assets/ic_play_button.svg',
                            height: 92,
                            width: 92,
                          ),
                        ),
                        onTap: () {
                          setState(() {
                            if (_controller.value.isPlaying) {
                              _controller.pause();
                              _shouldShowPlayButton = true;
                            } else {
                              _controller.play();
                              _shouldShowPlayButton = false;
                            }
                          });
                        },
                      )
                  ],
                );
              })),
        ],
      ),
    );
  }
}
