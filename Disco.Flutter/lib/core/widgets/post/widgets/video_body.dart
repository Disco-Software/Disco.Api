import 'package:chewie/chewie.dart';
import 'package:disco_app/data/network/network_models/video_network.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:video_player/video_player.dart';

class VideoBody extends StatefulWidget {
  const VideoBody({Key? key, required this.postVideo}) : super(key: key);

  final PostVideo postVideo;

  @override
  State<VideoBody> createState() => _VideoBodyState();
}

class _VideoBodyState extends State<VideoBody> {
  late VideoPlayerController _controller;
  late ChewieController _chewieController;

  @override
  void initState() {
    super.initState();
    _controller = VideoPlayerController.network(widget.postVideo.videoSource ?? '');
    _chewieController = ChewieController(
      videoPlayerController: _controller,
      autoPlay: true,
      deviceOrientationsAfterFullScreen: [DeviceOrientation.portraitUp],
    );
  }

  @override
  void dispose() {
    super.dispose();
    _controller.dispose();
    _chewieController.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Container(
        decoration: BoxDecoration(
          color: Colors.black,
          borderRadius: BorderRadius.circular(12.0),
        ),
        child: Chewie(
          controller: _chewieController,
        ));
  }
}
