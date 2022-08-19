import 'package:auto_route/src/router/auto_router_x.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/core/widgets/post/post.dart';
import 'package:disco_app/core/widgets/unicorn_image.dart';
import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/pages/user/main/bloc/posts_cubit.dart';
import 'package:disco_app/pages/user/main/bloc/stories_cubit.dart';
import 'package:disco_app/pages/user/main/bloc/stories_state.dart';
import 'package:disco_app/res/numbers.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:pull_to_refresh/pull_to_refresh.dart';

import 'bloc/posts_state.dart';

const String title = 'Your story';

class MainPage extends StatelessWidget {
  const MainPage({Key? key, this.shouldLoadData = true}) : super(key: key);
  final bool shouldLoadData;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xff1C142E),
      body: _SuccessStateWidget(
        shouldLoadData: shouldLoadData,
      ),
    );
  }
}

// void _blocLisener(BuildContext context, Object? state) {
//   WidgetsBinding.instance?.addPostFrameCallback((timeStamp) {
//     if (state is SuccessState) {}
//   });
// }

// onSearch() {}

class _SuccessStateWidget extends StatefulWidget {
  final bool shouldLoadData;

  const _SuccessStateWidget({Key? key, required this.shouldLoadData}) : super(key: key);

  @override
  State<_SuccessStateWidget> createState() => _SuccessStateWidgetState();
}

class _SuccessStateWidgetState extends State<_SuccessStateWidget> {
  final RefreshController _refreshController = RefreshController(initialRefresh: false);
  final List<Post> _posts = [];

  // final List<StoriesModel> _stories = [];
  int _postNumberPage = 1;

  // int _storiesNumberPage = 1;
  bool isLastBlocPaginationPage = false;

  @override
  void initState() {
    super.initState();
    context.read<PostsCubit>().loadPosts(pageNumber: 1, isInitial: true);
    context.read<StoriesCubit>().loadStories(isInitial: true);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        backgroundColor: const Color(0xff1C142E),
        body: NestedScrollView(
          headerSliverBuilder: (BuildContext context, bool innerBoxIsScrolled) {
            return [
              SliverAppBar(
                backgroundColor: const Color(0xFF1C142D),
                centerTitle: false,
                title: const Text(
                  "DISCO",
                  style: TextStyle(
                    fontSize: 32,
                    fontFamily: 'Colonna',
                    fontWeight: FontWeight.bold,
                  ),
                  textAlign: TextAlign.start,
                ),
                automaticallyImplyLeading: true,
                actions: [
                  IconButton(
                      padding: const EdgeInsets.only(right: 32),
                      onPressed: () {
                        /// context.read<PostsCubit>().add(InitialEvent(id: 1));
                      },
                      icon: SvgPicture.asset(
                        "assets/ic_search.svg",
                        width: 32,
                        height: 30,
                      )),
                ],
              ),
              BlocConsumer<StoriesCubit, StoriesState>(
                listener: (context, state) {
                  // if (state is SuccessStoriesState) {
                  //   _stories.addAll(state.stories);
                  //   setState(() {});
                  //   if (state.stories.length < Numbers.storiesPageSize) {
                  //     context.read<StoriesCubit>().isLastPage = true;
                  //   } else {
                  //     _storiesNumberPage++;
                  //   }
                  // }
                },
                builder: (context, state) {
                  if (context.read<StoriesCubit>().stories.isNotEmpty) {
                    return SliverToBoxAdapter(
                      child: Stack(
                        children: [
                          SizedBox(
                            height: 110,
                            child: NotificationListener(
                              onNotification: (ScrollNotification scrollInfo) {
                                if (scrollInfo is ScrollEndNotification &&
                                    !context.read<StoriesCubit>().isLastPage) {
                                  context.read<StoriesCubit>().loadStories();
                                }
                                return true;
                              },
                              child: _posts.isNotEmpty
                                  ? ListView.builder(
                                      scrollDirection: Axis.horizontal,
                                      itemBuilder: (ctx, index) {
                                        if (index == 0) {
                                          return GestureDetector(
                                            onTap: () {},
                                            child: Padding(
                                              padding: const EdgeInsets.only(left: 12, right: 8),
                                              child: UnicornImage(
                                                title: "Your story",
                                                imageUrl: (state is SuccessStoriesState)
                                                    ? state.userImageUrl
                                                    : '',
                                                shouldHaveGradientBorder: false,
                                                shouldHavePlus: true,
                                              ),
                                            ),
                                          );
                                        } else {
                                          return GestureDetector(
                                            onTap: () => context.router.push(StoryRoute(
                                                index: index - 1,
                                                totalLength: _posts.length,
                                                key: ValueKey(index - 1))),
                                            child: Padding(
                                              padding: const EdgeInsets.symmetric(horizontal: 8),
                                              child: UnicornImage(
                                                imageUrl: context
                                                        .read<StoriesCubit>()
                                                        .stories[index - 1]
                                                        .profile
                                                        ?.photo ??
                                                    '',
                                                title: context
                                                        .read<StoriesCubit>()
                                                        .stories[index - 1]
                                                        .profile
                                                        ?.user
                                                        ?.userName ??
                                                    "",
                                              ),
                                            ),
                                          );
                                        }
                                      },
                                      itemCount: context.read<StoriesCubit>().stories.length + 1,
                                    )
                                  : const Center(child: CircularProgressIndicator()),
                            ),
                          ),
                          if (state is LoadingStoriesState)
                            Container(
                              color: Colors.black.withOpacity(0.3),
                              height: 110,
                            ),
                          if (state is LoadingStoriesState)
                            const Padding(
                              padding: EdgeInsets.only(top: 5.0),
                              child: Align(
                                  alignment: Alignment.center, child: CircularProgressIndicator()),
                            ),
                        ],
                      ),
                    );
                  } else {
                    return SliverToBoxAdapter(
                      child: Padding(
                        padding: const EdgeInsets.only(right: 8, top: 8),
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.start,
                          children: [
                            const SizedBox(
                              width: 12,
                            ),
                            UnicornImage(
                              title: "Your story",
                              imageUrl: (state is SuccessStoriesState) ? state.userImageUrl : '',
                              shouldHaveGradientBorder: false,
                              shouldHavePlus: true,
                            ),
                          ],
                        ),
                      ),
                    );
                  }
                  return const SliverToBoxAdapter(child: SizedBox());
                },
              ),
            ];
          },
          body: NotificationListener<ScrollNotification>(
            onNotification: (ScrollNotification scrollInfo) {
              if (scrollInfo is ScrollEndNotification && !context.read<PostsCubit>().isLastPage) {
                context.read<PostsCubit>().loadPosts(pageNumber: _postNumberPage);
              }
              return true;
            },
            child: SmartRefresher(
              controller: _refreshController,
              onRefresh: () {
                context.read<PostsCubit>().loadPosts(
                      onLoaded: (_) {
                        _refreshController.refreshCompleted();
                      },
                      pageNumber: 1,
                    );
              },
              child: CustomScrollView(
                slivers: [
                  const SliverToBoxAdapter(),
                  SliverList(
                    delegate: SliverChildBuilderDelegate(
                      (ctx, index) {
                        return UnicornPost(post: _posts[index]);
                      },
                      childCount: _posts.length,
                    ),
                  ),
                  const SliverPadding(padding: EdgeInsets.only(bottom: 50.0)),
                  BlocConsumer<PostsCubit, PostsState>(
                    listener: (context, state) {
                      if (state is SuccessPostsState) {
                        _posts.addAll(state.posts);
                        setState(() {});
                        if (state.posts.length < Numbers.postsPageSize) {
                          context.read<PostsCubit>().isLastPage = true;
                        } else {
                          _postNumberPage++;
                        }
                      }
                    },
                    builder: (context, state) {
                      if (state is LoadingPostsState) {
                        return const SliverToBoxAdapter(
                          child: Center(child: CircularProgressIndicator()),
                        );
                      } else {
                        return const SliverToBoxAdapter(child: SizedBox());
                      }
                    },
                  ),
                  const SliverToBoxAdapter(child: SizedBox(height: 200.0)),
                ],
              ),
            ),
          ),
        ));
  }
}
