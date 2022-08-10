import 'dart:ui';

import 'package:auto_route/auto_route.dart';
import 'package:cached_network_image/cached_network_image.dart';
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
  late Future<List<Duration>> _storiesDurationFuture;
  double animationControllerValue = 0;
  int storyItemIndex = 0;
  late int storyIndex;
  String _videoSource = '';

  // bool _isImageLoaded = false;

  // List<Duration> itemDurations = [];
  final List<StoryModel> stories = [];

  @override
  void didChangeDependencies() {
    storyIndex = widget.index;
    super.didChangeDependencies();
    final storiesImages = context.watch<StoriesCubit>().stories[storyIndex].storyImages;
    final List<StoryModel> filteredImages = storiesImages != null
        ? storiesImages
            .map((e) => StoryModel(
                  storyType: StoryType.image,
                  source: e.source ?? '',
                  dateOfCreation: DateTime.parse(e.dateOfCreation ?? '${DateTime.now()}'),
                ))
            .toList(growable: false)
        : [];

    final storyVideos = context.watch<StoriesCubit>().stories[storyIndex].storyVideos;
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
    print('LOADED STORIES FOR THIS USER ---> ${stories}');

    _storiesDurationFuture = Future.wait(stories.map((StoryModel story) async {
      switch (story.storyType) {
        case StoryType.image:
          return const Duration(seconds: 3);
        case StoryType.video:
          final _videoController = VideoPlayerController.network(story.source);
          final duration = await _videoController.initialize().then((_) {
            return _videoController.value.duration;
          });
          return duration;
      }
    }).toList(growable: false));
    _pageController = PageController(initialPage: storyIndex);
    _controller = AnimationController(vsync: this, duration: const Duration(milliseconds: 1));

    if (stories.isNotEmpty) {
      if (stories[storyItemIndex].storyType == StoryType.video) {
        print('VIDEO--BREAKPOINT');
        _videoSource = stories.isNotEmpty ? stories[storyItemIndex].source : '';
        _videoController = VideoPlayerController.network(_videoSource);
        _videoController.initialize().then((value) async {
          _controller.duration = _videoController.value.duration;
          _controller.forward();
          await Future.delayed(Duration(milliseconds: 300));
          setState(() {});
          ;
        });
      } else {
        print('Image--BREAKPOINT');
        _controller.duration = const Duration(seconds: 3);
        _controller.forward();
      }
    }

    Future.delayed(Duration.zero, () async {
      final _storiesDurations = await _storiesDurationFuture;
      _controller.duration =
          Duration(milliseconds: _storiesDurations[storyItemIndex].inMilliseconds);
      // if (_isImageLoaded) {

      // }

      // double durationMilliseconds = 0;
      // final durationList = snapshot.data;

      // double durationPercent =
      //     ((durationList![storyItemIndex].inMilliseconds /
      //         durationMilliseconds) *
      //         100.0) *
      //         0.01;
      // print('Dutation ==========>>>> $durationPercent');
      // _controller.duration = Duration(
      //     milliseconds: durationList[storyItemIndex].inMilliseconds);
      // _controller.forward();

      _controller.addListener(() async {
        if (_controller.status == AnimationStatus.completed) {
          if (storyItemIndex + 1 >= stories.length) {
            storyIndex++;
            storyItemIndex = 0;
            if (stories.isNotEmpty && stories[storyItemIndex].storyType == StoryType.video) {
              print('ONE SEC');
              await _pageController.nextPage(
                  duration: const Duration(milliseconds: 300), curve: Curves.easeIn);
              _videoSource = stories.isNotEmpty ? stories[storyItemIndex].source : '';
              _videoController.initialize().then((value) {
                _controller.duration = _videoController.value.duration;
                _controller.forward(from: 0.0);
                return _videoController.play();
              });
            } else {
              print('TWO SEC');

              await _pageController.nextPage(
                  duration: const Duration(milliseconds: 300), curve: Curves.easeIn);
              _controller.duration = const Duration(seconds: 3);
              _controller.forward(from: 0.0);
            }
          } else {
            storyItemIndex++;
            if (stories.isNotEmpty && stories[storyItemIndex].storyType == StoryType.video) {
              setState(() {
                _videoSource = stories.isNotEmpty ? stories[storyItemIndex].source : '';
                _videoController = VideoPlayerController.network(_videoSource);
                _videoController.initialize().then((value) {
                  _controller.duration = _videoController.value.duration;
                  _controller.forward(from: 0.0);
                  setState(() {});
                  return _videoController.play();
                });
              });
            }
          }
        }
      });
    });
  }

  @override
  void dispose() {
    super.dispose();
    _videoController.dispose();
    _controller.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return BlocBuilder<StoriesCubit, StoriesState>(
      builder: (context, state) {
        final height = MediaQuery.of(context).size.height;
        if (state is SuccessStoriesState) {
          final userStories = state.stories;
          final _isStoryImage = stories[storyItemIndex].storyType == StoryType.image;
          return Scaffold(
            body: GestureDetector(
              onTapDown: (_) {
                animationControllerValue = _controller.value;
                _controller.stop();
                if (!_isStoryImage) {
                  _videoController.pause();
                }
              },
              onTapUp: (_) {
                _controller.forward(from: animationControllerValue);
                if (!_isStoryImage) {
                  _videoController.play();
                }
              },
              child: SizedBox(
                height: height,
                child: CubePageView.builder(
                  onPageChanged: (index) async {
                    storyItemIndex = 0;
                    _controller.reset();
                  },
                  controller: _pageController,
                  itemCount: userStories.length,
                  itemBuilder: (ctx, index, notifier) {
                    final _isStoryImage = stories[storyItemIndex].storyType == StoryType.image;
                    print('LOL228 ${_isStoryImage}');
                    return CubeWidget(
                      index: index,
                      pageNotifier: notifier,
                      child: Stack(
                        children: [
                          IgnorePointer(
                            ignoring: true,
                            child: _isStoryImage
                                ? CachedNetworkImage(
                                    imageUrl: stories[storyItemIndex].source,
                                    errorWidget: (_, __, ___) =>
                                        Image.asset(Strings.defaultStoryImage),
                                    height: height,
                                    progressIndicatorBuilder: (context, url, downloadProgress) {
                                      // print('downloadProgress ${downloadProgress.progress}');
                                      // if (downloadProgress.progress == 1) {
                                      //   if (mounted) {
                                      //     _isImageLoaded = true;
                                      //   }
                                      // }

                                      return Center(
                                        child: CircularProgressIndicator(
                                            value: downloadProgress.progress),
                                      );
                                    },
                                  )
                                : Center(
                                    child: AspectRatio(
                                    aspectRatio: _videoController.value.aspectRatio,
                                    child: VideoPlayer(_videoController),
                                  )),
                          ),
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
                                        if (!_isStoryImage &&
                                            _videoController.value.isInitialized) {
                                          _videoController.pause();
                                        }
                                        _controller.stop();
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
                  },
                ),
              ),
            ),
          );
        } else {
          return const SizedBox();
        }
      },
    );
  }
}
