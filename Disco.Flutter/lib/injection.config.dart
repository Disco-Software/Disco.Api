// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// InjectableConfigGenerator
// **************************************************************************

import 'package:dio/dio.dart' as _i5;
import 'package:flutter_secure_storage/flutter_secure_storage.dart' as _i3;
import 'package:get_it/get_it.dart' as _i1;
import 'package:injectable/injectable.dart' as _i2;

import 'data/local/local_storage.dart' as _i4;
import 'data/network/api/auth_api.dart' as _i6;
import 'data/network/network_client.dart' as _i7;
import 'register_module.dart' as _i8; // ignore_for_file: unnecessary_lambdas

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
  gh.factory<_i6.AuthApi>(() => _i6.AuthApi(dio: get<_i5.Dio>()));
  gh.factory<_i7.NetworkClient>(() => _i7.NetworkClient(
      dio: get<_i5.Dio>(),
      authApi: get<_i6.AuthApi>(),
      storage: get<_i3.FlutterSecureStorage>()));
  return get;
}

class _$RegisterModule extends _i8.RegisterModule {}
