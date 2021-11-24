import 'package:flutter/material.dart';

class StartPage extends StatelessWidget {
  const StartPage({Key? key}) : super(key: key);

  static const routeName = '/start';

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
         height: double.infinity,
         width: double.infinity,
         color: const Color(0xFF29193E),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.center,
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
          Image.asset("assets/logo.png"),
          OutlinedButton(onPressed: _onLogin, child: const Text("Log In")),
          TextButton(onPressed: _onRegistration, child: const Text("Registration")),
        ],
        ),
      ),
    );
  }

  void _onLogin() {
  }

  void _onRegistration() {
  }
}
