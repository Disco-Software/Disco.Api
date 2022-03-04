import 'dart:async';

import 'package:disco_app/data/network/request_models/access_token_requset_model.dart';
import 'package:disco_app/data/network/request_models/register_request.dart';
import 'package:disco_app/data/network/request_models/reset_password_request.dart';

import '../network_client.dart';
import '../network_models/user_network.dart';
import '../request_models/login_request.dart';

class AuthApi {
  Future<UserTokenResponse?> login(LogInRequestModel model) =>
      NetworkClient.instance.dio
          .post("user/authentication/log-in", data: model)
          .then((response) {
        return UserTokenResponse.fromJson(response.data);
      });

  Future<UserTokenResponse?> registration(RegisterRequestModel model) =>
      NetworkClient.instance.dio
          .post("user/authentication/registration", data: model)
          .then((response) {
        return UserTokenResponse.fromJson(response.data);
      });

  Future<UserTokenResponse?> facebook(AccessTokenRequestModel model) =>
      NetworkClient.instance.dio
          .post("user/authentication/log-in/facebook", data: model)
          .then((response) {
        return UserTokenResponse.fromJson(response.data);
      });

  Future<String?> forgotPassword(ForgotPasswordModel model) =>
      NetworkClient.instance.dio
          .post<String?>('user/authentication/forgot-password', data: model)
          .then((response) {
        return response.data;
      });
}
