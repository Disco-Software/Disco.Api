import 'package:auto_route/annotations.dart';
import 'package:auto_route/auto_route.dart';
import 'package:disco_admin_panel/presentation/pages/authentication/login/login.dart';
import 'package:disco_admin_panel/presentation/pages/dashboard/dashboard_page.dart';

@MaterialAutoRouter(
  replaceInRouteName: 'Page,Route',
  routes: <AutoRoute>[
    // AutoRoute(path: '/', page: SplashPage, initial: true),
    AutoRoute(path: "/log-in", page: LoginPage, initial: true),
    AutoRoute(
      path: "/dashboard",
      page: DashboardPage,
    ),
  ],
)
// extend the generated private router
class $AppRouter {}
