import 'dart:developer';

import 'package:disco_app/domain/stored_user_model.dart';
import 'package:disco_app/res/strings.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:injectable/injectable.dart';

@injectable
class SecureStorageRepository {
  final FlutterSecureStorage secureStorage;

  SecureStorageRepository({required this.secureStorage});

  Future<void>? write({required String key, required String value}) {
    log('SecureStorageRepository -->write', name: 'Secure Storage write');

    secureStorage.write(key: key, value: value);
  }

  Future<String> read({required String key}) async {
    String value;
    value = await secureStorage.read(key: key) ?? '';
    log(value, name: 'Secure Storage read');

    return value;
  }

  Future<StoredUserModel> getStoredUserModel() async {
    final userPhoto = await secureStorage.read(key: Strings.userPhoto) ?? '';
    final goalFollowers = await secureStorage.read(key: Strings.goalFollowers) ?? '';
    final userName = await secureStorage.read(key: Strings.userName) ?? '';
    final userId = await secureStorage.read(key: Strings.userId) ?? '';
    final token = await secureStorage.read(key: Strings.token) ?? '';
    final refreshToken = await secureStorage.read(key: Strings.refreshToken) ?? '';
    final currentFollowers = await secureStorage.read(key: Strings.currentFollowers) ?? '';
    final moto = await secureStorage.read(key: Strings.moto) ?? '';
    final lastStatus = await secureStorage.read(key: Strings.lastStatus) ?? '';

    final model = StoredUserModel(
      userTarget: int.parse(goalFollowers),
      userPhoto: userPhoto,
      userName: userName,
      userId: userId,
      token: token,
      refreshToken: refreshToken,
      currentFollowers: int.parse(currentFollowers),
      moto: moto,
      lastStatus: lastStatus,
    );

    log(model.toString(), name: 'Stored information for user');

    return model;
  }

  void delete({required String key}) {
    secureStorage.delete(key: key);
  }

  Future<void> deleteAll() async {
    await secureStorage.delete(key: Strings.token);
    await secureStorage.delete(key: Strings.refreshToken);
    return await secureStorage.deleteAll();
  }
}
