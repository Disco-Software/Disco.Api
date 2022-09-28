import 'package:disco_admin_panel/core/strings.dart';
import 'package:disco_admin_panel/data/local/secure_storage.dart';

extension Secure on SecureStorageRepository {
  Future<void>? saveUserModel({
    required String? token,
    required String? refreshToken,
    required String? userPhoto,
    required String? userId,
    required String? userName,
  }) async {
    await write(key: Strings.userPhoto, value: userPhoto ?? '');
    await write(key: Strings.userId, value: userId ?? '');
    await write(key: Strings.userName, value: userName ?? '');
    await write(key: Strings.refreshToken, value: refreshToken ?? '');
    return await write(key: Strings.token, value: token ?? '');
  }
}
