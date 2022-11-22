abstract class ResetPasswordPageState {}

class InitialState extends ResetPasswordPageState {
  final String? email;
  InitialState({required this.email});
}

class SuccessPageState extends ResetPasswordPageState {}

class FaildPageState extends ResetPasswordPageState {
  final String? errorDescription;

  FaildPageState({this.errorDescription});
}
