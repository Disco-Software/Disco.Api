import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/data/network/network_models/story_network.dart';

abstract class MainPageState {}

class InitialState implements MainPageState {}

class LoadingState implements MainPageState {}

class SuccessState implements MainPageState {
  List<StoriesModel> stories;
  List<Post> posts;
  String userImageUrl;

  SuccessState(
      {required this.stories, required this.posts, required this.userImageUrl});
}

class ErrorState implements MainPageState {}