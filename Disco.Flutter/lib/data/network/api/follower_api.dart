import 'dart:async';

import 'package:dio/dio.dart';
import 'package:disco_app/data/network/network_models/refresh_token_model.dart';
import 'package:disco_app/data/network/request_models/access_token_requset_model.dart';
import 'package:disco_app/data/network/request_models/apple_login.dart';
import 'package:disco_app/data/network/request_models/create_follower_dto.dart';
import 'package:disco_app/data/network/request_models/google_login_request_model.dart';
import 'package:disco_app/data/network/request_models/register_request.dart';
import 'package:disco_app/data/network/request_models/reset_password_request.dart';
import 'package:disco_app/data/network/request_models/resett_password_request_model.dart';
import 'package:injectable/injectable.dart';

import '../network_models/user_network.dart';
import '../request_models/login_request.dart';

@injectable
class FollowerApi {
  final Dio client;

  FollowerApi({required this.client});

  Future<dynamic> createFollower(CreateFollowerDto dto) async {
    client.post("user/followers/create", data: dto).then((response) {
      return response.data;
    });
  }

  Future<dynamic> removeFollower(int userId) async {
    client.delete("user/followers/$userId").then((response) {
      return response.data;
    });
  }
}
