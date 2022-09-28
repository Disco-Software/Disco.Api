import 'package:disco_admin_panel/data/network/api/auth_api.dart';
import 'package:disco_admin_panel/data/network/models/user_token_response.dart';
import 'package:disco_admin_panel/data/network/request_models/login_request.dart';
import 'package:disco_admin_panel/data/network/request_models/reset_password_request.dart';
import 'package:disco_admin_panel/data/network/request_models/resett_password_request_model.dart';
import 'package:injectable/injectable.dart';

@injectable
class UserRepository {
  final AuthApi authApi;

  UserRepository({required this.authApi});

  Future<UserTokenResponse?> login(LogInRequestModel model) async =>
      await authApi.login(model).then((response) {
        return UserTokenResponse.fromJson(response);
      });

  // Future<UserTokenResponse?> registration(RegisterRequestModel model) async =>
  //     await authApi.registration(model).then((response) {
  //       return UserTokenResponse.fromJson(response);
  //     });

  Future<String?> forgotPassword(ForgotPasswordModel model) async =>
      await authApi.forgotPassword(model).then((response) {
        return response;
      });

  Future<UserTokenResponse?> resetPassword(ResetPasswordRequestModel model) async =>
      await authApi.resetPassword(model).then((user) {
        return user;
      });
}
