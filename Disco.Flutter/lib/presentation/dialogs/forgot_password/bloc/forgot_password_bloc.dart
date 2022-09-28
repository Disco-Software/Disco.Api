import 'package:disco_app/data/network/api/auth_api.dart';
import 'package:disco_app/data/network/request_models/reset_password_request.dart';
import 'package:disco_app/presentation/dialogs/forgot_password/bloc/forgot_password_event.dart';
import 'package:disco_app/presentation/dialogs/forgot_password/bloc/forgot_password_state.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class ForgotPasswordBloc extends Bloc<ForgotPasswordEvent, ForgotPasswordState> {
  final AuthApi authApi;

  ForgotPasswordBloc(initialState, {required this.authApi}) : super(initialState) {
    on<ForgotPasswordOnSendingEvent>((event, emit) =>
        emit.forEach<ForgotPasswordState>(_handleForgotPassword(event), onData: (state) => state));
  }

  Stream<ForgotPasswordState> _handleForgotPassword(ForgotPasswordOnSendingEvent event) async* {
    yield ForgotPasswordEmailSendingState();
    final authResult = await authApi.forgotPassword(ForgotPasswordModel(email: event.email));
    if (authResult != null) {
      yield ForgotPasswordSendedState();
    } else {
      yield ForgotPasswordErrorState(emailError: "Email not valid");
    }
  }
}
