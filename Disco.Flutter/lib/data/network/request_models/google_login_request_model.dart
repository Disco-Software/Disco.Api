class GoogleLogInRequestModel {
  String? email;
  String? userName;
  String? tokenId;
  String? photoUrl;
  String? id;
  String? serverAuthCode;

  GoogleLogInRequestModel({
    this.email,
    this.userName,
    this.tokenId,
    this.photoUrl,
    this.serverAuthCode,
  });

  GoogleLogInRequestModel.fromJson(Map<String, dynamic> json) {
    email = json['Email'];
    userName = json['UserName'];
    tokenId = json['IdToken'];
    photoUrl = json['Photo'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['Email'] = email;
    data['UserName'] = userName;
    data['IdToken'] = tokenId;
    data['Photo'] = photoUrl;
    return data;
  }
}
