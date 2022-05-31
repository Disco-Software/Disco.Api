import 'dart:async';

import 'package:dio/dio.dart';
import 'package:disco_app/data/local/local_storage.dart';
import 'package:disco_app/data/network/repositories/user_repository.dart';
import 'package:disco_app/data/network/request_models/login_request.dart';
import 'package:disco_app/res/strings.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:injectable/injectable.dart';

import 'login_event.dart';
import 'login_state.dart';

@injectable
class LoginBloc extends Bloc<LoginPageEvent, LoginPageState> {
  UserRepository userRepository;
  SecureStorageRepository secureStorageRepository;
  Dio dio;

  LoginBloc({
    required this.userRepository,
    required this.secureStorageRepository,
    required this.dio,
  }) : super(InitLoginState()) {
    on<LoginEvent>((event, emit) =>
        emit.forEach<LoginPageState>(_handleLogin(event), onData: (state) => state));
  }

  Stream<LoginPageState> _handleLogin(LoginEvent event) async* {
    try {
      yield LoginingState();
      final authResult = await userRepository.login(LogInRequestModel(
        email: event.email,
        password: event.password,
      ));
      if (authResult?.user != null && authResult?.accesToken != null) {
        yield LoggedInState(userTokenResponse: authResult);
        secureStorageRepository.write(key: Strings.token, value: authResult?.accesToken ?? '');
        secureStorageRepository.write(
          key: Strings.refreshToken,
          value: authResult?.refreshToken ?? '',
        );
        secureStorageRepository.write(
            key: Strings.userPhoto, value: authResult?.user?.profile?.photo ?? '');
        secureStorageRepository.write(key: Strings.userId, value: '${authResult?.user?.id}');
        dio.options.headers.addAll({'Authorization': 'Bearer: ${authResult?.accesToken}'});
      } else {
        final errorText = authResult?.accesToken;
        if (errorText?.contains("Password is not valid") ?? false) {
          yield LogInErrorState(passwordError: errorText);
        } else if (errorText?.contains("user not found") ?? false) {
          yield LogInErrorState(emailError: errorText);
        }
      }
    } catch (err) {
      yield LogInErrorState(emailError: 'Invalid email or password!');
    }
  }
}
