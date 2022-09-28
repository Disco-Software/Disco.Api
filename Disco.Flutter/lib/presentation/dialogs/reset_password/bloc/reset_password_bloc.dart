import 'package:disco_app/data/network/api/auth_api.dart';
import 'package:disco_app/dialogs/reset_password/bloc/reset_password_event.dart';
import 'package:disco_app/dialogs/reset_password/bloc/reset_password_state.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class ResetPasswordBloc
    extends Bloc<ResetPasswordEvent, ResetPasswordPageState>{
  final AuthApi authApi;

  ResetPasswordBloc(initialState, {required this.authApi})
      : super(initialState){
    on<ResetPasswordEvent>((event, emit) =>
        emit.forEach<ResetPasswordPageState>(_handleForgotPassword(event),
            onData: (state) => state));

  }

  _handleForgotPassword(event) {}
}