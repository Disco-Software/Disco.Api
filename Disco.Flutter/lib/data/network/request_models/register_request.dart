class RegisterRequestModel {
  String? userName;
  String? email;
  String? password;
  String? confirmPassword;

  RegisterRequestModel({
    this.userName,
    this.email,
    this.password,
    this.confirmPassword});

  RegisterRequestModel.fromJson(Map<String, dynamic> json) {
    userName = json['UserName'];
    email = json['Email'];
    password = json['Password'];
    confirmPassword = json['ConfirmPassword'];
  }
}
