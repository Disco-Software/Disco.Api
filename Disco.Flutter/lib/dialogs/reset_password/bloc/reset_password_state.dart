abstract class ResetPasswordPageState{}
class SuccessPageState extends ResetPasswordPageState{}
class FaildPageState extends ResetPasswordPageState{
  final String? errorDescription;

  FaildPageState({this.errorDescription});
}