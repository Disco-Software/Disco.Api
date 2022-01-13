import 'dart:async';

import 'package:disco_app/data/network/api/auth_api.dart';
import 'package:disco_app/data/network/request-models/login_request.dart';
import 'package:disco_app/pages/start/login/bloc/login_event.dart';
import 'package:disco_app/pages/start/login/bloc/login_state.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class LoginBloc extends Bloc<LoginPageEvent,LoginPageState>{
  LoginBloc(initialState) : super(initialState){
    on<LoginEvent>((event, emit) =>
      emit.forEach<LoginPageState>(_handleLogin(event), onData: (state) => state)
    );
  }

  final _authApi = AuthApi();

  Stream<LoginPageState> _handleLogin(LoginEvent event) async* {
    yield LoginingState();
    final authResult = await _authApi.login(LogInRequestModel(email: event.email, password: event.password));
    if(authResult?.user != null && authResult?.verificationResult != null) {
      yield LoggedInState();
    }
    else
      {
        final errorText = authResult?.verificationResult;
        if (errorText?.contains("Password is not valid") ?? false) {
          yield LogInErrorState(passwordError:errorText);
        }
        else if (errorText?.contains("user not found") ?? false){
          yield LogInErrorState(emailError: errorText);
        }
      }
  }
}