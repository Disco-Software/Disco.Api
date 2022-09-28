class RefreshTokenModel {
  String? refreshToken;
  String? accessToken;

  RefreshTokenModel({this.refreshToken, this.accessToken});

  RefreshTokenModel.fromJson(Map<String, dynamic> json) {
    refreshToken = json['RefreshToken'];
    accessToken = json["AccessToken"];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    if (refreshToken != null) {
      data['refreshToken'] = refreshToken;
    }
    if (accessToken != null) {
      data['accessToken'] = accessToken;
    }

    return data;
  }
}
