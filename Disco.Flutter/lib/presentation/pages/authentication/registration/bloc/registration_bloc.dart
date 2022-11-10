import 'package:dio/dio.dart';
import 'package:disco_app/app/extensions/secure_storage_extensions.dart';
import 'package:disco_app/data/local/local_storage.dart';
import 'package:disco_app/data/network/repositories/user_repository.dart';
import 'package:disco_app/data/network/request_models/register_request.dart';
import 'package:disco_app/domain/stored_user_model.dart';
import 'package:disco_app/presentation/pages/authentication/registration/bloc/registration_event.dart';
import 'package:disco_app/presentation/pages/authentication/registration/bloc/registration_state.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:injectable/injectable.dart';

@injectable
class RegistrationBloc extends Bloc<RegistrationPageEvent, RegistrationPageState> {
  UserRepository userRepository;
  SecureStorageRepository secureStorageRepository;
  Dio dio;

  RegistrationBloc({
    required this.userRepository,
    required this.secureStorageRepository,
    required this.dio,
  }) : super(InitialState()) {
    on<RegistrationEvent>((event, emit) =>
        emit.forEach<RegistrationPageState>(_handleRegistration(event), onData: (state) => state));
  }

  Stream<RegistrationPageState> _handleRegistration(RegistrationEvent event) async* {
    yield RegistratingState();
    final response = await userRepository.registration(RegisterRequestModel(
        userName: event.userName,
        email: event.email,
        password: event.password,
        confirmPassword: event.confirmPassword));
    if (response?.user != null && response?.accesToken != null) {
      yield RegistratedState();
      secureStorageRepository.saveUserModel(
        storedUserModel: StoredUserModel(
          refreshToken: response?.refreshToken,
          token: response?.accesToken,
          userId: '${response?.user?.id}',
          userName: response?.user?.userName,
          userPhoto: response?.user?.account?.photo,
          moto: response?.user?.account?.creed,
          currentFollowers: response?.user?.account?.status?.followersCount,
          userTarget: response?.user?.account?.status?.userTarget,
          lastStatus: response?.user?.account?.status?.lastStatus,
        ),
      );
      dio.options.headers.addAll({'Authorization': 'Bearer: ${response?.accesToken}'});
    } else {
      final errorText = response?.accesToken;
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
