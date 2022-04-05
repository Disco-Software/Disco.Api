import 'package:auto_route/src/router/auto_router_x.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/data/network/api/auth_api.dart';
import 'package:disco_app/dialogs/forgot_password/forgot_password.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:get_it/get_it.dart';

import 'bloc/login_bloc.dart';
import 'bloc/login_event.dart';
import 'bloc/login_state.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({Key? key}) : super(key: key);
  static const routeName = "/log-in";

  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  final _bloc = LoginBloc(InitLoginState(), authApi: GetIt.I.get<AuthApi>());
  final _emailController = TextEditingController();
  final _passwordController = TextEditingController();
  final _formKey = GlobalKey<FormState>();

  @override
  void dispose() {
    _bloc.close();
    _emailController.dispose();
    _passwordController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<LoginBloc, LoginPageState>(
        bloc: _bloc,
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
                            style: const TextStyle(color: DcColors.darkWhite),
                            decoration: InputDecoration(
                                errorText: state is LogInErrorState
                                    ? state.emailError
                                    : null)),
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
                          obscureText: true,
                          controller: _passwordController,
                          decoration: InputDecoration(
                              errorText: state is LogInErrorState
                                  ? state.passwordError
                                  : null),
                        ),
                        const SizedBox(height: 34),
                        const Text(
                            'By continuing, you agree to accept our' +
                                'Privacy Policy & Terms of Service',
                            textAlign: TextAlign.center,
                            style: TextStyle(color: DcColors.darkWhite)),
                        const SizedBox(height: 50),
                        Center(
                          child: SizedBox(
                            width: 192,
                            child: state is LoginingState
                                ? const Center(
                                    child: CircularProgressIndicator.adaptive(),
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
        listener: _blocLisener);
  }

  void _blocLisener(BuildContext context, Object? state) {
    WidgetsBinding.instance?.addPostFrameCallback((timeStamp) {
      if (state is LoggedInState) {
        context.router.navigate(const HomeRoute());
      }
    });
  }

  void _onLogin() {
    if (_formKey.currentState?.validate() ?? false) {
      final email = _emailController.text;
      final password = _passwordController.text;
      _bloc.add(LoginEvent(email: email, password: password));
    }
  }

  void _onPasswordForgot() {
    showDialog(context: context, builder: (_) => const ForgotPassword());
  }
}
