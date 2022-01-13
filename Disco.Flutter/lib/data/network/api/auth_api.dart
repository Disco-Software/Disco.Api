import 'dart:async';

import 'package:dio/dio.dart';
import 'package:disco_app/data/network/request-models/register_request.dart';

import '../network_client.dart';
import '../network_models/user_network.dart';
import '../request-models/login_request.dart';

class AuthApi {
  Future<UserTokenResponse?> login(LogInRequestModel model) =>
      NetworkClient.instance.dio
          .post("user/authentication/log-in", data: model).then((response) {
              return UserTokenResponse.fromJson(response.data);
      });

  Future<UserTokenResponse?> registration(RegisterRequestModel model) =>
      NetworkClient.instance.dio.post("user/authentication/registration", data: model)
          .then((response) {
            print(response);
  });
}