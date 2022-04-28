import 'package:dio/dio.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:injectable/injectable.dart';
import 'package:pretty_dio_logger/pretty_dio_logger.dart';

import 'data/network/interceptors/header_interceptor.dart';

const token =
    'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJuYmYiOjE2NDkxOTE4NDUsImV4cCI6MTY0OTI2Mzg0NSwiaXNzIjoiZGlzY28tYXBpIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdC9EaXNjby5BcGkifQ.rX0a333pDDs7mqWWt9WhwALsE6BBy2XOeUokRRLCt1M';

@module
abstract class RegisterModule {
  // You can register named preemptive types like follows
  @Named("BaseUrl")
  String get baseUrl => 'https://devdiscoapi.azurewebsites.net/api/';

  // url here will be injected
  @lazySingleton
  Dio dio(@Named('BaseUrl') String url) => _getDio(url);

  @lazySingleton
  FlutterSecureStorage flutterSecureStorage() => const FlutterSecureStorage();

  Dio _getDio(String url) {
    final dio = Dio(BaseOptions(baseUrl: url));
    final interceptors = [
      HeaderInterceptor.instance..set(dio),
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
