// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// InjectableConfigGenerator
// **************************************************************************

import 'package:dio/dio.dart' as _i6;
import 'package:flutter_secure_storage/flutter_secure_storage.dart' as _i4;
import 'package:get_it/get_it.dart' as _i1;
import 'package:injectable/injectable.dart' as _i2;
import 'package:just_audio/just_audio.dart' as _i3;

import 'data/local/local_storage.dart' as _i5;
import 'data/network/api/auth_api.dart' as _i11;
import 'data/network/api/post_api.dart' as _i7;
import 'data/network/api/stories_api.dart' as _i9;
import 'data/network/network_client.dart' as _i12;
import 'data/network/repositories/post_repository.dart' as _i8;
import 'data/network/repositories/stories_repository.dart' as _i10;
import 'data/network/repositories/user_repository.dart' as _i13;
import 'pages/authentication/login/bloc/login_bloc.dart' as _i14;
import 'register_module.dart' as _i15; // ignore_for_file: unnecessary_lambdas

// ignore_for_file: lines_longer_than_80_chars
/// initializes the registration of provided dependencies inside of [GetIt]
_i1.GetIt $initGetIt(_i1.GetIt get,
    {String? environment, _i2.EnvironmentFilter? environmentFilter}) {
  final gh = _i2.GetItHelper(get, environment, environmentFilter);
  final registerModule = _$RegisterModule();
  gh.lazySingleton<_i3.AudioPlayer>(() => registerModule.audioPlayer());
  gh.lazySingleton<_i4.FlutterSecureStorage>(
      () => registerModule.flutterSecureStorage());
  gh.factory<_i5.SecureStorageRepository>(() => _i5.SecureStorageRepository(
      secureStorage: get<_i4.FlutterSecureStorage>()));
  gh.factory<String>(() => registerModule.baseUrl, instanceName: 'BaseUrl');
  gh.lazySingleton<_i6.Dio>(
      () => registerModule.dio(get<String>(instanceName: 'BaseUrl')));
  gh.factory<_i7.PostApi>(() => _i7.PostApi(dio: get<_i6.Dio>()));
  gh.factory<_i8.PostRepository>(
      () => _i8.PostRepository(postApi: get<_i7.PostApi>()));
  gh.factory<_i9.StoriesApi>(() => _i9.StoriesApi(dio: get<_i6.Dio>()));
  gh.factory<_i10.StoriesRepository>(
      () => _i10.StoriesRepository(storiesApi: get<_i9.StoriesApi>()));
  gh.factory<_i11.AuthApi>(() => _i11.AuthApi(client: get<_i6.Dio>()));
  gh.factory<_i12.NetworkClient>(() => _i12.NetworkClient(
      dio: get<_i6.Dio>(),
      authApi: get<_i11.AuthApi>(),
      storage: get<_i4.FlutterSecureStorage>()));
  gh.factory<_i13.UserRepository>(
      () => _i13.UserRepository(authApi: get<_i11.AuthApi>()));
  gh.factory<_i14.LoginBloc>(() => _i14.LoginBloc(
      userRepository: get<_i13.UserRepository>(),
      secureStorageRepository: get<_i5.SecureStorageRepository>(),
      dio: get<_i6.Dio>()));
  return get;
}

class _$RegisterModule extends _i15.RegisterModule {}
