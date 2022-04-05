import 'package:disco_app/data/network/api/auth_api.dart';
import 'package:disco_app/data/network/request_models/access_token_requset_model.dart';
import 'package:disco_app/pages/authentication/search_registration/bloc/search_event.dart';
import 'package:disco_app/pages/authentication/search_registration/bloc/search_state.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class SearchBloc extends Bloc<SearchPageEvent, SearchPageState> {
  final AuthApi authApi;

  SearchBloc(initialState, {required this.authApi}) : super(initialState) {
    on<LogInFacebookEvent>((event, emit) {
      emit.forEach<SearchPageState>(_handleFacebookLogIn(event),
          onData: (state) => state);
    });
  }
  Stream<SearchPageState> _handleFacebookLogIn(
      LogInFacebookEvent event) async* {
    yield FacebookRegistrationState();
    final authResult = await authApi
        .facebook(AccessTokenRequestModel(accessToken: event.accessToken));
    if (authResult?.user != null && authResult?.verificationResult != null) {
      yield FacebookRegistratedState();
    }
  }
}
