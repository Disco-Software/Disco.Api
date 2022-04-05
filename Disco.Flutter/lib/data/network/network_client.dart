import 'package:dio/dio.dart';
import 'package:disco_app/data/network/network_models/user_network.dart';
import 'package:disco_app/res/strings.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:injectable/injectable.dart';

import 'api/auth_api.dart';

@injectable
class NetworkClient {
  final Dio dio;
  final AuthApi authApi;
  final FlutterSecureStorage storage;
  NetworkClient(
      {required this.dio, required this.authApi, required this.storage}) {
    dio.interceptors.add(InterceptorsWrapper(onError: (error, handler) async {
      if (error.response?.statusCode == 401) {
        await _refreshToken();
        return retry(error.requestOptions);
      }
    }));
  }

  Future<void> _refreshToken() async {
    final UserTokenResponse? user = await authApi.refreshToken();
    storage.write(key: Strings.token, value: user?.verificationResult);
  }

  Future<Response<dynamic>> get(String url, [dynamic queryParams]) async {
    return await dio.get(url, queryParameters: queryParams);
  }

  Future<Response<List<dynamic>?>> getAll(String url) async {
    return await dio.get<List<dynamic>>(url);
  }

  Future<Response<dynamic>> post(String url, [dynamic data]) async {
    return await dio.post(url, data: data);
  }

  Future<Response<String?>> postString(String url, [dynamic data]) async {
    return await dio.post(url, data: data);
  }

  Future<Response<dynamic>> put(String url,
      [Map<String, dynamic>? queryParams]) async {
    return await dio.put(url, queryParameters: queryParams);
  }

  Future<Response<dynamic>> delete(String url) async {
    return await dio.delete(url);
  }

  Future<void> retry(RequestOptions requestOptions) {
    final options = Options(
      method: requestOptions.method,
      headers: requestOptions.headers,
    );
    return dio.request<dynamic>(requestOptions.path,
        data: requestOptions.data,
        queryParameters: requestOptions.queryParameters,
        options: options);
  }
}
