import 'package:disco_app/data/network/network_models/user_network.dart';

abstract class LoginPageState {}

class LoggedInState extends LoginPageState {
  final UserTokenResponse? userTokenResponse;

  LoggedInState({this.userTokenResponse});
}

class InitLoginState extends LoginPageState {}

class LogInErrorState extends LoginPageState {
  final String? emailError;
  final String? passwordError;

  LogInErrorState({this.emailError, this.passwordError});
}

class LoginingState extends LoginPageState {}
