import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/data/network/network_models/user_network.dart';
import 'package:freezed_annotation/freezed_annotation.dart';

part 'profile_state.freezed.dart';

@freezed
class ProfileState with _$ProfileState {
  const factory ProfileState.initial() = ProfileStateInitial;

  const factory ProfileState.loading() = ProfileStateLoading;

  const factory ProfileState.loaded({required User user}) = ProfileStateLoaded;

  const factory ProfileState.saved(
      {required User user, required List<Post> savedPosts}) = ProfileStateSaved;

  const factory ProfileState.error() = ProfileStateError;
}
