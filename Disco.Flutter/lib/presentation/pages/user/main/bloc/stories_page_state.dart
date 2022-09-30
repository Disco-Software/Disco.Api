import 'package:freezed_annotation/freezed_annotation.dart';

part 'stories_page_state.freezed.dart';

@freezed
class StoriesPageState with _$StoriesPageState {
  const factory StoriesPageState.initial() = StoriesPageStateInitial;
  const factory StoriesPageState.running({required int duration}) = StoriesPageStateRunning;
  const factory StoriesPageState.finished() = StoriesPageStateFinished;
  const factory StoriesPageState.paused() = StoriesPageStatePaused;
}
