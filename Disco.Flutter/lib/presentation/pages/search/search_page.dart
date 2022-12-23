import 'dart:async';

import 'package:auto_route/auto_route.dart';
import 'package:cached_network_image/cached_network_image.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/injection.dart';
import 'package:disco_app/presentation/common_widgets/post/post.dart';
import 'package:disco_app/presentation/pages/user/main/bloc/posts_cubit.dart';
import 'package:disco_app/presentation/pages/user/main/bloc/posts_state.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_staggered_grid_view/flutter_staggered_grid_view.dart';
import 'package:flutter_svg/svg.dart';
import 'package:google_fonts/google_fonts.dart';

import 'bloc/search_page_cubit.dart';
import 'bloc/search_page_state.dart';

class SearchPage extends StatefulWidget implements AutoRouteWrapper {
  const SearchPage({Key? key}) : super(key: key);

  @override
  State<SearchPage> createState() => _SearchPageState();

  @override
  Widget wrappedRoute(context) {
    return BlocProvider<SearchItemCubit>(
      create: (context) => getIt(),
      child: this, // this as the child Important!
    );
  }
}

class _SearchPageState extends State<SearchPage> with SingleTickerProviderStateMixin {
  final _searchController = TextEditingController();
  late AnimationController _animationController;
  bool shouldShowSearchIcon = true;
  Timer? _debounce;
  final FocusNode _textFieldFocus = FocusNode();

  @override
  void initState() {
    super.initState();
    if (mounted) {
      _animationController =
          AnimationController(vsync: this, duration: const Duration(milliseconds: 1500))
            ..addListener(() {
              setState(() {});
            });
      _animationController.forward();
    }
  }

  @override
  void dispose() {
    _debounce?.cancel();
    _animationController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xFF1C142D),
      body: BlocBuilder<SearchItemCubit, SearchItemState>(
        builder: (context, state) {
          return CustomScrollView(
            slivers: [
              SliverAppBar(
                centerTitle: false,
                backgroundColor: const Color(0xFF1C142D),
                titleSpacing: _animationController.drive(Tween(begin: 0.0, end: 100.0)).value,
                leading: IconButton(
                  icon: const Icon(CupertinoIcons.chevron_back),
                  onPressed: () {
                    context.router.pop();
                  },
                ),
                title: const Text(
                  "DISCO",
                  style: TextStyle(
                    fontSize: 32,
                    fontFamily: 'Colonna',
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
              SliverToBoxAdapter(
                child: Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 50),
                  child: TextFormField(
                    focusNode: _textFieldFocus,
                    onChanged: (value) {
                      setState(() {
                        shouldShowSearchIcon = !shouldShowSearchIcon;
                      });
                      _debounce = Timer(const Duration(milliseconds: 600), () {
                        context.read<SearchItemCubit>().search(_searchController.text);
                      });
                    },
                    style: const TextStyle(color: DcColors.darkWhite, fontSize: 30),
                    controller: _searchController,
                    decoration: InputDecoration(
                      isDense: true,
                      prefixIcon: !_textFieldFocus.hasFocus
                          ? Padding(
                              padding: const EdgeInsets.all(8.0),
                              child: SvgPicture.asset(
                                'assets/ic_search.svg',
                                color: Colors.white,
                                height: 24,
                                width: 24,
                              ),
                            )
                          : null,
                    ),
                  ),
                ),
              ),
              const SliverPadding(padding: EdgeInsets.symmetric(vertical: 20.0)),
              if (_shoudlShowNothing(state))
                const SliverToBoxAdapter(
                  child: Text(
                    "Nothing found",
                    style:
                        TextStyle(fontSize: 24, fontWeight: FontWeight.bold, color: DcColors.white),
                    textAlign: TextAlign.center,
                  ),
                ),
              if (state is LoadingSearchItemState)
                SliverToBoxAdapter(child: Center(child: Image.asset('assets/music.gif')))
              else ...[
                if (state is SuccessSearchItemState &&
                    state.items.users != null &&
                    state.items.users!.isNotEmpty)
                  const SliverToBoxAdapter(
                    child: Text(
                      "Users",
                      style: TextStyle(
                          fontSize: 24, fontWeight: FontWeight.bold, color: DcColors.white),
                      textAlign: TextAlign.center,
                    ),
                  ),
                const SliverPadding(padding: EdgeInsets.symmetric(vertical: 20.0)),
                if (state is SuccessSearchItemState)
                  SliverGrid(
                    delegate: SliverChildBuilderDelegate((context, index) {
                      return Column(
                        children: [
                          Expanded(
                            child: Container(
                              decoration: BoxDecoration(
                                borderRadius: BorderRadius.circular(12),
                                boxShadow: const [
                                  BoxShadow(
                                    color: Color(0xffb2a044ff),
                                    offset: Offset(0, 4),
                                    blurRadius: 7,
                                  ),
                                ],
                              ),
                              child: InkWell(
                                onTap: () {
                                  if (state.items.users != null &&
                                      state.items.users![index].userId != null) {
                                    context.router.push(UserProfileRoute(
                                        userId: state.items.users?[index].userId ?? 0));
                                  }
                                },
                                child: ClipRRect(
                                  borderRadius: BorderRadius.circular(12),
                                  child: CachedNetworkImage(
                                    fit: BoxFit.cover,
                                    imageUrl: state.items.users?[index].photo ?? '',
                                    errorWidget: (context, string, err) => Container(
                                        color: Colors.white,
                                        child: Image.asset('assets/ic_photo.png')),
                                  ),
                                ),
                              ),
                            ),
                          ),
                          const SizedBox(
                            height: 8,
                          ),
                          Text(
                            state.items.users?[index].user?.userName ?? '',
                            style: GoogleFonts.aBeeZee(
                              fontSize: 14.0,
                              color: DcColors.white,
                            ),
                          ),
                        ],
                      );
                    }, childCount: state.items.users?.length ?? 0),
                    gridDelegate: SliverQuiltedGridDelegate(
                      crossAxisCount: 3,
                      mainAxisSpacing: 5,
                      crossAxisSpacing: 5,
                      repeatPattern: QuiltedGridRepeatPattern.inverted,
                      pattern: [
                        const QuiltedGridTile(2, 1),
                        const QuiltedGridTile(2, 2),
                        const QuiltedGridTile(1, 1),
                        const QuiltedGridTile(1, 1),
                        const QuiltedGridTile(1, 1),
                      ],
                    ),
                  ),
                if (_shouldShowPostsHeader(state))
                  const SliverToBoxAdapter(
                    child: Text(
                      "Posts",
                      style: TextStyle(
                          fontSize: 24, fontWeight: FontWeight.bold, color: DcColors.white),
                      textAlign: TextAlign.center,
                    ),
                  ),
                const SliverPadding(padding: EdgeInsets.symmetric(vertical: 20.0)),
                if (state is InitialSearchItemState)
                  BlocBuilder<PostsCubit, PostsState>(
                    builder: (context, state) {
                      return state is SuccessPostsState
                          ? SliverList(
                              delegate: SliverChildBuilderDelegate(
                                (ctx, index) {
                                  return UnicornPost(post: state.posts[index]);
                                },
                                childCount: state.posts.length,
                              ),
                            )
                          : const SliverPadding(padding: EdgeInsets.all(0));
                    },
                  ),
                if (state is SuccessSearchItemState)
                  SliverList(
                    delegate: SliverChildBuilderDelegate(
                      (ctx, index) {
                        return UnicornPost(post: state.items.posts?[index] ?? Post());
                      },
                      childCount: state.items.posts?.length ?? 0,
                    ),
                  ),
                const SliverPadding(padding: EdgeInsets.symmetric(vertical: 100.0)),
              ],
            ],
          );
        },
      ),
    );
  }

  bool _shouldShowPostsHeader(SearchItemState state) {
    return state is SuccessSearchItemState &&
            state.items.posts != null &&
            state.items.posts!.isNotEmpty ||
        state is InitialSearchItemState;
  }

  bool _shoudlShowNothing(SearchItemState state) {
    return state is SuccessSearchItemState &&
        state.items.users != null &&
        state.items.users!.isEmpty &&
        state.items.posts != null &&
        state.items.posts!.isEmpty;
  }
}
