import 'package:flutter/material.dart';

class SplashEndPage extends StatelessWidget {
  const SplashEndPage({Key? key}) : super(key: key);

  static const routeName = '/splash-end';

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: Container(
          color: Colors.red,
          child: const Text('Splash end'),
        ),
      ),
    );
  }
}
