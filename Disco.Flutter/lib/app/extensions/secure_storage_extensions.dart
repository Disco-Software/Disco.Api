import 'package:disco_app/data/local/local_storage.dart';
import 'package:disco_app/domain/stored_user_model.dart';
import 'package:disco_app/res/strings.dart';

extension Secure on SecureStorageRepository {
  Future<void>? saveUserModel({required StoredUserModel? storedUserModel}) async {
    if (storedUserModel?.userPhoto != null) {
      await write(key: Strings.userPhoto, value: storedUserModel?.userPhoto ?? '');
    }
    if (storedUserModel?.userId != null) {
      await write(key: Strings.userId, value: storedUserModel?.userId ?? '');
    }
    if (storedUserModel?.moto != null) {
      await write(key: Strings.moto, value: storedUserModel?.moto ?? '');
    }
    if (storedUserModel?.currentFollowers != null) {
      await write(
          key: Strings.currentFollowers, value: storedUserModel?.currentFollowers.toString() ?? '');
    }
    if (storedUserModel?.userTarget != null) {
      await write(
          key: Strings.goalFollowers, value: storedUserModel?.userTarget.toString() ?? '');
    }
    if (storedUserModel?.userName != null) {
      await write(key: Strings.userName, value: storedUserModel?.userName ?? '');
    }
    if (storedUserModel?.refreshToken != null) {
      await write(key: Strings.refreshToken, value: storedUserModel?.refreshToken ?? '');
    }
    if (storedUserModel?.token != null) {
      await write(key: Strings.token, value: storedUserModel?.token ?? '');
    }
    if (storedUserModel?.lastStatus != null) {
      await write(key: Strings.lastStatus, value: storedUserModel?.lastStatus ?? '');
    }
    return;
  }
}
