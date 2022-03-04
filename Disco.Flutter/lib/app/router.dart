import 'package:disco_app/pages/authentication/login/login_page.dart';
import 'package:disco_app/pages/authentication/registration/registration.dart';
import 'package:disco_app/pages/authentication/search_registration/search_registration_page.dart';
import 'package:disco_app/pages/start/splash_page.dart';
import 'package:disco_app/pages/start/start_page.dart';
import 'package:disco_app/pages/user/main/main_page.dart';
import 'package:flutter/material.dart';

class AppRouter {
  static Route<dynamic> generateRoute(RouteSettings settings) {
    switch (settings.name) {
      case SplashPage.routeName:
        return MaterialPageRoute(builder: (_) => const SplashPage());
      case StartPage.routeName:
        return MaterialPageRoute(builder: (_) => const StartPage());
      case LoginPage.routeName:
        return MaterialPageRoute(builder: (_) => const LoginPage());
      case SearchRegistrationPage.routeName:
        return MaterialPageRoute(
            builder: (_) => const SearchRegistrationPage());
      case RegistrationPage.routeName:
        return MaterialPageRoute(builder: (_) => const RegistrationPage());
      case MainPage.route:
        return MaterialPageRoute(builder: (_) => const MainPage());
      default:
        return MaterialPageRoute(
            builder: (_) => Scaffold(
                  body: Center(
                    child: Text('this route not found ${settings.name}'),
                  ),
                ));
    }
  }
}
