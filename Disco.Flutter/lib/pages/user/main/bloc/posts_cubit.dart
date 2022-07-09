import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/data/network/repositories/post_repository.dart';
import 'package:disco_app/res/numbers.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:injectable/injectable.dart';

import 'posts_state.dart';

@injectable
class PostsCubit extends Cubit<PostsState> {
  PostsCubit({required this.postRepository}) : super(InitialPostsState());

  final PostRepository postRepository;

  bool isLastPage = false;

  Future<void> loadPosts(
      {required int pageNumber, Function(List<Post>)? onLoaded, bool isInitial = false}) async {
    if (isInitial) {
      isLastPage = false;
    }
    try {
      emit(LoadingPostsState());

      final posts = isLastPage
          ? <Post>[]
          : await postRepository.getAllPosts(
              pageNumber,
              Numbers.postsPageSize,
            );

      emit(SuccessPostsState(
        posts: posts ?? [],
        hasLoading: true,
      ));
      if (onLoaded != null) {
        onLoaded(posts ?? []);
      }
    } catch (err) {
      emit(ErrorPostsState());
      debugPrint('$err');
    }
  }
}
