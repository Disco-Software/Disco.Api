import 'dart:async';

import 'package:dio/dio.dart';
import 'package:disco_app/data/network/network_models/refresh_token_model.dart';
import 'package:disco_app/data/network/request_models/access_token_requset_model.dart';
import 'package:disco_app/data/network/request_models/apple_login.dart';
import 'package:disco_app/data/network/request_models/google_login_request_model.dart';
import 'package:disco_app/data/network/request_models/register_request.dart';
import 'package:disco_app/data/network/request_models/reset_password_request.dart';
import 'package:disco_app/data/network/request_models/resett_password_request_model.dart';
import 'package:injectable/injectable.dart';

import '../network_models/user_network.dart';
import '../request_models/login_request.dart';

@injectable
class AuthApi {
  final Dio client;

  AuthApi({required this.client});

  Future<dynamic> login(LogInRequestModel model) =>
      client.post("user/account/log-in", data: model).then((response) {
        return response.data;
      });

  Future<dynamic> getUserDetails() =>
      client.get("user/account/details/user").then((response) {
        return response.data;
      });

  Future<dynamic> getUserById(int id) =>
      client.get("user/account/details/user/$id").then((response) {
        return response.data;
      });

  Future<dynamic> registration(RegisterRequestModel model) =>
      client.post("user/account/registration", data: model).then((response) {
        return response.data;
      });

  Future<UserTokenResponse?> refreshToken(RefreshTokenModel model) =>
      client.put("user/account/refresh", data: model).then((response) {
        return UserTokenResponse.fromJson(response.data);
      });

  Future<UserTokenResponse?> facebook(AccessTokenRequestModel model) =>
      client.post("user/account/log-in/facebook", data: model).then((response) {
        return UserTokenResponse.fromJson(response.data);
      });

  Future<UserTokenResponse?> apple(AppleLogInRequestModel model) =>
      client.post("user/account/log-in/apple", data: model).then((response) {
        return response.data;
      });

  Future<UserTokenResponse?> googleLogin(GoogleLogInRequestModel model) =>
      client.post("user/account/log-in/google", data: model).then((response) {
        return UserTokenResponse.fromJson(response.data);
      });

  Future<String?> forgotPassword(ForgotPasswordModel model) =>
      client.post('user/account/forgot-password', data: model).then((response) {
        return response.data;
      });

  Future<UserTokenResponse?> resetPassword(ResetPasswordRequestModel model) =>
      client
          .put("user/account/reset-password", data: model.toJson())
          .then((response) {
        return response.data;
      });
}
