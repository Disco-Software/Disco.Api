import 'dart:async';

import 'package:dio/dio.dart';
import 'package:disco_app/data/network/request_models/access_token_requset_model.dart';
import 'package:disco_app/data/network/request_models/apple_login.dart';
import 'package:disco_app/data/network/request_models/register_request.dart';
import 'package:disco_app/data/network/request_models/reset_password_request.dart';
import 'package:disco_app/data/network/request_models/resett_password_request_model.dart';
import 'package:injectable/injectable.dart';

import '../network_models/user_network.dart';
import '../request_models/login_request.dart';

@injectable
class AuthApi {
  final Dio _dio;
  AuthApi({required Dio dio}) : _dio = dio;

  Future<UserTokenResponse?> login(LogInRequestModel model) =>
      _dio.post("user/authentication/log-in", data: model).then((response) {
        return UserTokenResponse.fromJson(response.data);
      });

  Future<UserTokenResponse?> registration(RegisterRequestModel model) => _dio
          .post("user/authentication/registration", data: model)
          .then((response) {
        return UserTokenResponse.fromJson(response.data);
      });

  Future<UserTokenResponse?> refreshToken() => _dio
          .put<UserTokenResponse>("user/authentication/refresh")
          .then((response) {
        return response.data;
      });

  Future<UserTokenResponse?> facebook(AccessTokenRequestModel model) => _dio
          .post("user/authentication/log-in/facebook", data: model)
          .then((response) {
        return UserTokenResponse.fromJson(response.data);
      });

  Future<UserTokenResponse?> apple(AppleLogInRequestModel model) => _dio
          .post<UserTokenResponse>("user/authentication/log-in/apple",
              data: model)
          .then((response) {
        return response.data;
      });

  Future<String?> forgotPassword(ForgotPasswordModel model) => _dio
          .post<String?>('user/authentication/forgot-password', data: model)
          .then((response) {
        return response.data;
      });

  Future<UserTokenResponse?> resetPassword(ResetPasswordRequestModel model) =>
      _dio
          .put<UserTokenResponse>("user/authentication/reset-password",
              data: model)
          .then((response) {
        return response.data;
      });
}
