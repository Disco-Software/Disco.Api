import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/data/network/repositories/post_repository.dart';
import 'package:disco_app/data/network/repositories/stories_repository.dart';
import 'package:disco_app/res/numbers.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'main_event.dart';
import 'main_state.dart';

class MainPageBloc extends Bloc<MainPageEvent, MainPageState> {
  final PostRepository postRepository;
  final StoriesRepository storiesRepository;
  bool isLastPage = false;

  MainPageBloc({required this.postRepository, required this.storiesRepository})
      : super(LoadingState()) {
    on<LoadPostsEvent>((event, emit) async {
      await _loadPosts(event, emit);
    });
  }

  Future<void> _loadPosts(LoadPostsEvent event, Emitter<MainPageState> emit) async {
    try {
      emit(LoadingState());
      // final userId = await getIt.get<SecureStorageRepository>().read(key: Strings.userId);

      final posts = isLastPage
          ? <Post>[]
          : await postRepository.getAllPosts(event.pageNumber, Numbers.pageSize);

      emit(SuccessPostsState(
        posts: posts ?? [],
        hasLoading: event.hasLoading,
      ));
      if (event.onLoaded != null) {
        event.onLoaded!(posts ?? []);
      }
    } catch (err) {
      emit(ErrorState());
      debugPrint('$err');
    }
  }
}
