import 'package:auto_route/auto_route.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import 'package:video_player/video_player.dart';

class FullScreenVideoPage extends StatefulWidget {
  final String source;
  final VideoPlayerController controller;

  const FullScreenVideoPage({
    Key? key,
    required this.source,
    required this.controller,
  }) : super(key: key);

  @override
  State<FullScreenVideoPage> createState() => _FullScreenVideoPageState();
}

class _FullScreenVideoPageState extends State<FullScreenVideoPage> {
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
  Widget build(BuildContext context) {
    return Material(
      child: Stack(
        children: [
          GestureDetector(
            onTap: () {
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
                  color: Colors.black,
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      AspectRatio(
                        aspectRatio: widget.controller.value.aspectRatio,
                        child: VideoPlayer(widget.controller),
                      ),
                    ],
                  ),
                ),
              ],
            ),
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
          Align(
            alignment: Alignment.topCenter,
            child: Padding(
              padding: const EdgeInsets.only(
                top: 20.0,
                right: 5.0,
              ),
              child: Row(
                children: [
                  const Spacer(),
                  IconButton(
                      onPressed: () {
                        context.router.pop();
                      },
                      icon: const Icon(CupertinoIcons.clear)),
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }
}
