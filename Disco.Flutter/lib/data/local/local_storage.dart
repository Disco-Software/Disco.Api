import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:injectable/injectable.dart';

@injectable
class SecureStorageRepository {
  final FlutterSecureStorage secureStorage;

  SecureStorageRepository({required this.secureStorage});

  void write({required String key, required String value}) {
    secureStorage.write(key: key, value: value);
  }

  void read({required String key}) {
    secureStorage.read(key: key);
  }
}
