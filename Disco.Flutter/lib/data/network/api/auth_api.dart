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
      client.post("user/authentication/log-in", data: model).then((response) {
        return response.data;
      });

  Future<dynamic> registration(RegisterRequestModel model) => client
          .post("user/authentication/registration", data: model)
          .then((response) {
        return response.data;
      });

  Future<UserTokenResponse?> refreshToken(RefreshTokenModel model) =>
      client.put("user/authentication/refresh", data: model).then((response) {
        return UserTokenResponse.fromJson(response.data);
      });

  Future<UserTokenResponse?> facebook(AccessTokenRequestModel model) => client
          .post("user/authentication/log-in/facebook", data: model)
          .then((response) {
        return UserTokenResponse.fromJson(response.data);
      });

  Future<UserTokenResponse?> apple(AppleLogInRequestModel model) => client
          .post("user/authentication/log-in/apple", data: model)
          .then((response) {
        return response.data;
      });

  Future<UserTokenResponse?> googleLogin(GoogleLogInRequestModel model) {
    print("lol 0");

    client
        .post("user/authentication/log-in/google", data: model)
        .then((response) {
      print("lol 1");
      return UserTokenResponse.fromJson(response.data);
    }).catchError((onError) {
      print(onError);
    });

    throw new Exception();
  }

  Future<String?> forgotPassword(ForgotPasswordModel model) => client
          .post('user/authentication/forgot-password', data: model)
          .then((response) {
        return response.data;
      });

  Future<UserTokenResponse?> resetPassword(ResetPasswordRequestModel model) =>
      client
          .put("user/authentication/reset-password", data: model.toJson())
          .then((response) {
        return response.data;
      });
}
