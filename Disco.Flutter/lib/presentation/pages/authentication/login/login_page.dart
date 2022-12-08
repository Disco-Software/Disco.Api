import 'package:auto_route/auto_route.dart';
import 'package:dio/dio.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/data/local/local_storage.dart';
import 'package:disco_app/data/network/repositories/user_repository.dart';
import 'package:disco_app/injection.dart';
import 'package:disco_app/presentation/dialogs/forgot_password/forgot_password.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'bloc/login_bloc.dart';
import 'bloc/login_event.dart';
import 'bloc/login_state.dart';

class LoginPage extends StatefulWidget implements AutoRouteWrapper {
  const LoginPage({Key? key}) : super(key: key);
  static const routeName = "/log-in";

  @override
  State<LoginPage> createState() => _LoginPageState();

  @override
  Widget wrappedRoute(BuildContext context) {
    return BlocProvider(
      create: (_) => LoginBloc(
        userRepository: getIt.get<UserRepository>(),
        secureStorageRepository: getIt.get<SecureStorageRepository>(),
        dio: getIt.get<Dio>(),
      ),
      child: this,
    );
  }
}

class _LoginPageState extends State<LoginPage> {
  final _emailController = TextEditingController();
  final _passwordController = TextEditingController();
  final _formKey = GlobalKey<FormState>();
  bool _passwordVisible = false;

  @override
  void dispose() {
    _emailController.dispose();
    _passwordController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<LoginBloc, LoginPageState>(
        builder: (context, state) {
          return Scaffold(
            appBar: AppBar(
              backgroundColor: DcColors.darkViolet,
              leading: IconButton(
                icon: Image.asset("assets/back_button.png"),
                onPressed: () => Navigator.of(context).pop(),
              ),
              title: const Text(
                "Log in",
                style: TextStyle(fontSize: 32),
              ),
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
                child: Form(
                  key: _formKey,
                  child: SingleChildScrollView(
                    padding: const EdgeInsets.symmetric(horizontal: 70),
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.center,
                      crossAxisAlignment: CrossAxisAlignment.start,
                      mainAxisSize: MainAxisSize.max,
                      children: [
                        const Padding(
                          padding: EdgeInsets.only(
                            left: 18,
                            bottom: 8,
                          ),
                          child: Text(
                            "E-mail",
                            style: TextStyle(
                                fontSize: 16, color: DcColors.darkWhite),
                          ),
                        ),
                        TextFormField(
                          controller: _emailController,
                          autovalidateMode: AutovalidateMode.onUserInteraction,
                          validator: (value) =>
                              _onEmailValidate(_emailController.text),
                          style: const TextStyle(color: DcColors.darkWhite),
                          decoration: InputDecoration(
                              errorText: state is LogInErrorState
                                  ? state.emailError
                                  : null),
                        ),
                        const SizedBox(height: 24),
                        const Padding(
                          padding: EdgeInsets.only(
                            left: 18,
                            bottom: 8,
                          ),
                          child: Text(
                            "Password",
                            style: TextStyle(
                                fontSize: 16, color: DcColors.darkWhite),
                          ),
                        ),
                        TextFormField(
                          style: const TextStyle(color: DcColors.darkWhite),
                          obscureText: _passwordVisible,
                          autovalidateMode: AutovalidateMode.onUserInteraction,
                          validator: (value) =>
                              _onPasswordValidate(_passwordController.text),
                          controller: _passwordController,
                          decoration: InputDecoration(
                              errorText: state is LogInErrorState
                                  ? state.passwordError
                                  : null,
                              suffixIcon: IconButton(
                                icon: Icon(_passwordVisible
                                    ? CupertinoIcons.eye_slash
                                    : CupertinoIcons.eye),
                                color: DcColors.white,
                                onPressed: () {
                                  setState(() {
                                    _passwordVisible = !_passwordVisible;
                                  });
                                },
                              )),
                        ),
                        const SizedBox(height: 34),
                        const Text(
                            'By continuing, you agree to accept our Privacy Policy & Terms of Service',
                            textAlign: TextAlign.center,
                            style: TextStyle(color: DcColors.darkWhite)),
                        const SizedBox(height: 50),
                        Center(
                          child: SizedBox(
                            width: 192,
                            child: state is LoginingState
                                ? const Center(
                                    child: CircularProgressIndicator(),
                                  )
                                : ElevatedButton(
                                    onPressed: _onLogin,
                                    child: const Text('Log In')),
                          ),
                        ),
                        const SizedBox(
                          height: 30,
                        ),
                        Center(
                          child: SizedBox(
                            height: 40,
                            child: TextButton(
                                onPressed: _onPasswordForgot,
                                child: const Text("Forgot your password",
                                    textAlign: TextAlign.center,
                                    style: TextStyle(
                                      decoration: TextDecoration.underline,
                                      color: DcColors.darkWhite,
                                    ))),
                          ),
                        )
                      ],
                    ),
                  ),
                ),
              ),
            ),
          );
        },
        listener: _blocListener);
  }

  void _blocListener(BuildContext context, Object? state) {
    WidgetsBinding.instance?.addPostFrameCallback((timeStamp) {
      if (state is LoggedInState) {
        context.router
            .pushAndPopUntil(HomeRoute(), predicate: (route) => false);
      }
    });
  }

  void _onLogin() {
    if (_formKey.currentState?.validate() ?? false) {
      final email = _emailController.text;
      final password = _passwordController.text;
      context
          .read<LoginBloc>()
          .add(LoginEvent(email: email, password: password));
    }
  }

  String? _onEmailValidate(String value) {
    bool emailValid = RegExp(
            r"^[a-zA-Z0-9.a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9]+\.[a-zA-Z]+")
        .hasMatch(value);
    if (value.isEmpty) {
      return "Email can not be empty";
    } else if (!emailValid) {
      return 'Invalid email';
    } else {
      return null;
    }
  }

  void _onPasswordForgot() {
    showDialog(context: context, builder: (_) => const ForgotPassword());
  }

  String? _onPasswordValidate(String value) {
    if (value.isEmpty) {
      return 'Password is requared';
    } else if (value.length < 6) {
      return 'Password must have more the 6 letters';
    } else {
      return null;
    }
  }
}
