import 'package:disco_app/data/network/network_models/video_network.dart';
import 'package:disco_app/presentation/pages/user/add_post/widgets/disco_video_player.dart';
import 'package:flutter/material.dart';
import 'package:video_player/video_player.dart';

class VideoBody extends StatefulWidget {
  const VideoBody({Key? key, required this.postVideo}) : super(key: key);

  final PostVideo postVideo;

  @override
  State<VideoBody> createState() => _VideoBodyState();
}

class _VideoBodyState extends State<VideoBody> {
  late VideoPlayerController _controller;

  @override
  void initState() {
    super.initState();
    _controller = VideoPlayerController.network(widget.postVideo.videoSource ?? '');
  }

  @override
  void dispose() {
    super.dispose();
    _controller.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Container(
        decoration: BoxDecoration(
          color: Colors.black,
          borderRadius: BorderRadius.circular(12.0),
        ),
        child: DiscoVideoPlayer(
          controller: _controller,
          source: widget.postVideo.videoSource ?? '',
        ));
  }
}
