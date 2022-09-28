import 'package:auto_route/auto_route.dart';
import 'package:dio/dio.dart';
import 'package:disco_admin_panel/core/app_router.gr.dart';
import 'package:disco_admin_panel/core/colors.dart';
import 'package:disco_admin_panel/data/local/secure_storage.dart';
import 'package:disco_admin_panel/data/network/repositories/user_repository.dart';
import 'package:disco_admin_panel/injection.dart';
import 'package:disco_admin_panel/presentation/pages/authentication/forgot_password/forgot_password.dart';
import 'package:disco_admin_panel/presentation/pages/authentication/login/bloc/login_bloc.dart';
import 'package:disco_admin_panel/presentation/pages/authentication/login/bloc/login_event.dart';
import 'package:disco_admin_panel/presentation/pages/authentication/login/bloc/login_state.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class LoginPage extends StatefulWidget implements AutoRouteWrapper {
  const LoginPage({Key? key}) : super(key: key);

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

  @override
  void dispose() {
    _emailController.dispose();
    _passwordController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    final Shader linearGradient = const LinearGradient(
      colors: <Color>[Color(0xffFFF170), Color(0xffDE871F)],
    ).createShader(const Rect.fromLTWH(0.0, 0.0, 200.0, 70.0));

    return Scaffold(
      backgroundColor: DcColors.loginBackground,
      body: Center(
        child: GestureDetector(
          onTap: () {
            FocusScope.of(context).unfocus();
          },
          child: Container(
            height: 580,
            width: 380,
            decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(8),
                color: Colors.white,
                gradient: const RadialGradient(
                  radius: 100,
                  colors: [
                    Color(0xFF2E1257),
                    Color(0xFF221338),
                  ],
                ),
                boxShadow: const [
                  BoxShadow(color: Color(0xFFB2A044FF), offset: Offset(0, 4), blurRadius: 7),
                ]),
            child: Form(
              key: _formKey,
              child: Column(
                children: [
                  const Spacer(),
                  Text(
                    "DISCO",
                    style: TextStyle(
                      fontSize: 72,
                      fontFamily: 'Colonna',
                      foreground: Paint()..shader = linearGradient,
                      shadows: const [
                        BoxShadow(
                          color: Color(0xFFa044ff),
                          offset: Offset(0, 4),
                          blurRadius: 7.0,
                          spreadRadius: 2.0,
                        ),
                      ],
                    ),
                    textAlign: TextAlign.start,
                  ),
                  const Spacer(flex: 2),
                  const Text(
                    'Log in',
                    style: TextStyle(
                      fontWeight: FontWeight.bold,
                      color: DcColors.darkWhite,
                      fontSize: 24,
                    ),
                  ),
                  const Spacer(flex: 2),
                  Padding(
                    padding: const EdgeInsets.symmetric(horizontal: 50.0),
                    child: Column(
                      children: [
                        const Align(
                            alignment: Alignment.bottomLeft,
                            child: Padding(
                              padding: EdgeInsets.only(bottom: 8, left: 15),
                              child: Text('E-mail', style: TextStyle(color: DcColors.darkWhite)),
                            )),
                        BlocBuilder<LoginBloc, LoginState>(
                          builder: (context, state) {
                            return TextFormField(
                              controller: _emailController,
                              autovalidateMode: AutovalidateMode.onUserInteraction,
                              style: const TextStyle(color: Colors.white),
                              validator: (value) => _onEmailValidate(_emailController.text),
                              decoration: InputDecoration(
                                  enabledBorder: OutlineInputBorder(
                                    borderSide: const BorderSide(color: DcColors.darkWhite),
                                    borderRadius: BorderRadius.circular(25),
                                  ),
                                  border:
                                      OutlineInputBorder(borderRadius: BorderRadius.circular(25)),
                                  errorText: state is LogInErrorState ? state.emailError : null),
                            );
                          },
                        ),
                      ],
                    ),
                  ),
                  const SizedBox(height: 24),
                  Padding(
                    padding: const EdgeInsets.symmetric(horizontal: 50.0),
                    child: Column(
                      children: [
                        const Align(
                            alignment: Alignment.bottomLeft,
                            child: Padding(
                              padding: EdgeInsets.only(bottom: 8, left: 15),
                              child: Text('Password', style: TextStyle(color: DcColors.darkWhite)),
                            )),
                        BlocBuilder<LoginBloc, LoginState>(
                          builder: (context, state) {
                            return TextFormField(
                              obscureText: true,
                              style: const TextStyle(color: Colors.white),
                              autovalidateMode: AutovalidateMode.onUserInteraction,
                              validator: (value) => _onPasswordValidate(_passwordController.text),
                              controller: _passwordController,
                              decoration: InputDecoration(
                                  enabledBorder: OutlineInputBorder(
                                    borderSide: const BorderSide(color: DcColors.darkWhite),
                                    borderRadius: BorderRadius.circular(25),
                                  ),
                                  border:
                                      OutlineInputBorder(borderRadius: BorderRadius.circular(25)),
                                  errorText: state is LogInErrorState ? state.passwordError : null),
                            );
                          },
                        ),
                      ],
                    ),
                  ),
                  const Spacer(),
                  BlocConsumer<LoginBloc, LoginState>(
                    listener: _blocListener,
                    builder: (context, state) {
                      return state is LoginingState
                          ? const Center(
                              child: CircularProgressIndicator(),
                            )
                          : SizedBox(
                              width: 192,
                              child:
                                  ElevatedButton(onPressed: _onLogin, child: const Text('Log In')),
                            );
                    },
                  ),
                  const Spacer(),
                  Center(
                    child: SizedBox(
                      height: 40,
                      child: TextButton(
                        onPressed: _onPasswordForgot,
                        child: const Text(
                          "Forgot your password",
                          textAlign: TextAlign.center,
                          style: TextStyle(
                            decoration: TextDecoration.underline,
                            color: DcColors.darkWhite,
                          ),
                        ),
                      ),
                    ),
                  ),
                  const Spacer(),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }

  void _onLogin() {
    if (_formKey.currentState?.validate() ?? false) {
      final email = _emailController.text;
      final password = _passwordController.text;
      context.read<LoginBloc>().add(LoginEvent(email: email, password: password));
    }
  }

  String? _onEmailValidate(String value) {
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

  void _onPasswordForgot() {
    showDialog(context: context, builder: (_) => const ForgotPassword());
  }

  String? _onPasswordValidate(String value) {
    if (value.isEmpty) {
      return 'Password is required';
    } else if (value.length < 6) {
      return 'Password must have more the 6 letters';
    } else {
      return null;
    }
  }

  void _blocListener(BuildContext context, Object? state) {
    WidgetsBinding.instance?.addPostFrameCallback((timeStamp) {
      if (state is LoggedInState) {
        context.router.pushAndPopUntil(const DashboardRoute(), predicate: (route) => false);
      }
    });
  }
}
