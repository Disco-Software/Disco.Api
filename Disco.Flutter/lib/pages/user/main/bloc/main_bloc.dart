import 'package:disco_app/data/network/api/post_api.dart';
import 'package:disco_app/data/network/api/stories_api.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'main_event.dart';
import 'main_state.dart';

class MainPageBloc extends Bloc<MainPageEvent, MainPageState> {
  MainPageBloc() : super(LoadingState()) {
    print(123);
    on<InitialEvent>((event, emit) {
      _loadData(event, emit);
    });
  }

  final _storiesApi = StoriesApi();
  final _postApi = PostApi();

  void _loadData(MainPageEvent event, Emitter<MainPageState> emit) async {
    print("test");
    emit(LoadingState());
    if (event is InitialEvent) {
      try {
        final stories = await _storiesApi.fetchStories(event.id);
        final posts = await _postApi.GetAllPosts(event.id);
        emit(SuccessState(stories: stories ?? [], posts: posts ?? []));
      } on Exception {
        emit(ErrorState());
      }
    }
  }
}
