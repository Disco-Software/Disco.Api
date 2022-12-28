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
import 'data/network/api/account_details_api.dart' as _i16;
import 'data/network/api/auth_api.dart' as _i18;
import 'data/network/api/follower_api.dart' as _i7;
import 'data/network/api/post_api.dart' as _i9;
import 'data/network/api/search_api.dart' as _i12;
import 'data/network/api/stories_api.dart' as _i14;
import 'data/network/network_client.dart' as _i20;
import 'data/network/repositories/account_details_repository.dart' as _i17;
import 'data/network/repositories/follower_repository.dart' as _i8;
import 'data/network/repositories/post_repository.dart' as _i10;
import 'data/network/repositories/search_repository.dart' as _i13;
import 'data/network/repositories/stories_repository.dart' as _i15;
import 'data/network/repositories/user_repository.dart' as _i22;
import 'presentation/pages/authentication/login/bloc/login_bloc.dart' as _i23;
import 'presentation/pages/authentication/registration/bloc/registration_bloc.dart'
    as _i25;
import 'presentation/pages/search/bloc/search_page_cubit.dart' as _i21;
import 'presentation/pages/user/main/bloc/like_cubit.dart' as _i19;
import 'presentation/pages/user/main/bloc/posts_cubit.dart' as _i11;
import 'presentation/pages/user/profile/bloc/profile_cubit.dart' as _i24;
import 'presentation/pages/user/profile/bloc/subscribe_cubit.dart' as _i26;
import 'register_module.dart' as _i27; // ignore_for_file: unnecessary_lambdas

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
  gh.factory<_i7.FollowerApi>(() => _i7.FollowerApi(client: get<_i6.Dio>()));
  gh.factory<_i8.FollowerRepository>(
      () => _i8.FollowerRepository(followerApi: get<_i7.FollowerApi>()));
  gh.factory<_i9.PostApi>(() => _i9.PostApi(dio: get<_i6.Dio>()));
  gh.factory<_i10.PostRepository>(
      () => _i10.PostRepository(postApi: get<_i9.PostApi>()));
  gh.factory<_i11.PostsCubit>(
      () => _i11.PostsCubit(postRepository: get<_i10.PostRepository>()));
  gh.factory<_i12.SearchApi>(() => _i12.SearchApi(dio: get<_i6.Dio>()));
  gh.factory<_i13.SearchRepository>(
      () => _i13.SearchRepository(searchApi: get<_i12.SearchApi>()));
  gh.factory<_i14.StoriesApi>(() => _i14.StoriesApi(dio: get<_i6.Dio>()));
  gh.factory<_i15.StoriesRepository>(
      () => _i15.StoriesRepository(storiesApi: get<_i14.StoriesApi>()));
  gh.factory<_i16.AccountDetailsApi>(
      () => _i16.AccountDetailsApi(client: get<_i6.Dio>()));
  gh.factory<_i17.AccountDetailsRepository>(() => _i17.AccountDetailsRepository(
      accountDetailsApi: get<_i16.AccountDetailsApi>()));
  gh.factory<_i18.AuthApi>(() => _i18.AuthApi(client: get<_i6.Dio>()));
  gh.factory<_i19.LikeCubit>(
      () => _i19.LikeCubit(postRepository: get<_i10.PostRepository>()));
  gh.factory<_i20.NetworkClient>(() => _i20.NetworkClient(
      dio: get<_i6.Dio>(),
      authApi: get<_i18.AuthApi>(),
      storage: get<_i4.FlutterSecureStorage>()));
  gh.factory<_i21.SearchItemCubit>(() =>
      _i21.SearchItemCubit(searchRepository: get<_i13.SearchRepository>()));
  gh.factory<_i22.UserRepository>(
      () => _i22.UserRepository(authApi: get<_i18.AuthApi>()));
  gh.factory<_i23.LoginBloc>(() => _i23.LoginBloc(
      userRepository: get<_i22.UserRepository>(),
      secureStorageRepository: get<_i5.SecureStorageRepository>(),
      dio: get<_i6.Dio>()));
  gh.factory<_i24.ProfileCubit>(() => _i24.ProfileCubit(
      userRepository: get<_i22.UserRepository>(),
      accountDetailsRepository: get<_i17.AccountDetailsRepository>()));
  gh.factory<_i25.RegistrationBloc>(() => _i25.RegistrationBloc(
      userRepository: get<_i22.UserRepository>(),
      secureStorageRepository: get<_i5.SecureStorageRepository>(),
      dio: get<_i6.Dio>()));
  gh.factory<_i26.SubscribeCubit>(() => _i26.SubscribeCubit(
      userRepository: get<_i22.UserRepository>(),
      followerRepository: get<_i8.FollowerRepository>()));
  return get;
}

class _$RegisterModule extends _i27.RegisterModule {}
