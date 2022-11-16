import 'dart:ui';

import 'package:auto_route/auto_route.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/data/local/story_model.dart';
import 'package:disco_app/data/network/network_models/account_network.dart';
import 'package:disco_app/data/network/network_models/story_network.dart';
import 'package:disco_app/presentation/pages/user/main/bloc/stories_cubit.dart';
import 'package:disco_app/presentation/pages/user/main/bloc/stories_state.dart';
import 'package:disco_app/presentation/pages/user/main/pages/stories/story_view/story_view.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_svg/svg.dart';
import 'package:google_fonts/google_fonts.dart';

class StoryPage extends StatefulWidget {
  final int index;
  final int totalLength;

  const StoryPage({
    required this.index,
    required this.totalLength,
    Key? key,
  }) : super(key: key);

  @override
  State<StoryPage> createState() => _StoryPageState();
}

class _StoryPageState extends State<StoryPage> with SingleTickerProviderStateMixin {
  late int storyIndex;
  late StoryController _storyController;
  final List<StoryModel> stories = [];
  List<StoryItem> newStories = [];
  late int _totalLength;
  Account? currentUser;
  final FocusNode _textFieldFocus = FocusNode();
  final TextEditingController _textController = TextEditingController();
  // final PageController _pageController = PageController();

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    _totalLength = widget.totalLength;
    storyIndex = widget.index;
    List<StoriesModel> newCubitStories = context.watch<StoriesCubit>().stories;
    if (newCubitStories.isNotEmpty && storyIndex < newCubitStories.length) {
      final storiesImages = newCubitStories[storyIndex].storyImages;
      currentUser = context.watch<StoriesCubit>().stories[storyIndex].profile;
      final List<StoryModel> filteredImages = storiesImages != null
          ? storiesImages
              .map((e) => StoryModel(
                    storyType: StoryType.image,
                    source: e.source ?? '',
                    dateOfCreation: DateTime.parse(e.dateOfCreation ?? '${DateTime.now()}'),
                  ))
              .toList(growable: false)
          : [];
      _storyController = StoryController();

      final storyVideos = newCubitStories[storyIndex].storyVideos;
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
      newStories = stories.map((e) {
        if (e.storyType == StoryType.video) {
          return StoryItem.pageVideo(
            e.source,
            controller: _storyController,
          );
        } else {
          return StoryItem.pageImage(
            url: e.source,
            controller: _storyController,
          );
        }
      }).toList();
    } else {
      _storyController = StoryController();
      newStories.add(StoryItem.pageImage(
        url: '',
        controller: _storyController,
      ));
      context.router.pop();
    }

    print('LOADED STORIES FOR THIS USER ---> ${stories}');
  }

  @override
  void dispose() {
    super.dispose();
    _textFieldFocus.dispose();
    _textController.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return BlocBuilder<StoriesCubit, StoriesState>(
      builder: (context, state) {
        if (state is SuccessStoriesState) {
          return Scaffold(
            body: Stack(
              children: [
                GestureDetector(
                  onTap: () {
                    FocusScope.of(context).unfocus();
                  },
                  child: Material(
                    type: MaterialType.transparency,
                    child: StoryView(
                      onCloseTap: () {},
                      // onTap: () {
                      //   if (_textFieldFocus.hasFocus) {
                      //     _textFieldFocus.unfocus();
                      //   }
                      // },
                      storyItems: newStories,
                      controller: _storyController,
                      onComplete: () {
                        if (widget.index + 1 < widget.totalLength) {
                          context.router.popAndPush(
                            AnimatedStoryRoute(
                              index: widget.index + 1,
                              totalLength: _totalLength,
                              key: ValueKey(widget.index + 1),
                            ),
                          );
                        } else {
                          context.router.pop();
                        }
                      },
                      onVerticalSwipeComplete: (direction) {
                        if (direction == Direction.down) {
                          context.router.pop();
                        }
                        if (direction == Direction.left) {
                          context.router.replace(AnimatedStoryRoute(
                              index: widget.index + 1,
                              totalLength: _totalLength,
                              key: ValueKey(
                                widget.index + 1,
                              )));
                        }
                      },
                      onStoryShow: (item) {
                        _storyController.play();
                        int pos = newStories.indexOf(item);
                        if (pos > 0) {
                          setState(() {});
                        }
                      },
                    ),
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.only(top: 75.0, left: 20.0),
                  child: Row(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    children: [
                      ClipOval(
                        child: currentUser != null &&
                                currentUser!.photo != null &&
                                currentUser!.photo!.isNotEmpty
                            ? Container(
                                color: Colors.white,
                                child: Image.network(
                                  currentUser?.photo ?? '',
                                  height: 50,
                                  width: 50,
                                ),
                              )
                            : Container(
                                color: Colors.white,
                                child: Image.asset(
                                  'assets/ic_photo.png',
                                  height: 50,
                                  width: 50,
                                ),
                              ),
                      ),
                      const SizedBox(width: 16),
                      Text(
                        currentUser?.user?.userName ?? 'Name',
                        style: GoogleFonts.aBeeZee(
                          color: const Color(0xFFE6E0D2),
                          fontSize: 16,
                        ),
                      ),
                    ],
                  ),
                ),
                Column(
                  children: [
                    const Spacer(),
                    Padding(
                      padding: const EdgeInsets.symmetric(horizontal: 45),
                      child: Row(
                        children: [
                          Expanded(
                              child: Focus(
                            onFocusChange: (hasFocus) {
                              if (hasFocus) {
                                _storyController.pause();
                              } else {
                                _storyController.play();
                              }
                            },
                            child: TextField(
                              focusNode: _textFieldFocus,
                              decoration: const InputDecoration(
                                hintText: 'New message...',
                              ),
                              style: const TextStyle(color: Colors.white),
                            ),
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
        } else {
          return const SizedBox();
        }
      },
    );
  }
}
