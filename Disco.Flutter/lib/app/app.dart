import 'package:disco_app/pages/start/login/login_page.dart';
import 'package:disco_app/pages/start/splash_page.dart';
import 'package:disco_app/pages/start/start_page.dart';
import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:disco_app/res/colors.dart';
class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData.dark().copyWith(
        inputDecorationTheme:  InputDecorationTheme(border:  OutlineInputBorder(borderSide: BorderSide(color: DcColors.white, width: 2), borderRadius: BorderRadius.circular(25))),
        textTheme: GoogleFonts.aBeeZeeTextTheme(),
        textButtonTheme: TextButtonThemeData(
          style: TextButton.styleFrom(
            primary: DcColors.darkWhite,
            textStyle: const TextStyle(
                fontSize: 18, decoration: TextDecoration.underline),
          ),
        ),
        outlinedButtonTheme: OutlinedButtonThemeData(
          style: OutlinedButton.styleFrom(
            padding: EdgeInsets.zero,
            textStyle: const TextStyle(fontSize: 24),
            primary: DcColors.white,
            side: const BorderSide(width: 2, color: DcColors.white),
            minimumSize: const Size(100, 56),
            shape: const RoundedRectangleBorder(
              borderRadius: BorderRadius.all(
                Radius.circular(24),
              ),
            ),
          ),
        ), elevatedButtonTheme: ElevatedButtonThemeData(
        style: ElevatedButton.styleFrom(
          padding: EdgeInsets.zero,
          textStyle: const TextStyle(fontSize: 24),
          primary: DcColors.violet,
          minimumSize: const Size(100, 56),
          shape: const RoundedRectangleBorder(
            borderRadius: BorderRadius.all(
              Radius.circular(24),
            ),
          ),
        ),
      ),
      ),
      initialRoute: SplashPage.routeName,
      routes: {
        SplashPage.routeName: (_) => const SplashPage(),
        StartPage.routeName: (_) => const StartPage(),
        LoginPage.routeName: (_) => const LoginPage(),
      },
    );
  }
}