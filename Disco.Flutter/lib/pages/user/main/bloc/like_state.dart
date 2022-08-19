import 'package:freezed_annotation/freezed_annotation.dart';

part 'like_state.freezed.dart';

@freezed
class LikeState with _$LikeState {
  const factory LikeState.initial() = LikeStateInitial;
  const factory LikeState.success({required int likes}) = LikeStateSuccess;
  const factory LikeState.loading() = LikeStateLoading;
  const factory LikeState.error() = LikeStateError;
}
