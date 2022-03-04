import 'package:disco_app/app/router.dart';
import 'package:disco_app/pages/start/splash_page.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      onGenerateRoute: AppRouter.generateRoute,
      initialRoute: SplashPage.routeName,
      title: 'Flutter Demo',
      theme: ThemeData.dark().copyWith(
        inputDecorationTheme: InputDecorationTheme(
            border: OutlineInputBorder(
                borderSide: BorderSide(color: DcColors.white, width: 2),
                borderRadius: BorderRadius.circular(25))),
        textTheme: GoogleFonts.aBeeZeeTextTheme(),
        textButtonTheme: TextButtonThemeData(
          style: TextButton.styleFrom(
            primary: DcColors.darkWhite,
            textStyle: const TextStyle(
                fontSize: 18, decoration: TextDecoration.underline),
          ),
        ),
        floatingActionButtonTheme: const FloatingActionButtonThemeData(
          foregroundColor: DcColors.floatingActionButtonColor,
          splashColor: Colors.transparent,
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
        ),
        elevatedButtonTheme: ElevatedButtonThemeData(
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
    );
  }
}
