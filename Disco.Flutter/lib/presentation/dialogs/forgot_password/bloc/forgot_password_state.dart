abstract class ForgotPasswordState{

}
class InitState extends ForgotPasswordState{

}
class SendedMessageToEmailState extends ForgotPasswordState{

}

class ForgotPasswordEmailSendingState extends ForgotPasswordState{

}

class ForgotPasswordSendedState extends ForgotPasswordState{

}

class ForgotPasswordErrorState extends ForgotPasswordState{
  final String? emailError;

  ForgotPasswordErrorState({this.emailError});
}