import 'package:disco_app/data/local/local_storage.dart';
import 'package:disco_app/data/network/repositories/post_repository.dart';
import 'package:disco_app/data/network/repositories/stories_repository.dart';
import 'package:disco_app/pages/user/main/bloc/stories_event.dart';
import 'package:disco_app/pages/user/main/bloc/stories_state.dart';
import 'package:disco_app/res/strings.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../../injection.dart';

class StoriesBloc extends Bloc<StoriesEvent, StoriesState> {
  final PostRepository postRepository;
  final StoriesRepository storiesRepository;

  StoriesBloc({required this.postRepository, required this.storiesRepository})
      : super(LoadingState()) {
    on<LoadStoriesEvent>((event, emit) async {
      await _loadStories(event, emit);
    });
  }

  Future<void> _loadStories(StoriesEvent event, Emitter<StoriesState> emit) async {
    try {
      final userId = await getIt.get<SecureStorageRepository>().read(key: Strings.userId);
      final stories = await storiesRepository.fetchStories(int.parse(userId));
      final userImageUrl = await getIt.get<SecureStorageRepository>().read(key: Strings.userPhoto);
      emit(SuccessStoriesState(
        stories: stories ?? [],
        userImageUrl: userImageUrl,
      ));
    } catch (err) {
      emit(ErrorState());
      debugPrint('$err');
    }
  }
}
