import 'package:disco_app/data/network/network_models/post_network.dart';

abstract class MainPageState {}

class InitialState implements MainPageState {}

class LoadingState implements MainPageState {}

class SuccessPostsState implements MainPageState {
  List<Post> posts;
  final bool hasLoading;

  SuccessPostsState({
    required this.posts,
    required this.hasLoading,
  });
}

class ErrorState implements MainPageState {}
