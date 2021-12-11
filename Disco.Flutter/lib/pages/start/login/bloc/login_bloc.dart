import 'dart:async';

import 'package:disco_app/pages/start/login/bloc/login_event.dart';
import 'package:disco_app/pages/start/login/bloc/login_state.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class LoginBloc extends Bloc<LoginPageEvent,LoginPageState>{
  LoginBloc(initialState) : super(initialState){
    on<LoginEvent>(_handleLogin);
  }


  FutureOr<void> _handleLogin(LoginEvent event, Emitter<LoginPageState> emit) async {
  }
}