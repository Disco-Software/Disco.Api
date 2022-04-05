import 'package:disco_app/data/network/api/auth_api.dart';
import 'package:disco_app/data/network/request_models/register_request.dart';
import 'package:disco_app/pages/authentication/registration/bloc/registration_event.dart';
import 'package:disco_app/pages/authentication/registration/bloc/registration_state.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class RegistrationBloc
    extends Bloc<RegistrationPageEvent, RegistrationPageState> {
  final AuthApi authApi;

  RegistrationBloc(initialState, {required this.authApi})
      : super(initialState) {
    on<RegistrationEvent>((event, emit) => emit.forEach<RegistrationPageState>(
        _handleRegistration(event),
        onData: (state) => state));
  }

  Stream<RegistrationPageState> _handleRegistration(
      RegistrationEvent event) async* {
    yield RegistratingState();
    final response = await authApi.registration(RegisterRequestModel(
        userName: event.userName,
        email: event.email,
        password: event.password,
        confirmPassword: event.confirmPassword));
    if (response?.user != null && response?.verificationResult != null) {
      yield RegistratedState();
    } else {
      final errorText = response?.verificationResult;
      switch (errorText) {
        case "User name is requared":
          yield RegistrationErrorState(userName: "User name is requared");
          break;
        case "Email is required":
          yield RegistrationErrorState(email: errorText);
          break;
        case "Email must be a valid email address":
          RegistrationErrorState(email: errorText);
          break;
        case "Password is required":
          RegistrationErrorState(password: errorText);
          break;
        default:
          "";
          RegistrationErrorState(password: errorText);
          break;
      }
    }
  }
}
