class StoredUserModel {
  final String? token;
  final String? refreshToken;
  final String? userPhoto;
  final String? userId;
  final String? userName;
  final String? moto;
  final String? lastStatus;
  final int? currentFollowers;
  final int? userTarget;

  StoredUserModel({
    required this.lastStatus,
    this.token,
    this.refreshToken,
    this.userPhoto,
    this.userId,
    this.userName,
    this.moto,
    this.currentFollowers,
    this.userTarget,
  });

  @override
  String toString() {
    return 'StoredUserModel{token: $token, refreshToken: $refreshToken, userPhoto: $userPhoto, userId: $userId, userName: $userName, moto: $moto, lastStatus: $lastStatus, currentFollowers: $currentFollowers, userTarget: $userTarget}';
  }
}
