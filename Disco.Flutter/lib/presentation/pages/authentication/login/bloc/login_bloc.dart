import 'dart:async';

import 'package:dio/dio.dart';
import 'package:disco_app/app/extensions/secure_storage_extensions.dart';
import 'package:disco_app/data/local/local_storage.dart';
import 'package:disco_app/data/network/repositories/user_repository.dart';
import 'package:disco_app/data/network/request_models/login_request.dart';
import 'package:disco_app/domain/stored_user_model.dart';
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
        secureStorageRepository.saveUserModel(
          storedUserModel: StoredUserModel(
            refreshToken: authResult?.refreshToken,
            token: authResult?.accesToken,
            userId: '${authResult?.user?.id}',
            userName: authResult?.user?.userName,
            userPhoto: authResult?.user?.account?.photo,
            moto: authResult?.user?.account?.creed,
            currentFollowers: authResult?.user?.account?.status?.followersCount,
            userTarget: authResult?.user?.account?.status?.userTarget,
            lastStatus: authResult?.user?.account?.status?.lastStatus,
          ),
        );
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
