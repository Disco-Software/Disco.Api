import 'dart:async';

import 'package:dio/dio.dart';
import 'package:disco_admin_panel/data/network/models/user_token_response.dart';
import 'package:disco_admin_panel/data/network/request_models/refresh_token_model.dart';
import 'package:disco_admin_panel/data/network/request_models/reset_password_request.dart';
import 'package:disco_admin_panel/data/network/request_models/resett_password_request_model.dart';
import 'package:injectable/injectable.dart';

import '../request_models/login_request.dart';

@injectable
class AuthApi {
  final Dio client;

  AuthApi({required this.client});

  Future<dynamic> login(LogInRequestModel model) =>
      client.post("admin/authentication/log-in", data: model).then((response) {
        return response.data;
      });

  // Future<dynamic> registration(RegisterRequestModel model) =>
  //     client.post("user/authentication/registration", data: model).then((response) {
  //       return response.data;
  //     });

  Future<UserTokenResponse?> refreshToken(RefreshTokenModel model) =>
      client.put("admin/authentication/refresh", data: model).then((response) {
        return UserTokenResponse.fromJson(response.data);
      });

  Future<String?> forgotPassword(ForgotPasswordModel model) =>
      client.post('admin/authentication/forgot-password', data: model).then((response) {
        return response.data;
      });

  Future<UserTokenResponse?> resetPassword(ResetPasswordRequestModel model) =>
      client.put("admin/authentication/reset-password", data: model.toJson()).then((response) {
        return response.data;
      });
}
