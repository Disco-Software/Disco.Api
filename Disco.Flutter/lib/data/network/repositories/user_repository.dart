import 'dart:developer';

import 'package:disco_app/data/network/api/auth_api.dart';
import 'package:disco_app/data/network/network_models/user_network.dart';
import 'package:disco_app/data/network/request_models/access_token_requset_model.dart';
import 'package:disco_app/data/network/request_models/apple_login.dart';
import 'package:disco_app/data/network/request_models/login_request.dart';
import 'package:disco_app/data/network/request_models/register_request.dart';
import 'package:disco_app/data/network/request_models/reset_password_request.dart';
import 'package:disco_app/data/network/request_models/resett_password_request_model.dart';
import 'package:injectable/injectable.dart';

@injectable
class UserRepository {
  final AuthApi authApi;

  UserRepository({required this.authApi});

  Future<UserTokenResponse?> login(LogInRequestModel model) async =>
      await authApi.login(model).then((response) {
        return UserTokenResponse.fromJson(response);
      });

  Future<User?> getUserDetails() async => await authApi.getUserDetails().then((response) {
        return User.fromJson(response);
      });

  Future<User?> getUserById(int id) async {
    try {
      final user = await authApi.getUserById(id).then((response) {
        return User.fromJson(response['user']);
      });
      return user;
    } catch (err) {
      log('$err', name: 'getUserById Error');
    }
  }

  Future<UserTokenResponse?> registration(RegisterRequestModel model) async =>
      await authApi.registration(model).then((response) {
        return UserTokenResponse.fromJson(response);
      });

  Future<UserTokenResponse?> facebook(AccessTokenRequestModel model) async =>
      await authApi.facebook(model).then((user) {
        return user;
      });

  Future<UserTokenResponse?> apple(AppleLogInRequestModel model) async =>
      await authApi.apple(model).then((user) {
        return user;
      });

  Future<String?> forgotPassword(ForgotPasswordModel model) async =>
      await authApi.forgotPassword(model).then((response) {
        return response;
      });

  Future<UserTokenResponse?> resetPassword(ResetPasswordRequestModel model) async =>
      await authApi.resetPassword(model).then((user) {
        return user;
      });
}
