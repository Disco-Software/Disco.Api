import 'package:disco_app/data/network/network_models/story_network.dart';

abstract class StoriesState {}

class InitialState implements StoriesState {}

class LoadingState implements StoriesState {}

class SuccessStoriesState implements StoriesState {
  List<StoriesModel> stories;
  String userImageUrl;

  SuccessStoriesState({
    required this.stories,
    required this.userImageUrl,
  });
}

class ErrorState implements StoriesState {}
