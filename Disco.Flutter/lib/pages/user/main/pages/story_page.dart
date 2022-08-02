import 'dart:ui';

import 'package:auto_route/auto_route.dart';
import 'package:cube_transition/cube_transition.dart';
import 'package:disco_app/data/local/story_model.dart';
import 'package:disco_app/pages/user/main/bloc/stories_cubit.dart';
import 'package:disco_app/pages/user/main/bloc/stories_state.dart';
import 'package:disco_app/res/strings.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:percent_indicator/linear_percent_indicator.dart';
import 'package:video_player/video_player.dart';

class StoryPage extends StatefulWidget {
  final int index;

  const StoryPage({
    required this.index,
    Key? key,
  }) : super(key: key);

  @override
  State<StoryPage> createState() => _StoryPageState();
}

class _StoryPageState extends State<StoryPage> with SingleTickerProviderStateMixin {
  late AnimationController _controller;
  late PageController _pageController;
  late VideoPlayerController _videoController;
  double animationControllerValue = 0;
  int storyItemIndex = 0;
  String _videoSource = '';

  // List<Duration> itemDurations = [];
  List<StoryModel> stories = [];

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    final storiesImages = context.watch<StoriesCubit>().stories[widget.index].storyImages;
    final List<StoryModel> filteredImages = storiesImages != null
        ? storiesImages
            .map((e) => StoryModel(
                  storyType: StoryType.image,
                  source: e.source ?? '',
                  dateOfCreation: DateTime.parse(e.dateOfCreation ?? '${DateTime.now()}'),
                ))
            .toList(growable: false)
        : [];

    final storyVideos = context.watch<StoriesCubit>().stories[widget.index].storyVideos;
    final List<StoryModel> filteredVideos = storyVideos != null
        ? storyVideos
            .map((e) => StoryModel(
                  storyType: StoryType.video,
                  source: e.source ?? '',
                  dateOfCreation: DateTime.parse(e.dateOfCreation ?? '${DateTime.now()}'),
                ))
            .toList(growable: false)
        : [];

    stories.addAll(filteredImages);
    stories.addAll(filteredVideos);
    stories.sort((a, b) => a.dateOfCreation.compareTo(b.dateOfCreation));

    _controller = AnimationController(vsync: this, duration: const Duration(seconds: 3));
    _controller.forward();
    _pageController = PageController(initialPage: widget.index);
    _controller.addListener(() {
      if (_controller.status == AnimationStatus.completed) {
        if (storyItemIndex + 1 >= stories.length) {
          _videoController.dispose();
          context.router.pop();
        } else {
          storyItemIndex++;
          if (stories.isNotEmpty && stories[storyItemIndex].storyType == StoryType.video) {
            setState(() {
              _videoSource = stories.isNotEmpty ? stories[storyItemIndex].source : '';
              _videoController = VideoPlayerController.network(_videoSource);
              _videoController.initialize().then((value) {
                _controller.duration = _videoController.value.duration;
                _controller.forward(from: 0.0);
                return _videoController.play();
              });
            });
          }
        }
      }
    });
  }

  @override
  void initState() {
    super.initState();
  }

  @override
  void dispose() {
    super.dispose();
    _videoController.dispose();
    _controller.dispose();
    _pageController.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return BlocBuilder<StoriesCubit, StoriesState>(
      builder: (context, state) {
        final height = MediaQuery.of(context).size.height;
        if (state is SuccessStoriesState) {
          final storiesImages = state.stories[widget.index].storyImages ?? [];
          final userStories = state.stories;
          return Scaffold(
            body: Stack(
              children: [
                Center(
                  child: GestureDetector(
                    onTapDown: (_) {
                      animationControllerValue = _controller.value;
                      _controller.stop();
                      _videoController.pause();
                    },
                    onTapUp: (_) {
                      _controller.forward(from: animationControllerValue);
                      _videoController.play();
                    },
                    child: SizedBox(
                      height: height,
                      child: CubePageView.builder(
                        onPageChanged: (index) async {
                          await Future.delayed(const Duration(milliseconds: 1500), () {
                            // _controller.forward(from: 0.0);
                          });
                        },
                        controller: _pageController,
                        itemCount: userStories.length,
                        itemBuilder: (ctx, index, notifier) {
                          return CubeWidget(
                            index: index,
                            pageNotifier: notifier,
                            child: Stack(
                              children: [
                                stories[storyItemIndex].storyType == StoryType.image
                                    ? Image.network(
                                        stories[storyItemIndex].source,
                                        errorBuilder: (_, __, ___) =>
                                            Image.asset(Strings.defaultStoryImage),
                                        height: height,
                                      )
                                    : Center(
                                        child: AspectRatio(
                                        aspectRatio: _videoController.value.aspectRatio,
                                        child: VideoPlayer(_videoController),
                                      )),
                                Column(
                                  children: [
                                    const Spacer(),
                                    Padding(
                                      padding: const EdgeInsets.symmetric(horizontal: 45),
                                      child: Row(
                                        children: [
                                          const Expanded(
                                              child: TextField(
                                            decoration: InputDecoration(
                                              hintText: 'New message...',
                                            ),
                                            style: TextStyle(color: Colors.white),
                                          )),
                                          const SizedBox(width: 20.0),
                                          SvgPicture.asset(
                                            'assets/ic_send.svg',
                                            width: 40,
                                            height: 40,
                                          )
                                        ],
                                      ),
                                    ),
                                    SizedBox(height: MediaQuery.of(context).padding.bottom),
                                  ],
                                ),
                              ],
                            ),
                          );
                        },
                      ),
                    ),
                  ),
                ),
                SafeArea(
                  child: Align(
                    alignment: Alignment.topCenter,
                    child: Row(
                      children: [
                        AnimatedBuilder(
                          builder: (context, index) => LinearPercentIndicator(
                            width: 350,
                            lineHeight: 9,
                            percent: _controller.value,
                            barRadius: const Radius.circular(7),
                            linearGradient: const LinearGradient(
                                colors: [Color(0xFFE08D11), Color(0xFFF6EA7D)]),
                            backgroundColor: const Color(0xFFC9D6FF),
                          ),
                          animation: _controller,
                        ),
                        const SizedBox(width: 10.0),
                        GestureDetector(
                            onTap: () {
                              _videoController.pause();
                              context.router.pop();
                            },
                            child: const Icon(CupertinoIcons.clear)),
                      ],
                    ),
                  ),
                ),
              ],
            ),
          );
        } else {
          return const SizedBox();
        }
      },
    );
  }
}
