import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/data/network/network_models/story_network.dart';

abstract class MainPageEvent {}

class InitialEvent implements MainPageEvent {
  final int id;

  InitialEvent({required this.id});
}

class SuccessEvent implements MainPageEvent {
  List<StoriesModel>? stories;
  List<Post>? posts;

  SuccessEvent({this.posts, this.stories});
}

class ErrorEvent implements MainPageEvent {}
