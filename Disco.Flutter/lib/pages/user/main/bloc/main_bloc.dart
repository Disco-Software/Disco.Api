import 'package:disco_app/data/local/local_storage.dart';
import 'package:disco_app/data/network/repositories/post_repository.dart';
import 'package:disco_app/data/network/repositories/stories_repository.dart';
import 'package:disco_app/res/strings.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../../injection.dart';
import 'main_event.dart';
import 'main_state.dart';

class MainPageBloc extends Bloc<MainPageEvent, MainPageState> {
  final PostRepository postRepository;
  final StoriesRepository storiesRepository;

  MainPageBloc({required this.postRepository, required this.storiesRepository})
      : super(LoadingState()) {
    on<LoadPostsEvent>((event, emit) async {
      await _loadPosts(event, emit);
    });
  }

  Future<void> _loadPosts(MainPageEvent event, Emitter<MainPageState> emit) async {
    try {
      if ((event as LoadPostsEvent).hasLoading) emit(LoadingState());
      final userId = await getIt.get<SecureStorageRepository>().read(key: Strings.userId);
      final posts = await postRepository.getAllPosts(int.parse(userId));
      emit(SuccessPostsState(
        posts: posts ?? [],
        hasLoading: event.hasLoading,
      ));
      event.onLoaded();
    } catch (err) {
      emit(ErrorState());
      debugPrint('$err');
    }
  }
}
