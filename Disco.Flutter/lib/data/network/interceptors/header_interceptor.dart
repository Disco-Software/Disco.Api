import 'dart:async';

import 'package:dio/dio.dart';
import 'package:disco_app/data/local/local_storage.dart';
import 'package:disco_app/data/network/api/auth_api.dart';
import 'package:disco_app/data/network/network_models/user_network.dart';
import 'package:disco_app/res/strings.dart';
import 'package:flutter/material.dart';

import '../../../injection.dart';

enum TokenType { Firebase, JWT, Bearer, Custom }

const _authHeader = 'Authorization';

class HeaderInterceptor extends Interceptor {
  HeaderInterceptor._privateConstructor();

  static final HeaderInterceptor _instance = HeaderInterceptor._privateConstructor();

  static HeaderInterceptor get instance => _instance;

  late final Dio _dio;

  // TokenStorage _tokenStorage;

  // bool _isFirstTokenError = true;

  late Future Function(RequestOptions, RequestInterceptorHandler) onRequestFunction;
  late Future Function(Response, ResponseInterceptorHandler) onResponseFunction;
  late Future Function(DioError, ErrorInterceptorHandler) onErrorFunction;

  void init({
    TokenType tokenType = TokenType.Custom,
    required Future Function(RequestOptions options, RequestInterceptorHandler handler) onRequest,
    required Future Function(Response response, ResponseInterceptorHandler handler) onResponse,
    required Future Function(DioError error, ErrorInterceptorHandler handler) onError,
  }) {
    onRequestFunction = onRequest;
    onResponseFunction = onResponse;
    onErrorFunction = onError;
    return;
  }

  void set(Dio dio) {
    _dio = dio;
    // _tokenStorage = tokenStorage;
  }

  @override
  Future onRequest(RequestOptions options, RequestInterceptorHandler handler) async {
    final String token = await getIt.get<SecureStorageRepository>().read(key: Strings.token);
    if (token.isNotEmpty) {
      options.headers[_authHeader] = 'Bearer ' + token;
    }
    debugPrint('${options.headers} hehe');

    // return onRequestFunction(options, handler);
    return handler.next(options);
  }

  @override
  Future onError(DioError error, ErrorInterceptorHandler handler) async {
    // final String token = await getIt.get<SecureStorageRepository>().read(key: Strings.token) ?? '';
    if (_isTokenExpiredError(error)) {
      try {
        final UserTokenResponse? newToken = await getIt.get<AuthApi>().refreshToken();
        getIt
            .get<SecureStorageRepository>()
            .write(key: Strings.token, value: newToken?.verificationResult ?? '');
      } catch (err) {
        print('Error _refreshToken | header_interceptor-> $err');
      }

      return handler.next(error);
    }
    // else if (_isTokenExpiredError(error)) {
    //   _logger.info('token RENEWED, logout');
    // }

    return handler.next(error);
  }

  @override
  Future onResponse(Response response, ResponseInterceptorHandler handler) async {
    return handler.next(response);
  }

  bool _isTokenExpiredError(DioError error) {
    return error.response?.statusCode == 401;
  }
}
