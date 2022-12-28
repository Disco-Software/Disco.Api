import 'dart:async';

import 'package:dio/dio.dart';
import 'package:injectable/injectable.dart';


@injectable
class AccountDetailsApi {
  final Dio client;

  AccountDetailsApi({required this.client});

  Future<dynamic> setPhoto(FormData data) => client
          .put("user/account/details/change/photo", data: data)
          .then((response) {
        return response.data;
      });
}
