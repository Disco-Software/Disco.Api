import 'dart:io';

import 'package:dio/dio.dart';
import 'package:disco_app/data/network/api/account_details_api.dart';
import 'package:disco_app/data/network/network_models/user_network.dart';
import 'package:injectable/injectable.dart';

@injectable
class AccountDetailsRepository {
  final AccountDetailsApi accountDetailsApi;

  AccountDetailsRepository({required this.accountDetailsApi});

  Future<User> setPhoto(String photo) async {
    final formData =
        FormData.fromMap({"Photo": await MultipartFile.fromFile(photo)});

    final json = await accountDetailsApi.setPhoto(formData);

    final user = User.fromJson(json);

    return user;
  }
}
