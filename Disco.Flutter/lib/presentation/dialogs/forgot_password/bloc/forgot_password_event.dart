abstract class ForgotPasswordEvent{

}

class ForgotPasswordOnSendingEvent extends ForgotPasswordEvent{
  final String email;

  ForgotPasswordOnSendingEvent({required this.email});
}