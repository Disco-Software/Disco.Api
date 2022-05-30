import 'package:auto_route/annotations.dart';
import 'package:auto_route/auto_route.dart';
import 'package:disco_app/pages/authentication/login/login_page.dart';
import 'package:disco_app/pages/authentication/registration/registration.dart';
import 'package:disco_app/pages/authentication/search_registration/search_registration_page.dart';
import 'package:disco_app/pages/start/splash_page.dart';
import 'package:disco_app/pages/user/add_post/add_post_page.dart';
import 'package:disco_app/pages/user/chat/chat.dart';
import 'package:disco_app/pages/user/home_page.dart';
import 'package:disco_app/pages/user/main/main_page.dart';
import 'package:disco_app/pages/user/profile/profile.dart';
import 'package:disco_app/pages/user/saved/saved.dart';
import 'package:disco_app/pages/user/saved/saved_item_page/saved_item.dart';

@MaterialAutoRouter(
  replaceInRouteName: 'Page,Route',
  routes: <AutoRoute>[
    AutoRoute(path: '/', page: SplashPage, initial: true),
    AutoRoute(path: "/log-in", page: LoginPage),
    AutoRoute(path: "/search", page: SearchRegistrationPage),
    AutoRoute(path: "/registration", page: RegistrationPage),
    AutoRoute(path: "/create-post", page: AddPostPage, name: 'PostRoute'),
    AutoRoute(
      path: ':itemId',
      page: SavedItem,
      name: 'SavedItemRoute',
    ),
    AutoRoute(path: '/home', page: HomePage, children: [
      AutoRoute(path: "line", page: MainPage, name: 'LineRoute'),
      AutoRoute(
        path: 'saved',
        page: SavedItemsPage,
        name: 'SavedItemsRoute',
      ),
      AutoRoute(path: "empty_add_post", page: EmptyRouterPage, name: 'EmptyAddPostRoute'),
      AutoRoute(path: "chat", page: ChatPage),
      AutoRoute(path: "profile", page: ProfilePage),
    ]),
  ],
)
// extend the generated private router
class $AppRouter {}
