import 'package:disco_app/data/local/local_storage.dart';
import 'package:disco_app/res/strings.dart';

extension Secure on SecureStorageRepository {
  Future<void>? saveUserModel({
    required String? token,
    required String? refreshToken,
    required String? userPhoto,
    required String? userId,
    required String? userName,
    required String? moto,
    required int? currentFollowers,
    required int? goalFollowers,
  }) async {
    await write(key: Strings.userPhoto, value: userPhoto ?? '');
    await write(key: Strings.userId, value: userId ?? '');
    await write(key: Strings.moto, value: moto ?? '');
    await write(key: Strings.currentFollowers, value: currentFollowers.toString());
    await write(key: Strings.goalFollowers, value: goalFollowers.toString());
    await write(key: Strings.userName, value: userName ?? '');
    await write(key: Strings.refreshToken, value: refreshToken ?? '');
    return await write(key: Strings.token, value: token ?? '');
  }
}
