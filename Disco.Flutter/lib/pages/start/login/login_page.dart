import 'package:disco_app/pages/start/login/bloc/login_event.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'bloc/login_bloc.dart';
import 'bloc/login_state.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({Key? key}) : super(key: key);
  static const routeName = "/log-in";
  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  final _bloc = LoginBloc(InitLoginState());
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
    return BlocConsumer<LoginBloc, LoginPageState>(builder: (context,state){
      return Scaffold(body: Form(
        key: _formKey,
        child: Column(children: [
          TextFormField(
            controller: _emailController
          ),
          TextFormField(
            controller: _passwordController,
          ),
          const Text('By continuing, you agree to accept our' +
            'Privacy Policy & Terms of Service'),
          ElevatedButton(onPressed: _onLogin, child: const Text('Log In'))

        ],),
      ),);
    }, listener: _blocLisener);
  }

  void _blocLisener(BuildContext context, Object? state) {
  }

  void _onLogin() {
    if(_formKey.currentState?.validate()??false){
      final email = _emailController.text;
      final password = _passwordController.text;
      _bloc.add(LoginEvent(email: email, password: password));
    }
  }
}
