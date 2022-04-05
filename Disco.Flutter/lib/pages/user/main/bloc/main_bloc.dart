import 'package:disco_app/data/network/repositories/post_repository.dart';
import 'package:disco_app/data/network/repositories/stories_repository.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'main_event.dart';
import 'main_state.dart';

class MainPageBloc extends Bloc<MainPageEvent, MainPageState> {
  final PostRepository postRepository;
  final StoriesRepository storiesRepository;

  MainPageBloc({required this.postRepository, required this.storiesRepository})
      : super(LoadingState()) {
    print(123);
    on<InitialEvent>((event, emit) {
      _loadData(event, emit);
    });
  }

  void _loadData(MainPageEvent event, Emitter<MainPageState> emit) async {
    print("test");
    emit(LoadingState());
    if (event is InitialEvent) {
      try {
        final stories = await storiesRepository.fetchStories(event.id);
        final posts = await postRepository.getAllPosts(event.id);
        emit(SuccessState(stories: stories ?? [], posts: posts ?? []));
      } on Exception {
        emit(ErrorState());
      }
    }
  }
}
