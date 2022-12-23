import 'dart:developer';

import 'package:dio/dio.dart';
import 'package:disco_app/data/network/api/follower_api.dart';
import 'package:disco_app/data/network/api/post_api.dart';
import 'package:disco_app/data/network/network_models/create_follower_model.dart';
import 'package:disco_app/data/network/network_models/create_post_model.dart';
import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/data/network/request_models/create_follower_dto.dart';
import 'package:injectable/injectable.dart';

@injectable
class FollowerRepository {
  final FollowerApi followerApi;

  FollowerRepository({required this.followerApi});

  Future<FollowerResponseModel> createFollower(CreateFollowerDto dto) async {
    print('$dto lol229');
    try {
      return followerApi.createFollower(dto).then((follower) {
        return FollowerResponseModel.fromJson(follower);
      });
    } catch (err) {
      log('$err', name: 'create follower error');
      return FollowerResponseModel();
    }
  }

  Future<void> removeFollower(int userId) {
    return followerApi.removeFollower(userId);
  }
}
