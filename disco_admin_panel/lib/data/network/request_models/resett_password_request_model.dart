class ResetPasswordRequestModel {
  String? confirmationToken;
  String? email;
  String? password;
  String? confirmPassword;

  ResetPasswordRequestModel(
      {this.confirmationToken,
      this.email,
      this.password,
      this.confirmPassword});

  ResetPasswordRequestModel.fromJson(Map<String, dynamic> json) {
    confirmationToken = json['ConfirmationToken'];
    email = json['Email'];
    password = json['Password'];
    confirmPassword = json['ConfirmPassword'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['ConfirmationToken'] = confirmationToken;
    data['Email'] = email;
    data['Password'] = password;
    data['ConfirmPassword'] = confirmPassword;
    return data;
  }
}
