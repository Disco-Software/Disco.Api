import 'package:disco_app/core/widgets/post/post.dart';
import 'package:disco_app/core/widgets/unicorn_image.dart';
import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/pages/user/main/bloc/main_bloc.dart';
import 'package:disco_app/pages/user/main/bloc/main_event.dart';
import 'package:disco_app/pages/user/main/bloc/stories_bloc.dart';
import 'package:disco_app/pages/user/main/bloc/stories_event.dart';
import 'package:disco_app/pages/user/main/bloc/stories_state.dart';
import 'package:disco_app/res/numbers.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:pull_to_refresh/pull_to_refresh.dart';

import 'bloc/main_state.dart';

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

  _SuccessStateWidget({Key? key, required this.shouldLoadData}) : super(key: key);

  @override
  State<_SuccessStateWidget> createState() => _SuccessStateWidgetState();
}

class _SuccessStateWidgetState extends State<_SuccessStateWidget> {
  final RefreshController _refreshController = RefreshController(initialRefresh: false);
  final List<Post> _posts = [];
  int _postNumberPage = 1;
  bool isLastBlocPaginationPage = false;

  @override
  void initState() {
    super.initState();
    context.read<MainPageBloc>().add(LoadPostsEvent(pageNumber: 1, hasLoading: true));
    context.read<StoriesBloc>().add(LoadStoriesEvent(
          pageNumber: 1,
        ));
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
                        /// context.read<MainPageBloc>().add(InitialEvent(id: 1));
                      },
                      icon: SvgPicture.asset(
                        "assets/ic_search.svg",
                        width: 32,
                        height: 30,
                      )),
                ],
              ),
              BlocBuilder<StoriesBloc, StoriesState>(
                builder: (context, state) {
                  if (state is SuccessStoriesState) {
                    if (state.stories.isNotEmpty) {
                      return SliverToBoxAdapter(
                        child: SizedBox(
                          height: 110,
                          child: ListView.builder(
                            scrollDirection: Axis.horizontal,
                            itemBuilder: (ctx, index) {
                              if (index == 0) {
                                return Padding(
                                  padding: const EdgeInsets.only(left: 12, right: 8),
                                  child: UnicornImage(
                                    title: "Your story",
                                    imageUrl: state.userImageUrl,
                                    shouldHaveGradientBorder: false,
                                    shouldHavePlus: true,
                                  ),
                                );
                              } else {
                                return Padding(
                                  padding: const EdgeInsets.symmetric(horizontal: 8),
                                  child: UnicornImage(
                                    imageUrl: state.stories[index].profile?.photo ??
                                        "assets/ic_photo.png",
                                    title: state.stories[index].profile?.user?.userName ?? "",
                                  ),
                                );
                              }
                            },
                            itemCount: state.stories.length,
                          ),
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
                                imageUrl: state.userImageUrl,
                                shouldHaveGradientBorder: false,
                                shouldHavePlus: true,
                              ),
                            ],
                          ),
                        ),
                      );
                    }
                  }
                  return const SliverToBoxAdapter(child: SizedBox());
                },
              ),
            ];
          },
          body: NotificationListener<ScrollNotification>(
            onNotification: (ScrollNotification scrollInfo) {
              if (scrollInfo.metrics.pixels >= scrollInfo.metrics.maxScrollExtent) {
                context
                    .read<MainPageBloc>()
                    .add(LoadPostsEvent(pageNumber: _postNumberPage, hasLoading: false));
              }

              print(
                  'SUPER METRICS  --> ${scrollInfo.metrics.pixels} === ${scrollInfo.metrics.maxScrollExtent}');
              return true;
            },
            child: SmartRefresher(
              controller: _refreshController,
              onRefresh: () {
                context.read<MainPageBloc>().add(LoadPostsEvent(
                      hasLoading: false,
                      onLoaded: (_) {
                        _refreshController.refreshCompleted();
                      },
                      pageNumber: 1,
                    ));
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
                  BlocConsumer<MainPageBloc, MainPageState>(
                    listener: (context, state) {
                      if (state is SuccessPostsState) {
                        _posts.addAll(state.posts);
                        setState(() {});
                        if (state.posts.length < Numbers.pageSize) {
                          context.read<MainPageBloc>().isLastPage = true;
                        } else {
                          _postNumberPage++;
                        }
                      }
                    },
                    builder: (context, state) {
                      if (state is LoadingState) {
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
