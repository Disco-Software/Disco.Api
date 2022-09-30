import 'package:disco_app/data/network/network_models/post_network.dart';

abstract class PostsState {}

class InitialPostsState implements PostsState {}

class LoadingPostsState implements PostsState {}

class SuccessPostsState implements PostsState {
  List<Post> posts;
  final bool hasLoading;

  SuccessPostsState({
    required this.posts,
    required this.hasLoading,
  });
}

class ErrorPostsState implements PostsState {}
