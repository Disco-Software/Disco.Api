import 'package:auto_route/src/router/auto_router_x.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/pages/authentication/registration/bloc/registration_event.dart';
import 'package:disco_app/pages/authentication/registration/bloc/registration_state.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'bloc/registration_bloc.dart';

class RegistrationPage extends StatefulWidget {
  const RegistrationPage({Key? key}) : super(key: key);
  static const routeName = '/registration';

  @override
  _RegistrationPageState createState() => _RegistrationPageState();
}

class _RegistrationPageState extends State<RegistrationPage> {
  final _formKey = GlobalKey<FormState>();
  final _bloc = RegistrationBloc(InitialState());
  final _userNameController = TextEditingController();
  final _emailController = TextEditingController();
  final _passwordController = TextEditingController();
  final _confirmPasswordController = TextEditingController();

  void _blocLisener(BuildContext context, Object? state) {
    WidgetsBinding.instance?.addPostFrameCallback((timeStamp) {
      if (state is RegistratedState) {
        context.router.navigate(const HomeRoute());
      }
    });
  }

  @override
  void dispose() {
    _bloc.close();
    _emailController.dispose();
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
                      decoration: InputDecoration(
                          errorText: state is RegistrationErrorState ? state.userName : null),
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
                      decoration: InputDecoration(
                          errorText: state is RegistrationErrorState ? state.email : null),
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
                      decoration: InputDecoration(
                          errorText: state is RegistrationErrorState ? state.password : null),
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
                      decoration: InputDecoration(
                          errorText:
                              state is RegistrationErrorState ? state.confirmPassword : null),
                      style: const TextStyle(color: DcColors.darkWhite),
                    ),
                    Center(
                        child: SizedBox(
                            width: double.infinity,
                            child: Padding(
                              padding: const EdgeInsets.only(top: 64, left: 29, right: 29),
                              child: state is RegistratingState
                                  ? const Center(
                                      child: CircularProgressIndicator.adaptive(),
                                    )
                                  : ElevatedButton(
                                      onPressed: onRegistration,
                                      child: const Text("Create account"),
                                    ),
                            ))),
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
}
