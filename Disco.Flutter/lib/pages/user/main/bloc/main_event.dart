import 'package:disco_app/data/network/network_models/post_network.dart';

abstract class MainPageEvent {}

class InitialEvent implements MainPageEvent {
  final int id;

  InitialEvent({required this.id});
}

class LoadPostsEvent implements MainPageEvent {
  final bool hasLoading;
  final Function(List<Post>)? onLoaded;
  final int pageNumber;

  LoadPostsEvent({
    required this.hasLoading,
    this.onLoaded,
    required this.pageNumber,
  });
}

class ErrorEvent implements MainPageEvent {}
