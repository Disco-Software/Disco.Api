import 'package:disco_app/data/network/api/auth_api.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'reset_password_event.dart';
import 'reset_password_state.dart';

class ResetPasswordBloc extends Bloc<ResetPasswordEvent, ResetPasswordPageState> {
  final AuthApi authApi;

  ResetPasswordBloc(initialState, {required this.authApi}) : super(initialState) {
    on<ResetPasswordEvent>((event, emit) => emit
        .forEach<ResetPasswordPageState>(_handleForgotPassword(event), onData: (state) => state));
  }

  _handleForgotPassword(event) {}
}
