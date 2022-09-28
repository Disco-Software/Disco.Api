import 'package:disco_app/data/local/local_storage.dart';
import 'package:disco_app/data/network/network_models/story_network.dart';
import 'package:disco_app/data/network/repositories/stories_repository.dart';
import 'package:disco_app/presentation/pages/user/main/bloc/stories_state.dart';
import 'package:disco_app/res/numbers.dart';
import 'package:disco_app/res/strings.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../../../injection.dart';

class StoriesCubit extends Cubit<StoriesState> {
  final StoriesRepository storiesRepository;

  StoriesCubit({required this.storiesRepository}) : super(InitialStoriesState());
  bool isLastPage = false;
  List<StoriesModel> stories = [];
  int pageNumber = 0;

  Future<void> loadStories({bool isInitial = false}) async {
    if (isInitial) {
      isLastPage = false;
      stories = [];
      pageNumber = 1;
    }
    try {
      emit(LoadingStoriesState());
      final _stories = isLastPage
          ? <StoriesModel>[]
          : await storiesRepository.fetchStories(pageNumber, Numbers.storiesPageSize);
      final userImageUrl = await getIt.get<SecureStorageRepository>().read(key: Strings.userPhoto);
      stories.addAll(_stories ?? []);

      if (_stories != null && _stories.length < Numbers.storiesPageSize) {
        isLastPage = true;
      } else {
        pageNumber++;
      }
      emit(SuccessStoriesState(
        stories: _stories ?? [],
        userImageUrl: userImageUrl,
      ));
    } catch (err) {
      emit(ErrorStoriesState());
      debugPrint('$err');
    }
  }
}
