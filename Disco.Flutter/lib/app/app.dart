import 'package:disco_app/pages/splash/splash_end_page.dart';
import 'package:disco_app/pages/splash/splash_page.dart';
import 'package:flutter/material.dart';

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        primarySwatch: Colors.orange,
      ),
      initialRoute: SplashPage.routeName,
      routes: {
        SplashPage.routeName: (_) => const SplashPage(),
        SplashEndPage.routeName: (_) => const SplashEndPage(),
      },
    );
  }
}
