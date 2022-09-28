import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/data/network/repositories/post_repository.dart';
import 'package:disco_app/presentation/pages/search/bloc/search_page_state.dart';
import 'package:disco_app/res/numbers.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:injectable/injectable.dart';

import 'search_page_state.dart';

@injectable
class SearchCubit extends Cubit<SearchState> {
  SearchCubit({required this.postRepository}) : super(InitialSearchState());

  final PostRepository postRepository;

  bool isLastPage = false;

  Future<void> loadPosts(
      {required int pageNumber, Function(List<Post>)? onLoaded, bool isInitial = false}) async {
    if (isInitial) {
      isLastPage = false;
    }
    try {
      emit(LoadingSearchState());

      final posts = isLastPage
          ? <Post>[]
          : await postRepository.getAllPosts(
              pageNumber,
              Numbers.postsPageSize,
            );

      // emit(SuccessSearchState(
      //   posts: posts ?? [],
      //   hasLoading: true,
      // ));
      if (onLoaded != null) {
        onLoaded(posts ?? []);
      }
    } catch (err) {
      emit(ErrorSearchState());
      debugPrint('$err');
    }
  }
}
