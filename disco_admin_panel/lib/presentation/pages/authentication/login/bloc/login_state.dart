import 'package:disco_admin_panel/data/network/models/user_token_response.dart';

abstract class LoginState {}

class LoggedInState extends LoginState {
  final UserTokenResponse? userTokenResponse;

  LoggedInState({this.userTokenResponse});
}

class InitLoginState extends LoginState {}

class LogInErrorState extends LoginState {
  final String? emailError;
  final String? passwordError;

  LogInErrorState({this.emailError, this.passwordError});
}

class LoginingState extends LoginState {}
