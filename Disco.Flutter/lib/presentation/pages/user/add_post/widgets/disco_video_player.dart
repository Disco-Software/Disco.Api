import 'package:auto_route/auto_route.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:percent_indicator/linear_percent_indicator.dart';
import 'package:video_player/video_player.dart';

class DiscoVideoPlayer extends StatefulWidget {
  final VideoPlayerController controller;
  final String source;
  final bool isFullscreenMode;

  const DiscoVideoPlayer({
    Key? key,
    required this.controller,
    required this.source,
    this.isFullscreenMode = false,
  }) : super(key: key);

  @override
  State<DiscoVideoPlayer> createState() => _DiscoVideoPlayerState();
}

class _DiscoVideoPlayerState extends State<DiscoVideoPlayer> {
  bool _shouldShowShadowLayer = false;
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
    widget.controller.initialize().then((value) => setState(() {}));
  }

  @override
  Widget build(BuildContext context) {
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
            child: widget.controller.value.isInitialized
                ? Center(
                    child: AspectRatio(
                      aspectRatio: widget.controller.value.aspectRatio,
                      child: VideoPlayer(widget.controller),
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
                  child: widget.controller.value.isPlaying ? _switchedPause : _switchedPlay,
                ),
              ),
              onTap: () {
                setState(() {
                  if (widget.controller.value.isPlaying) {
                    widget.controller.pause();
                    _shouldShowShadowLayer = true;
                  } else {
                    widget.controller.play();

                    _shouldShowShadowLayer = false;
                  }
                });
              },
            ),
          if (_shouldShowShadowLayer)
            Padding(
              padding: widget.isFullscreenMode
                  ? const EdgeInsets.only(bottom: 25.0)
                  : const EdgeInsets.all(0),
              child: Align(
                child: AnimatedBuilder(
                  builder: (context, index) => Row(
                    children: [
                      Row(
                        children: [
                          _VideoScrubber(
                            controller: widget.controller,
                            child: LinearPercentIndicator(
                              width: widget.isFullscreenMode ? 300 : 200,
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
                            icon: Icon(
                              widget.isFullscreenMode
                                  ? CupertinoIcons.fullscreen_exit
                                  : CupertinoIcons.fullscreen,
                              size: 15.0,
                            ),
                            onPressed: () {
                              if (!widget.isFullscreenMode) {
                                context.router.push(FullScreenVideoRoute(
                                    source: widget.source, controller: widget.controller));
                              } else {
                                context.router.pop();
                              }
                            },
                          ),
                        ],
                      ),
                    ],
                    mainAxisAlignment: MainAxisAlignment.center,
                  ),
                  animation: widget.controller,
                ),
                alignment: Alignment.bottomCenter,
              ),
            ),
        ],
      ),
    );
  }

  double _getVideoPositionPercent() {
    final int duration = widget.controller.value.duration.inMilliseconds;
    final int position = widget.controller.value.position.inMilliseconds;
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
