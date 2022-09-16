class RegisterRequestModel {
  String? userName;
  String? email;
  String? password;
  String? confirmPassword;

  RegisterRequestModel({this.userName, this.email, this.password, this.confirmPassword});

  RegisterRequestModel.fromJson(Map<String, dynamic> json) {
    userName = json['UserName'];
    email = json['Email'];
    password = json['Password'];
    confirmPassword = json['ConfirmPassword'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['UserName'] = userName;
    data['Email'] = email;
    data['Password'] = password;
    data['ConfirmPassword'] = confirmPassword;
    return data;
  }
}
