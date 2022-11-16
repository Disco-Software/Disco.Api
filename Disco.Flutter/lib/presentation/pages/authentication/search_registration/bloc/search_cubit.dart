import 'dart:developer' as developer;

import 'package:disco_app/app/extensions/secure_storage_extensions.dart';
import 'package:disco_app/data/local/local_storage.dart';
import 'package:disco_app/data/network/api/auth_api.dart';
import 'package:disco_app/data/network/network_models/user_network.dart';
import 'package:disco_app/data/network/request_models/access_token_requset_model.dart';
import 'package:disco_app/data/network/request_models/apple_login.dart';
import 'package:disco_app/data/network/request_models/google_login_request_model.dart';
import 'package:disco_app/domain/stored_user_model.dart';
import 'package:disco_app/presentation/pages/authentication/search_registration/bloc/search_state.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:google_sign_in/google_sign_in.dart';

import '../../../../../injection.dart';

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

  Future<void> handleGoogleLogIn({
    required GoogleSignInAccount user,
  }) async {
    try {
      emit(GoogleRegistrationState());
      emit(LoadingState());
      final authResult = await getIt.get<AuthApi>().googleLogin(GoogleLogInRequestModel(
            userName: user.displayName ?? '',
            email: user.email,
            tokenId: user.id,
            photoUrl: user.photoUrl,
            serverAuthCode: user.serverAuthCode,
          ));
      if (authResult?.user != null && authResult?.accesToken != null) {
        developer.log(authResult?.user?.email ?? '', name: 'Saved user');
        _saveUserData(authResult);

        emit(GoogleRegistratedState());
      }
    } catch (err) {
      emit(ErrorSearchPageState());
    }
  }

  void _saveUserData(UserTokenResponse? authResult) async {
    getIt.get<SecureStorageRepository>().saveUserModel(
          storedUserModel: StoredUserModel(
            refreshToken: authResult?.refreshToken,
            token: authResult?.accesToken,
            userId: '${authResult?.user?.id}',
            userName: authResult?.user?.userName,
            userPhoto: authResult?.user?.account?.photo,
            moto: authResult?.user?.account?.creed,
            currentFollowers: authResult?.user?.account?.status?.followersCount,
            userTarget: authResult?.user?.account?.status?.userTarget,
            lastStatus: authResult?.user?.account?.status?.lastStatus,
          ),
        );
  }
}
