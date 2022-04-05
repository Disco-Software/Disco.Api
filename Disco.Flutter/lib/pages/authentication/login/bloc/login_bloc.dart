import 'dart:async';

import 'package:disco_app/data/network/api/auth_api.dart';
import 'package:disco_app/data/network/request_models/login_request.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'login_event.dart';
import 'login_state.dart';

class LoginBloc extends Bloc<LoginPageEvent, LoginPageState> {
  AuthApi authApi;

  LoginBloc(initialState, {required this.authApi}) : super(initialState) {
    on<LoginEvent>((event, emit) => emit.forEach<LoginPageState>(
        _handleLogin(event),
        onData: (state) => state));
  }

  Stream<LoginPageState> _handleLogin(LoginEvent event) async* {
    yield LoginingState();
    final authResult = await authApi
        .login(LogInRequestModel(email: event.email, password: event.password));
    if (authResult?.user != null && authResult?.verificationResult != null) {
      yield LoggedInState();
    } else {
      final errorText = authResult?.verificationResult;
      if (errorText?.contains("Password is not valid") ?? false) {
        yield LogInErrorState(passwordError: errorText);
      } else if (errorText?.contains("user not found") ?? false) {
        yield LogInErrorState(emailError: errorText);
      }
    }
  }
}
