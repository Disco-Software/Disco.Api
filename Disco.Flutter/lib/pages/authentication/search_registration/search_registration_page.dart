import 'dart:io' show Platform;

import 'package:disco_app/data/network/api/auth_api.dart';
import 'package:disco_app/data/network/request_models/access_token_requset_model.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_facebook_auth/flutter_facebook_auth.dart';
import 'package:google_fonts/google_fonts.dart';

class SearchRegistrationPage extends StatefulWidget {
  const SearchRegistrationPage({Key? key}) : super(key: key);
  static const routeName = "/search";

  @override
  _SearchRegistrationPageState createState() => _SearchRegistrationPageState();
}

class _SearchRegistrationPageState extends State<SearchRegistrationPage> {
  @override
  Widget build(BuildContext context) {
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
                            style: GoogleFonts.aBeeZee(textStyle: const TextStyle(color: DcColors.darkWhite, fontSize: 16)),
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
                          label: Text('Continue with Facebook',
                              style:  GoogleFonts.aBeeZee(textStyle:const TextStyle(color: DcColors.darkWhite, fontSize: 16)),
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
                      style:TextStyle(color: DcColors.darkWhite, fontSize: 12) ),
                    ),
                ],
              ),
            ),
          ),
        ));
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
    Navigator.of(context).pop();
  }

  void onEmailPressed() {}

  void onGooglePressed() {}

  void onApplePressed() {}

  void onFacebookPressed() async {
    final facebookResponse = await FacebookAuth.i.login(permissions: ['public_profile', 'email']);
    if(facebookResponse.status == LoginStatus.success){
      final requestData = FacebookAuth.i.getUserData(
        fields: 'email,name,username,picture,',
      );
    }
  }
}
