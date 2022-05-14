abstract class StoriesEvent {}

class LoadStoriesEvent implements StoriesEvent {
  LoadStoriesEvent();
}

class ErrorEvent implements StoriesEvent {}
