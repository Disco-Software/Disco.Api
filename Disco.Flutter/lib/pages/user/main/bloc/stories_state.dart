import 'package:disco_app/data/network/network_models/story_network.dart';

abstract class StoriesState {}

class InitialStoriesState implements StoriesState {}

class LoadingStoriesState implements StoriesState {}

class SuccessStoriesState implements StoriesState {
  List<StoriesModel> stories;
  String userImageUrl;

  SuccessStoriesState({
    required this.stories,
    required this.userImageUrl,
  });
}

class ErrorStoriesState implements StoriesState {}
