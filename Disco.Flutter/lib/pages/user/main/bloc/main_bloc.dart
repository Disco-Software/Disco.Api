import 'package:disco_app/data/local/local_storage.dart';
import 'package:disco_app/data/network/repositories/post_repository.dart';
import 'package:disco_app/data/network/repositories/stories_repository.dart';
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
    on<InitialEvent>((event, emit) async {
      await _loadData(event, emit);
    });
  }

  Future<void> _loadData(
      MainPageEvent event, Emitter<MainPageState> emit) async {
    emit(LoadingState());
    try {
      final stories =
          await storiesRepository.fetchStories((event as InitialEvent).id);
      final posts = await postRepository.getAllPosts(event.id);
      final userImageUrl =
          await getIt.get<SecureStorageRepository>().read(key: 'userImageUrl');
      print("user image $userImageUrl");
      emit(SuccessState(
          userImageUrl: userImageUrl,
          stories: stories ?? [],
          posts: posts ?? []));
    } catch (err) {
      debugPrint('$err');
      emit(ErrorState());
    }
  }
}
