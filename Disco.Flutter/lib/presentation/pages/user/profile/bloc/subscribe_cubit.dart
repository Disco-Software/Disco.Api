import 'dart:developer' as developer;

import 'package:disco_app/data/network/network_models/like.dart';
import 'package:disco_app/data/network/network_models/user_network.dart';
import 'package:disco_app/data/network/repositories/follower_repository.dart';
import 'package:disco_app/data/network/repositories/user_repository.dart';
import 'package:disco_app/data/network/request_models/create_follower_dto.dart';
import 'package:disco_app/presentation/pages/user/profile/bloc/subscribe_state.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:injectable/injectable.dart';

import 'profile_state.dart';

@injectable
class SubscribeCubit extends Cubit<SubscribeState> {
  SubscribeCubit({required this.userRepository, required this.followerRepository})
      : super(const SubscribeState.loading());

  final UserRepository userRepository;
  final FollowerRepository followerRepository;

  Future<void> init(User user) async {
    final currentUser = await userRepository.getUserDetails();
    final followersUsers = user.account?.followers?.map((e) => e.followerAccount?.userId) ?? [];
    if (followersUsers.contains(currentUser?.id)) {
      emit(const SubscribeState.subscribed());
    } else {
      emit(const SubscribeState.unsubscribed());
    }
  }

  Future<void> subscribe(int userId, [String? installationId]) async {
    emit(const SubscribeState.loading());
    followerRepository.createFollower(
        CreateFollowerDto(followerAccountId: userId.toString(), installationId: installationId));
    emit(const SubscribeState.subscribed());
  }

  Future<void> unsubscribe(int userId) async {
    emit(const SubscribeState.loading());
    followerRepository.removeFollower(userId);
    emit(const SubscribeState.unsubscribed());
  }
}
