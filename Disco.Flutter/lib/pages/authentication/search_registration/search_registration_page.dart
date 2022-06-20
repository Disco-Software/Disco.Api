import 'dart:io' show Platform;

import 'package:auto_route/auto_route.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/pages/authentication/search_registration/bloc/search_state.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_facebook_auth/flutter_facebook_auth.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:sign_in_with_apple/sign_in_with_apple.dart';

import 'bloc/search_cubit.dart';

class SearchRegistrationPage extends StatefulWidget {
  const SearchRegistrationPage({Key? key}) : super(key: key);
  static const routeName = "/search";

  @override
  _SearchRegistrationPageState createState() => _SearchRegistrationPageState();
}

class _SearchRegistrationPageState extends State<SearchRegistrationPage> {
  @override
  Widget build(BuildContext context) {
    return BlocConsumer<SearchCubit, SearchPageState>(
      listener: (ctx, state) {
        WidgetsBinding.instance?.addPostFrameCallback((timeStamp) {
          if (state is FacebookRegistratedState || state is AppleRegistratedState) {
            context.router.navigate(HomeRoute());
          }
        });
      },
      builder: (ctx, state) {
        return Scaffold(
            appBar: AppBar(
              leading: IconButton(
                icon: Image.asset('assets/back_button.png'),
                onPressed: onBackButtonPressed,
              ),
              title: const Text('Registration', style: TextStyle(fontSize: 28)),
              backgroundColor: DcColors.darkViolet,
              centerTitle: true,
            ),
            body: Container(
              decoration: const BoxDecoration(
                image: DecorationImage(
                  image: AssetImage("assets/background.png"),
                  fit: BoxFit.cover,
                ),
              ),
              height: double.infinity,
              width: double.infinity,
              child: Center(
                child: Padding(
                  padding: const EdgeInsets.only(top: 62),
                  child: Stack(
                    children: [
                      Column(
                        mainAxisAlignment: MainAxisAlignment.start,
                        children: [
                          Padding(
                            padding: const EdgeInsets.only(left: 71, right: 71),
                            child: SizedBox(
                                width: double.infinity,
                                child: OutlinedButton.icon(
                                  onPressed: onEmailPressed,
                                  icon: Image.asset('assets/ic_email.png'),
                                  label: Text(
                                    'Continue with E-mail',
                                    style: GoogleFonts.aBeeZee(
                                        textStyle: const TextStyle(
                                            color: DcColors.darkWhite, fontSize: 16)),
                                  ),
                                )),
                          ),
                          const SizedBox(
                            height: 51,
                          ),
                          Padding(
                            padding: const EdgeInsets.only(left: 71, right: 71),
                            child: SizedBox(
                              width: double.infinity,
                              child: _setButtonOnPlatform(),
                            ),
                          ),
                          const SizedBox(
                            height: 51,
                          ),
                          Padding(
                            padding: const EdgeInsets.only(left: 71, right: 71),
                            child: SizedBox(
                                width: double.infinity,
                                child: OutlinedButton.icon(
                                  onPressed: onFacebookPressed,
                                  icon: Image.asset('assets/ic_facebook.png'),
                                  label: Text(
                                    'Continue with Facebook',
                                    style: GoogleFonts.aBeeZee(
                                        textStyle: const TextStyle(
                                            color: DcColors.darkWhite, fontSize: 16)),
                                  ),
                                )),
                          ),
                          const SizedBox(
                            height: 62,
                          ),
                          const Padding(
                            padding: EdgeInsets.only(left: 80, right: 80),
                            child: Text(
                                'By continuing, you agree to accept our ' +
                                    'Privacy Policy & Terms of Service',
                                textAlign: TextAlign.center,
                                style: TextStyle(color: DcColors.darkWhite, fontSize: 12)),
                          ),
                        ],
                      ),
                      if (state is LoadingState) const Center(child: CircularProgressIndicator()),
                    ],
                  ),
                ),
              ),
            ));
      },
    );
  }

  Widget _setButtonOnPlatform() {
    if (Platform.isIOS) {
      return OutlinedButton.icon(
          onPressed: onApplePressed,
          icon: Image.asset('assets/ic_apple.png'),
          label: const Text(
            'Continue with Apple ID',
            style: TextStyle(fontSize: 16),
          ));
    } else {
      return OutlinedButton.icon(
          onPressed: onGooglePressed,
          icon: Image.asset('assets/ic_google.png'),
          label: const Text(
            'Continue with Google',
            style: TextStyle(fontSize: 16),
          ));
    }
  }

  void onBackButtonPressed() {
    context.router.pop();
  }

  void onEmailPressed() {
    context.router.navigate(const RegistrationRoute());
  }

  void onGooglePressed() {}

  Future<void> onApplePressed() async {
    final appleResponse = await SignInWithApple.getAppleIDCredential(
      scopes: [
        AppleIDAuthorizationScopes.email,
        AppleIDAuthorizationScopes.fullName,
      ],
    );

    if (appleResponse.email != null && appleResponse.givenName != null) {
      context.read<SearchCubit>().handleAppleLogIn(
          name: appleResponse.givenName ?? '', email: appleResponse.userIdentifier ?? '');
    }
  }

  void onFacebookPressed() async {
    final facebookResponse = await FacebookAuth.i.login(permissions: ['public_profile', 'email']);
    final String? token = facebookResponse.accessToken?.token;
    if (facebookResponse.status == LoginStatus.success) {
      FacebookAuth.i.getUserData(fields: 'email,first_name,name,picture');
      context.read<SearchCubit>().handleFacebookLogIn(token ?? '');
    }
  }
}
