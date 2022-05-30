import 'package:disco_app/data/local/local_storage.dart';
import 'package:disco_app/data/network/api/auth_api.dart';
import 'package:disco_app/data/network/network_models/user_network.dart';
import 'package:disco_app/data/network/request_models/access_token_requset_model.dart';
import 'package:disco_app/data/network/request_models/apple_login.dart';
import 'package:disco_app/pages/authentication/search_registration/bloc/search_state.dart';
import 'package:disco_app/res/strings.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../../injection.dart';

class SearchCubit extends Cubit<SearchPageState> {
  SearchCubit() : super(InitialState());

  Future<void> handleFacebookLogIn(String accessToken) async {
    emit(FacebookRegistrationState());
    emit(LoadingState());
    final authResult =
        await getIt.get<AuthApi>().facebook(AccessTokenRequestModel(accessToken: accessToken));
    if (authResult?.user != null && authResult?.accesToken != null) {
      _saveUserData(authResult);

      emit(FacebookRegistratedState());
    }
  }

  Future<void> handleAppleLogIn({required String email, required String name}) async {
    emit(AppleRegistrationState());
    emit(LoadingState());
    final authResult = await getIt.get<AuthApi>().apple(AppleLogInRequestModel(
          name: name,
          appleId: email,
          email: email,
        ));
    if (authResult?.user != null && authResult?.accesToken != null) {
      _saveUserData(authResult);

      emit(AppleRegistratedState());
    }
  }

  void _saveUserData(UserTokenResponse? authResult) {
    getIt
        .get<SecureStorageRepository>()
        .write(key: Strings.token, value: authResult?.accesToken ?? "");
    getIt
        .get<SecureStorageRepository>()
        .write(key: Strings.refreshToken, value: authResult?.refreshToken ?? "");
    getIt
        .get<SecureStorageRepository>()
        .write(key: Strings.userPhoto, value: authResult?.user?.profile?.photo ?? "");
    getIt
        .get<SecureStorageRepository>()
        .write(key: Strings.userId, value: '${authResult?.user?.id}');
  }
}
