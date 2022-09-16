import 'package:dio/dio.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:injectable/injectable.dart';
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
}
