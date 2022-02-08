abstract class LoginPageEvent{

}

class LoginEvent extends LoginPageEvent{
  final String email;
  final String password;

  LoginEvent({required this.email, required this.password});
}