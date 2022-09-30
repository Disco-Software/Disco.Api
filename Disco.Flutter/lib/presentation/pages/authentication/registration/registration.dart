import 'package:auto_route/auto_route.dart';
import 'package:dio/dio.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/data/local/local_storage.dart';
import 'package:disco_app/data/network/repositories/user_repository.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../../injection.dart';
import 'bloc/registration_bloc.dart';
import 'bloc/registration_event.dart';
import 'bloc/registration_state.dart';

class RegistrationPage extends StatefulWidget {
  const RegistrationPage({Key? key}) : super(key: key);
  static const routeName = '/registration';

  @override
  _RegistrationPageState createState() => _RegistrationPageState();
}

class _RegistrationPageState extends State<RegistrationPage> {
  final _formKey = GlobalKey<FormState>();
  final _bloc = RegistrationBloc(
    userRepository: getIt.get<UserRepository>(),
    dio: getIt.get<Dio>(),
    secureStorageRepository: getIt.get<SecureStorageRepository>(),
  );
  final _userNameController = TextEditingController();
  final _emailController = TextEditingController();
  final _passwordController = TextEditingController();
  final _confirmPasswordController = TextEditingController();

  void _blocLisener(BuildContext context, Object? state) {
    WidgetsBinding.instance?.addPostFrameCallback((timeStamp) {
      if (state is RegistratedState) {
        context.router.pushAndPopUntil(HomeRoute(), predicate: (route) => false);
      }
    });
  }

  @override
  void dispose() {
    _bloc.close();
    _emailController.dispose();
    _userNameController.dispose();
    _confirmPasswordController.dispose();
    _passwordController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<RegistrationBloc, RegistrationPageState>(
      bloc: _bloc,
      listener: _blocLisener,
      builder: (context, state) => Scaffold(
        appBar: AppBar(
          title: const Text(
            "Registration",
            style: TextStyle(fontSize: 28, fontWeight: FontWeight.normal),
          ),
          leading:
              IconButton(onPressed: onBackPressed, icon: Image.asset("assets/back_button.png")),
          centerTitle: true,
          backgroundColor: DcColors.darkViolet,
        ),
        body: Container(
          decoration: const BoxDecoration(
              image:
                  DecorationImage(image: AssetImage("assets/background.png"), fit: BoxFit.cover)),
          width: double.infinity,
          height: double.infinity,
          child: SingleChildScrollView(
            child: Form(
              key: _formKey,
              child: Padding(
                padding: const EdgeInsets.only(left: 71, right: 71, top: 35),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  crossAxisAlignment: CrossAxisAlignment.start,
                  mainAxisSize: MainAxisSize.max,
                  children: [
                    const Padding(
                      padding: EdgeInsets.only(left: 18, bottom: 8),
                      child: Text(
                        "Name",
                        style: TextStyle(
                            color: DcColors.darkWhite, fontSize: 16, fontStyle: FontStyle.normal),
                      ),
                    ),
                    TextFormField(
                      controller: _userNameController,
                      autovalidateMode: AutovalidateMode.onUserInteraction,
                      validator: (value) => _getUserNameErrorText(value ?? ''),
                      style: const TextStyle(color: DcColors.darkWhite),
                    ),
                    const SizedBox(
                      height: 24,
                    ),
                    const Padding(
                      padding: EdgeInsets.only(left: 18, bottom: 8),
                      child: Text(
                        "E-mail",
                        style: TextStyle(
                            color: DcColors.darkWhite, fontSize: 16, fontStyle: FontStyle.normal),
                      ),
                    ),
                    TextFormField(
                      controller: _emailController,
                      autovalidateMode: AutovalidateMode.onUserInteraction,
                      validator: (value) => _getEmailErrorText(value ?? ''),
                      style: const TextStyle(color: DcColors.darkWhite),
                    ),
                    const Padding(
                      padding: EdgeInsets.only(left: 18, bottom: 8, top: 24),
                      child: Text(
                        "Password",
                        style: TextStyle(
                            color: DcColors.darkWhite, fontSize: 16, fontStyle: FontStyle.normal),
                      ),
                    ),
                    TextFormField(
                      controller: _passwordController,
                      autovalidateMode: AutovalidateMode.onUserInteraction,
                      validator: (value) => _getPasswordErrorText(value ?? ''),
                      style: const TextStyle(color: DcColors.darkWhite),
                    ),
                    const Padding(
                      padding: EdgeInsets.only(left: 18, bottom: 8, top: 24),
                      child: Text(
                        "Confirm password",
                        style: TextStyle(
                            color: DcColors.darkWhite, fontSize: 16, fontStyle: FontStyle.normal),
                      ),
                    ),
                    TextFormField(
                      controller: _confirmPasswordController,
                      autovalidateMode: AutovalidateMode.onUserInteraction,
                      validator: (value) =>
                          _getConfirmationPasswordErrorText(value ?? '', _passwordController.text),
                      style: const TextStyle(color: DcColors.darkWhite),
                    ),
                    const SizedBox(height: 64),
                    state is RegistratingState
                        ? const Center(
                            child: CircularProgressIndicator(),
                          )
                        : Padding(
                            padding: const EdgeInsets.all(8.0),
                            child: InkWell(
                              onTap: onRegistration,
                              child: Container(
                                height: 55.0,
                                decoration: BoxDecoration(
                                  borderRadius: BorderRadius.circular(25.0),
                                  color: DcColors.violet,
                                ),
                                child: Center(
                                    child: Text(
                                  "Create account",
                                  style: GoogleFonts.aBeeZee(
                                    fontSize: 24.0,
                                    color: const Color(0xFFE6E0D2),
                                  ),
                                )),
                              ),
                            ),
                          ),
                  ],
                ),
              ),
            ),
          ),
        ),
      ),
    );
  }

  void onBackPressed() {
    context.router.pop();
  }

  void onRegistration() {
    if (_formKey.currentState?.validate() ?? false) {
      final email = _emailController.text;
      final userName = _userNameController.text;
      final password = _passwordController.text;
      final confirmPassword = _confirmPasswordController.text;

      _bloc.add(RegistrationEvent(
          userName: userName, email: email, password: password, confirmPassword: confirmPassword));
    }
  }

  String? _getUserNameErrorText(String value) {
    if (value.isEmpty) {
      return "User name is can not be empty";
    }
    return null;
  }

  String? _getPasswordErrorText(String value) {
    if (value.isEmpty) {
      return 'Password can not be empty';
    } else if (value.length < 6) {
      return 'Password must have not less the 6 letters';
    } else {
      return null;
    }
  }

  String? _getConfirmationPasswordErrorText(String firstValue, String secondvalue) {
    if (firstValue.isEmpty) {
      return 'Confirm password can not be empty';
    } else if (firstValue != secondvalue) {
      return 'Password and confirm password must be equal';
    } else {
      return null;
    }
  }
}

String? _getEmailErrorText(String value) {
  bool emailValid = RegExp(r"^[a-zA-Z0-9.a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9]+\.[a-zA-Z]+")
      .hasMatch(value);
  if (value.isEmpty) {
    return "Email can not be empty";
  } else if (!emailValid) {
    return 'Invalid email';
  } else {
    return null;
  }
}
