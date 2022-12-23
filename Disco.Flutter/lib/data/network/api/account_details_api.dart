import 'dart:async';

import 'package:dio/dio.dart';
import 'package:disco_app/data/network/network_models/refresh_token_model.dart';
import 'package:disco_app/data/network/request_models/access_token_requset_model.dart';
import 'package:disco_app/data/network/request_models/apple_login.dart';
import 'package:disco_app/data/network/request_models/google_login_request_model.dart';
import 'package:disco_app/data/network/request_models/register_request.dart';
import 'package:disco_app/data/network/request_models/reset_password_request.dart';
import 'package:disco_app/data/network/request_models/resett_password_request_model.dart';
import 'package:injectable/injectable.dart';

import '../network_models/user_network.dart';
import '../request_models/login_request.dart';

@injectable
class AccountDetailsApi {
  final Dio client;

  AccountDetailsApi({required this.client});

  Future<dynamic> setPhoto(FormData data) => client
          .post("user/account/details/change/photo", data: data)
          .then((response) {
        return response.data;
      });
}
