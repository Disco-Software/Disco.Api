abstract class RegistrationPageState{

}
class InitialState extends RegistrationPageState{

}
class RegistratingState extends RegistrationPageState{

}

class RegistratedState extends RegistrationPageState{

}

class RegistrationErrorState extends RegistrationPageState{
  String? userName;
  String? email;
  String? password;
  String? confirmPassword;

  RegistrationErrorState({this.userName, this.email, this.password, this.confirmPassword});
}