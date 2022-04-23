abstract class StoriesEvent {}

class LoadStoriesEvent implements StoriesEvent {
  final int id;

  LoadStoriesEvent({required this.id});
}

class ErrorEvent implements StoriesEvent {}
