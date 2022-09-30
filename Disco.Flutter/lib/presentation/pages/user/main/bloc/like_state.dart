import 'package:freezed_annotation/freezed_annotation.dart';

part 'like_state.freezed.dart';

@freezed
class LikeState with _$LikeState {
  const factory LikeState.initialSelected() = LikeStateInitialSelected;
  const factory LikeState.initialNotSelected() = LikeStateInitialNotSelected;

  const factory LikeState.notSelected({required int likes}) = LikeNotSelectedState;

  const factory LikeState.selected({required int likes}) = LikeSelectedState;

  const factory LikeState.loading() = LikeStateLoading;

  const factory LikeState.error() = LikeStateError;
}
