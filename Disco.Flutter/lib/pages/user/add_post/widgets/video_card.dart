import 'dart:io';

import 'package:auto_route/auto_route.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/providers/add_post_provider.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import 'package:percent_indicator/linear_percent_indicator.dart';
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
  bool _shouldShowShadowLayer = true;

  final Widget _switchedPause = Padding(
    key: const ValueKey(1),
    padding: const EdgeInsets.all(4.0),
    child: Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Image.asset('assets/ic_rectangle_big.png'),
        Image.asset('assets/ic_rectangle_big.png'),
      ],
    ),
  );

  final Widget _switchedPlay = SvgPicture.asset(
    'assets/ic_play_button.svg',
    height: 60,
    width: 60,
    key: const ValueKey(2),
  );

  @override
  void initState() {
    super.initState();
    _controller = VideoPlayerController.file(File(widget.source))
      ..initialize().then((value) => setState(() {}));
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
                return GestureDetector(
                  onTap: () async {
                    if (_shouldShowShadowLayer) {
                      _shouldShowShadowLayer = false;
                    } else {
                      _shouldShowShadowLayer = true;
                      Future.delayed(const Duration(seconds: 2), () {
                        setState(() {
                          _shouldShowShadowLayer = false;
                        });
                      });
                    }
                    setState(() {});
                  },
                  child: Stack(
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
                      if (_shouldShowShadowLayer)
                        Container(
                          color: Colors.black.withOpacity(0.3),
                        ),
                      if (_shouldShowShadowLayer)
                        GestureDetector(
                          child: Center(
                            child: AnimatedSwitcher(
                              duration: const Duration(milliseconds: 300),
                              transitionBuilder: (child, animation) => FadeTransition(
                                opacity: animation,
                                child: child,
                              ),
                              child: _controller.value.isPlaying ? _switchedPause : _switchedPlay,
                            ),
                          ),
                          onTap: () {
                            setState(() {
                              if (_controller.value.isPlaying) {
                                _controller.pause();
                                _shouldShowShadowLayer = true;
                              } else {
                                _controller.play();

                                _shouldShowShadowLayer = false;
                              }
                            });
                          },
                        ),
                      if (_shouldShowShadowLayer)
                        Align(
                          child: AnimatedBuilder(
                            builder: (context, index) => Row(
                              children: [
                                Row(
                                  children: [
                                    _VideoScrubber(
                                      controller: _controller,
                                      child: LinearPercentIndicator(
                                        width: 200,
                                        lineHeight: 9,
                                        percent: _getVideoPositionPercent(),
                                        barRadius: const Radius.circular(7),
                                        linearGradient: const LinearGradient(
                                            colors: [Color(0xFFE08D11), Color(0xFFF6EA7D)]),
                                        backgroundColor: const Color(0xFFC9D6FF),
                                        widgetIndicator: Container(
                                          width: 11.0,
                                          height: 20.0,
                                          decoration: BoxDecoration(
                                              color: DcColors.darkWhite,
                                              borderRadius: BorderRadius.circular(20.0)),
                                        ),
                                      ),
                                    ),
                                    IconButton(
                                      icon: const Icon(
                                        CupertinoIcons.fullscreen,
                                        size: 15.0,
                                      ),
                                      onPressed: () {
                                        context.router.push(FullScreenVideoRoute(
                                            source: widget.source, controller: _controller));
                                      },
                                    ),
                                  ],
                                ),
                              ],
                              mainAxisAlignment: MainAxisAlignment.center,
                            ),
                            animation: _controller,
                          ),
                          alignment: Alignment.bottomCenter,
                        ),
                    ],
                  ),
                );
              })),
        ],
      ),
    );
  }

  double _getVideoPositionPercent() {
    final int duration = _controller.value.duration.inMilliseconds;
    final int position = _controller.value.position.inMilliseconds;
    return position / duration;
  }
}

class _VideoScrubber extends StatefulWidget {
  const _VideoScrubber({
    required this.child,
    required this.controller,
  });

  final Widget child;
  final VideoPlayerController controller;

  @override
  _VideoScrubberState createState() => _VideoScrubberState();
}

class _VideoScrubberState extends State<_VideoScrubber> {
  bool _controllerWasPlaying = false;

  VideoPlayerController get controller => widget.controller;

  @override
  Widget build(BuildContext context) {
    void seekToRelativePosition(Offset globalPosition) {
      final RenderBox box = context.findRenderObject() as RenderBox;
      final Offset tapPos = box.globalToLocal(globalPosition);
      final double relative = tapPos.dx / box.size.width;
      final Duration position = controller.value.duration * relative;
      controller.seekTo(position);
    }

    return GestureDetector(
      behavior: HitTestBehavior.opaque,
      child: widget.child,
      onHorizontalDragStart: (DragStartDetails details) {
        if (!controller.value.isInitialized) {
          return;
        }
        _controllerWasPlaying = controller.value.isPlaying;
        if (_controllerWasPlaying) {
          controller.pause();
        }
      },
      onHorizontalDragUpdate: (DragUpdateDetails details) {
        if (!controller.value.isInitialized) {
          return;
        }
        seekToRelativePosition(details.globalPosition);
      },
      onHorizontalDragEnd: (DragEndDetails details) {
        if (_controllerWasPlaying && controller.value.position != controller.value.duration) {
          controller.play();
        }
      },
      onTapDown: (TapDownDetails details) {
        if (!controller.value.isInitialized) {
          return;
        }
        seekToRelativePosition(details.globalPosition);
      },
    );
  }
}
