import 'package:flutter/material.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:injectable/injectable.dart';

@injectable
class SecureStorageRepository {
  final FlutterSecureStorage secureStorage;

  SecureStorageRepository({required this.secureStorage});

  Future<void>? write({required String key, required String value}) {
    debugPrint('SecureStorageRepository -->write');

    secureStorage.write(key: key, value: value);
  }

  Future<String> read({required String key}) async {
    String value;
    debugPrint('SecureStorageRepository --> read');
    value = await secureStorage.read(key: key) ?? '';
    debugPrint('SecureStorageRepository --> reded value: $value');
    return value;
  }

  void delete({required String key}) {
    secureStorage.delete(key: key);
  }

  Future<void> deleteAll() async {
    return await secureStorage.deleteAll();
  }
}
