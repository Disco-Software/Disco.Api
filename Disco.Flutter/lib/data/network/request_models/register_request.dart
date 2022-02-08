class RegisterRequestModel {
  String? fullName;
  String? userName;
  String? email;
  String? password;
  String? confirmPassword;

  RegisterRequestModel({this.fullName,
    this.userName,
    this.email,
    this.password,
    this.confirmPassword});

  RegisterRequestModel.fromJson(Map<String, dynamic> json) {
    fullName = json['FullName'];
    userName = json['UserName'];
    email = json['Email'];
    password = json['Password'];
    confirmPassword = json['ConfirmPassword'];
  }
}
