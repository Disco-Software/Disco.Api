import 'dart:ui';

import 'package:auto_route/auto_route.dart';
import 'package:cube_transition/cube_transition.dart';
import 'package:disco_app/pages/user/main/bloc/stories_cubit.dart';
import 'package:disco_app/pages/user/main/bloc/stories_state.dart';
import 'package:disco_app/res/strings.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:percent_indicator/linear_percent_indicator.dart';

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

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    final storiesImagesLength =
        context.watch<StoriesCubit>().stories[widget.index].storyImages?.length ?? 0;
    final storyVideoLength =
        context.watch<StoriesCubit>().stories[widget.index].storyVideos?.length ?? 0;
    final storiesLength = context.watch<StoriesCubit>().stories.length;
    final int duration = 3 * (storiesImagesLength + storyVideoLength);
    _controller = AnimationController(vsync: this, duration: Duration(seconds: duration));
    _controller.forward();
    _pageController = PageController(initialPage: widget.index);
    _controller.addListener(() {
      if (_controller.isCompleted) {
        final pageIndex = _pageController.page?.toInt();
        if (pageIndex == storiesLength - 1) {
          Navigator.of(context, rootNavigator: true).pop();
        }
        _pageController.nextPage(
            duration: const Duration(milliseconds: 1500), curve: Curves.easeIn);
      }
    });
  }

  @override
  void dispose() {
    _pageController.dispose();
    _controller.dispose();
    super.dispose();
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
                  child: SizedBox(
                    height: height,
                    child: CubePageView.builder(
                      onPageChanged: (index) async {
                        await Future.delayed(const Duration(milliseconds: 1500), () {
                          _controller.forward(from: 0.0);
                        });
                      },
                      controller: _pageController,
                      itemCount: userStories.length,
                      itemBuilder: (ctx, index, notifier) {
                        // final notifierSafety = notifier ?? 0;
                        final item = userStories[index];
                        // final transform = Matrix4.identity();
                        // final t = (index - notifierSafety).abs();
                        // final scale = lerpDouble(1.5, 0, t);
                        return CubeWidget(
                          index: index,
                          pageNotifier: notifier,
                          child: Stack(
                            children: [
                              Image.network(
                                storiesImages.isNotEmpty ? item.storyImages![0].source ?? '' : '',
                                errorBuilder: (_, __, ___) =>
                                    Image.asset(Strings.defaultStoryImage),
                                height: height,
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
                            ],
                          ),
                        );
                      },
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
