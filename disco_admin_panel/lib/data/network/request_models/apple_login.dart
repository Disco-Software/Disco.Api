class AppleLogInRequestModel {
  String? email;
  String? name;
  String? appleId;

  AppleLogInRequestModel({this.email, this.name, this.appleId});

  AppleLogInRequestModel.fromJson(Map<String, dynamic> json) {
    email = json['Email'];
    name = json['Name'];
    appleId = json['AppleId'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['Email'] = email;
    data['Name'] = name;
    data['AppleId'] = appleId;
    return data;
  }
}
