class SearchPageEvent{

}

class LogInFacebookEvent extends SearchPageEvent{
  String? accessToken;

  LogInFacebookEvent({required this.accessToken});
}

class LogInAppleEvent extends SearchPageEvent{
  String AppleId;
  String Password;

  LogInAppleEvent({required this.AppleId, required this.Password});
}