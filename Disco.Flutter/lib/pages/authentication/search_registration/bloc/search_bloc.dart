import 'package:disco_app/data/local/local_storage.dart';
import 'package:disco_app/data/network/api/auth_api.dart';
import 'package:disco_app/data/network/request_models/access_token_requset_model.dart';
import 'package:disco_app/pages/authentication/search_registration/bloc/search_event.dart';
import 'package:disco_app/pages/authentication/search_registration/bloc/search_state.dart';
import 'package:disco_app/res/strings.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../../injection.dart';

class SearchBloc extends Bloc<SearchPageEvent, SearchPageState> {
  final AuthApi authApi;

  //final SecureStorageRepository secureStorageRepository;
  SearchBloc(
    initialState, {
    required this.authApi,
    //required this.secureStorageRepository,
  }) : super(initialState) {
    on<LogInFacebookEvent>((event, emit) {
      emit.forEach<SearchPageState>(_handleFacebookLogIn(event), onData: (state) => state);
    });
  }

  Stream<SearchPageState> _handleFacebookLogIn(LogInFacebookEvent event) async* {
    yield FacebookRegistrationState();
    final authResult =
        await authApi.facebook(AccessTokenRequestModel(accessToken: event.accessToken));
    if (authResult?.user != null && authResult?.verificationResult != null) {
      getIt
          .get<SecureStorageRepository>()
          .write(key: Strings.token, value: authResult?.verificationResult ?? "");
      getIt
          .get<SecureStorageRepository>()
          .write(key: Strings.userPhoto, value: authResult?.user?.profile?.photo ?? "");
      getIt
          .get<SecureStorageRepository>()
          .write(key: Strings.userId, value: '${authResult?.user?.id}');

      yield FacebookRegistratedState();
    }
  }
}
