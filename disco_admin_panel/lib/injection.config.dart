// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// InjectableConfigGenerator
// **************************************************************************

// ignore_for_file: no_leading_underscores_for_library_prefixes
import 'package:dio/dio.dart' as _i5;
import 'package:flutter_secure_storage/flutter_secure_storage.dart' as _i3;
import 'package:get_it/get_it.dart' as _i1;
import 'package:injectable/injectable.dart' as _i2;

import 'data/local/secure_storage.dart' as _i4;
import 'data/network/api/auth_api.dart' as _i6;
import 'data/network/repositories/user_repository.dart' as _i7;
import 'presentation/pages/authentication/login/bloc/login_bloc.dart' as _i8;
import 'register_module.dart' as _i9; // ignore_for_file: unnecessary_lambdas

// ignore_for_file: lines_longer_than_80_chars
/// initializes the registration of provided dependencies inside of [GetIt]
_i1.GetIt $initGetIt(_i1.GetIt get,
    {String? environment, _i2.EnvironmentFilter? environmentFilter}) {
  final gh = _i2.GetItHelper(get, environment, environmentFilter);
  final registerModule = _$RegisterModule();
  gh.lazySingleton<_i3.FlutterSecureStorage>(
      () => registerModule.flutterSecureStorage());
  gh.factory<_i4.SecureStorageRepository>(() => _i4.SecureStorageRepository(
      secureStorage: get<_i3.FlutterSecureStorage>()));
  gh.factory<String>(() => registerModule.baseUrl, instanceName: 'BaseUrl');
  gh.lazySingleton<_i5.Dio>(
      () => registerModule.dio(get<String>(instanceName: 'BaseUrl')));
  gh.factory<_i6.AuthApi>(() => _i6.AuthApi(client: get<_i5.Dio>()));
  gh.factory<_i7.UserRepository>(
      () => _i7.UserRepository(authApi: get<_i6.AuthApi>()));
  gh.factory<_i8.LoginBloc>(() => _i8.LoginBloc(
      userRepository: get<_i7.UserRepository>(),
      secureStorageRepository: get<_i4.SecureStorageRepository>(),
      dio: get<_i5.Dio>()));
  return get;
}

class _$RegisterModule extends _i9.RegisterModule {}
