import 'dart:async';

import 'package:dio/dio.dart';
import 'package:disco_app/data/local/local_storage.dart';
import 'package:disco_app/data/network/api/auth_api.dart';
import 'package:disco_app/data/network/network_models/refresh_token_model.dart';
import 'package:disco_app/data/network/network_models/user_network.dart';
import 'package:disco_app/res/strings.dart';

import '../../../injection.dart';

const _authHeader = 'Authorization';

class HeaderInterceptor extends Interceptor {
  HeaderInterceptor._privateConstructor();

  static final HeaderInterceptor _instance = HeaderInterceptor._privateConstructor();

  static HeaderInterceptor get instance => _instance;
  late final Dio _dio;

  void setDio(Dio dio) {
    _dio = dio;
  }

  @override
  Future onRequest(RequestOptions options, RequestInterceptorHandler handler) async {
    final String token = await getIt.get<SecureStorageRepository>().read(key: Strings.token);
    if (token.isNotEmpty) {
      options.headers[_authHeader] = 'Bearer ' + token;
    }

    return handler.next(options);
  }

  @override
  Future onError(DioError error, ErrorInterceptorHandler handler) async {
    if (_isTokenExpiredError(error)) {
      final accessToken = await getIt.get<SecureStorageRepository>().read(key: Strings.token);
      final refreshToken =
          await getIt.get<SecureStorageRepository>().read(key: Strings.refreshToken);

      try {
        final UserTokenResponse? newToken =
            await getIt.get<AuthApi>().refreshToken(RefreshTokenModel(
                  accessToken: accessToken,
                  refreshToken: refreshToken,
                ));
        await getIt
            .get<SecureStorageRepository>()
            .write(key: Strings.token, value: newToken?.accesToken ?? '');
        await getIt
            .get<SecureStorageRepository>()
            .write(key: Strings.refreshToken, value: newToken?.refreshToken ?? '');
      } catch (err) {
        print('Error _refreshToken | header_interceptor-> $err');
      }

      return handler.resolve(await _retry(error.requestOptions, _dio));
    }

    return handler.next(error);
  }

  Future<Response<dynamic>> _retry(RequestOptions requestOptions, Dio dio) async {
    final options = Options(
      method: requestOptions.method,
      headers: requestOptions.headers,
    );
    return dio.request<dynamic>(
      requestOptions.path,
      data: requestOptions.data,
      queryParameters: requestOptions.queryParameters,
      options: options,
    );
  }

  @override
  Future onResponse(Response response, ResponseInterceptorHandler handler) async {
    return handler.next(response);
  }

  bool _isTokenExpiredError(DioError error) {
    return error.response?.statusCode == 401;
  }
}
