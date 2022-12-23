import 'dart:developer' as developer;

import 'package:disco_app/data/network/network_models/like.dart';
import 'package:disco_app/data/network/network_models/user_network.dart';
import 'package:disco_app/data/network/repositories/account_details_repository.dart';
import 'package:disco_app/data/network/repositories/user_repository.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:injectable/injectable.dart';

import 'profile_state.dart';

@injectable
class ProfileCubit extends Cubit<ProfileState> {
  ProfileCubit(
      {required this.userRepository, required this.accountDetailsRepository})
      : super(const ProfileState.initial());

  final UserRepository userRepository;
  final AccountDetailsRepository accountDetailsRepository;

  Future<void> init(List<Like>? likes) async {}

  Future<void> loadMine() async {
    try {
      emit(const ProfileState.loading());
      final user = await userRepository.getUserDetails();
      if (user != null && user.id != null) {
        emit(ProfileState.loaded(user: user));
      }
    } catch (err) {
      emit(const ProfileState.error());
      developer.log('$err', name: 'Profile cubit error');
    }
  }

  Future<void> setPhoto(String photoPath) async {
    try {
      emit(const ProfileState.loading());
      final user = await accountDetailsRepository.setPhoto(photoPath);
      emit(ProfileState.loaded(user: user));
    } catch (error) {
      emit(const ProfileState.error());
      developer.log('$error', name: 'Profile cubit error');
    }
  }

  Future<void> loadUser(int id) async {
    try {
      emit(const ProfileState.loading());
      final user = await userRepository.getUserById(id);
      if (user != null && user.id != null) {
        emit(ProfileState.loaded(user: user));
      }
    } catch (err) {
      emit(const ProfileState.error());
      developer.log('$err', name: 'Profile cubit error');
    }
  }

  Future<void> loadSaved() async {
    //TODO: add when api will be provided

    try {
      emit(const ProfileState.loading());
      final user = await userRepository.getUserDetails();
      if (user != null) {
        emit(ProfileState.saved(
          user: user,
          savedPosts: [],
        ));
      }
    } catch (err) {
      emit(const ProfileState.error());
      developer.log('$err', name: 'Profile cubit error');
    }
    // try {
    //
    // } catch (err) {
    //   emit(const LikeState.error());
    //   developer.log('$err', name: 'Profile cubit error');
    // }
  }
}
