import 'package:disco_app/pages/splash/splash_end_page.dart';
import 'package:flutter/material.dart';

class SplashPage extends StatefulWidget {
  const SplashPage({Key? key}) : super(key: key);

  static const routeName = '/splash';

  @override
  _SplashPageState createState() => _SplashPageState();
}

class _SplashPageState extends State<SplashPage> {
  @override
  void initState() {
    super.initState();
    Future.delayed(const Duration(milliseconds: 300)).then((value) {
      Navigator.of(context).pushReplacementNamed(SplashEndPage.routeName);
    });
  }

  @override
  Widget build(BuildContext context) {
    return const Scaffold(
      body: Center(child: Text('Splash')),
    );
  }
}
