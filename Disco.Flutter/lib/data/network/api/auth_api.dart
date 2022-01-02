import 'package:dio/dio.dart';
import 'package:disco_app/data/network/request-models/register_request.dart';

import '../network_client.dart';
import '../network_models/user_network.dart';
import '../request-models/login_request.dart';

class AuthApi {

  Future<Response<UserTokenResponse>> login(LogInRequestModel model) => NetworkClient.instance.dio.post<UserTokenResponse>("user/authentication/log-in", data: model);

  Future<Response<UserTokenResponse>> registration(RegisterRequestModel model) => NetworkClient.instance.dio.post<UserTokenResponse>("user/authentication/registration", data: model);
}