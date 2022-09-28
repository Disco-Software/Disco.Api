abstract class ResetPasswordEvent{}
class ResetPasswordOnResetEvent{
  final String? email;

  ResetPasswordOnResetEvent({this.email});
}