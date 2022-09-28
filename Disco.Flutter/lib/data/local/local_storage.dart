import 'dart:developer';

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
    log('$value', name: 'Secure Storage read');

    return value;
  }

  void delete({required String key}) {
    secureStorage.delete(key: key);
  }

  Future<void> deleteAll() async {
    return await secureStorage.deleteAll();
  }
}
