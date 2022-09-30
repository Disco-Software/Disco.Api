abstract class RegistrationPageEvent{

}

class RegistrationEvent extends RegistrationPageEvent{
  String userName;
  String email;
  String password;
  String confirmPassword;

  RegistrationEvent({required this.userName, required this.email, required this.password, required this.confirmPassword});
}