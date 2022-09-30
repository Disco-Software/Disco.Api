import 'package:dio/dio.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:injectable/injectable.dart';
import 'package:just_audio/just_audio.dart';
import 'package:pretty_dio_logger/pretty_dio_logger.dart';

import 'data/network/interceptors/header_interceptor.dart';

@module
abstract class RegisterModule {
  @Named("BaseUrl")
  String get baseUrl => 'https://devdiscoapi.azurewebsites.net/api/';

  @lazySingleton
  Dio dio(@Named('BaseUrl') String url) => _getDio(url);

  @lazySingleton
  FlutterSecureStorage flutterSecureStorage() => const FlutterSecureStorage();

  @lazySingleton
  AudioPlayer audioPlayer() => AudioPlayer();

  Dio _getDio(String url) {
    final dio = Dio(BaseOptions(baseUrl: url));
    final interceptors = [
      HeaderInterceptor.instance..setDio(dio),
      PrettyDioLogger(
        requestBody: true,
        requestHeader: true,
      ),
    ];

    return dio..interceptors.addAll(interceptors);
  }

// same thing works for instances that's gotten asynchronous.
// all you need to do is wrap your instance with a future and tell injectable how
// to initialize it
// @preResolve // if you need to pre resolve the value
// Future<SharedPreferences> get prefs => SharedPreferences.getInstance();
// Also, make sure you await for your configure function before running the App.

}
