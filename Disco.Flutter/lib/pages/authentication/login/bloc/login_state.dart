abstract class LoginPageState {

}
class LoggedInState extends LoginPageState{

}

class InitLoginState extends LoginPageState{

}

class LogInErrorState extends LoginPageState {
  final String? emailError;
  final String? passwordError;

  LogInErrorState({this.emailError, this.passwordError});
}

class LoginingState extends LoginPageState{

}
