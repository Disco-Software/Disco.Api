import 'package:auto_route/annotations.dart';
import 'package:auto_route/auto_route.dart';
import 'package:disco_app/pages/user/chat/chat.dart';
import 'package:disco_app/pages/user/home_page.dart';
import 'package:disco_app/pages/user/main/main_page.dart';
import 'package:disco_app/pages/user/profile/profile.dart';
import 'package:disco_app/pages/user/saved/saved.dart';
import 'package:disco_app/pages/user/saved/saved_item_page/saved_item.dart';

@MaterialAutoRouter(
  replaceInRouteName: 'Page,Route',
  routes: <AutoRoute>[
    AutoRoute(path: '/', page: HomePage, initial: true, children: [
      AutoRoute(path: "line", page: MainPage),
      AutoRoute(path: "saved", page: EmptyRouterPage, children: [
        AutoRoute(path: "", page: SavedItemsPage),
        AutoRoute(path: ":itemId", page: SavedItem)
      ]),
      AutoRoute(path: "chat", page: ChatPage),
      AutoRoute(path: "profile", page: ProfilePage),
    ]),
    // AutoRoute(path: "/start", page: StartPage),
    // AutoRoute(path: "/log-in", page: LoginPage),
    // AutoRoute(path: "/search", page: SearchRegistrationPage),
    // AutoRoute(path: "/registration", page: RegistrationPage),
  ],
)
// extend the generated private router
class $AppRouter {}
