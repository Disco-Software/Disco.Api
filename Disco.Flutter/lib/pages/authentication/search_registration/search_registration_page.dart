import 'dart:io' show Platform;

import 'package:auto_route/src/router/auto_router_x.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/data/network/api/auth_api.dart';
import 'package:disco_app/pages/authentication/search_registration/bloc/search_bloc.dart';
import 'package:disco_app/pages/authentication/search_registration/bloc/search_state.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_facebook_auth/flutter_facebook_auth.dart';
import 'package:get_it/get_it.dart';
import 'package:google_fonts/google_fonts.dart';

import 'bloc/search_event.dart';

class SearchRegistrationPage extends StatefulWidget {
  const SearchRegistrationPage({Key? key}) : super(key: key);
  static const routeName = "/search";

  @override
  _SearchRegistrationPageState createState() => _SearchRegistrationPageState();
}

class _SearchRegistrationPageState extends State<SearchRegistrationPage> {
  final _bloc = SearchBloc(InitialState(), authApi: GetIt.I.get<AuthApi>());

  void _blocLisener(BuildContext context, Object? state) {
    WidgetsBinding.instance?.addPostFrameCallback((timeStamp) {
      if (state is FacebookRegistratedState) {
        context.router.navigate(const HomeRoute());
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<SearchBloc, SearchPageState>(
      bloc: _bloc,
      listener: _blocLisener,
      builder: (context, state) => Scaffold(
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
                child: Column(
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
                          style: TextStyle(
                              color: DcColors.darkWhite, fontSize: 12)),
                    ),
                  ],
                ),
              ),
            ),
          )),
    );
  }

  Widget _setButtonOnPlatform() {
    if (Platform.isIOS) {
      return OutlinedButton.icon(
          onPressed: onApplePressed,
          icon: Image.asset('assets/apple.png'),
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

  void onApplePressed() {}

  void onFacebookPressed() async {
    final facebookResponse =
        await FacebookAuth.i.login(permissions: ['public_profile', 'email']);
    final String? token = facebookResponse.accessToken?.token;
    if (facebookResponse.status == LoginStatus.success) {
      FacebookAuth.i.getUserData(fields: 'email,first_name,name,picture');
      _bloc.add(LogInFacebookEvent(accessToken: token));
    }
  }
}
