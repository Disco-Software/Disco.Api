import 'package:auto_route/annotations.dart';
import 'package:auto_route/auto_route.dart';
import 'package:disco_app/pages/authentication/login/login_page.dart';
import 'package:disco_app/pages/authentication/registration/registration.dart';
import 'package:disco_app/pages/authentication/search_registration/search_registration_page.dart';
import 'package:disco_app/pages/start/splash_page.dart';
import 'package:disco_app/pages/user/add_post/add_post_page.dart';
import 'package:disco_app/pages/user/add_post/record_audio_page.dart';
import 'package:disco_app/pages/user/add_post/select_files_page.dart';
import 'package:disco_app/pages/user/add_post/widgets/fullscreen_video.dart';
import 'package:disco_app/pages/user/chat/chat.dart';
import 'package:disco_app/pages/user/home_page.dart';
import 'package:disco_app/pages/user/main/main_page.dart';
import 'package:disco_app/pages/user/main/pages/stories/story_page.dart';
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
    AutoRoute(path: '/fullscreen-video', page: FullScreenVideoPage),
    AutoRoute(path: '/story', page: StoryPage),
    CustomRoute(
        path: '/story_anim',
        page: StoryPage,
        name: 'AnimatedStoryRoute',
        transitionsBuilder: TransitionsBuilders.fadeIn),
    // CustomRoute(
    //   path: '/story',
    //   page: StoryPage,
    //   transitionsBuilder: cubeTransition,
    //   name: 'StoryAnimatedRoute',
    // ),
    AutoRoute(
      path: ':itemId',
      page: SavedItem,
      name: 'SavedItemRoute',
    ),
    AutoRoute(path: '/home', page: HomePage, children: [
      AutoRoute(path: "feed", page: MainPage, name: 'FeedRoute'),
      AutoRoute(
        path: 'saved',
        page: SavedItemsPage,
        name: 'SavedItemsRoute',
      ),
      AutoRoute(
        path: 'addPost',
        name: 'AddPostRouter',
        page: EmptyRouterPage,
        children: [
          AutoRoute(path: '', page: AddPostPage),
          AutoRoute(path: 'record-audio', page: RecordAudioPage),
          AutoRoute(path: 'select-audio', page: SelectFilesPage),
        ],
      ),
      AutoRoute(path: "chat", page: ChatPage),
      AutoRoute(path: "profile", page: ProfilePage),
    ]),
  ],
)
// extend the generated private router
class $AppRouter {}
//
// Widget cubeTransition(BuildContext context, Animation<double> animation,
//     Animation<double> secondaryAnimation, Widget child) {
//   return Stack(
//     children: <Widget>[
//       SlideTransition(
//         position: Tween<Offset>(
//           begin: Offset.zero,
//           end: const Offset(-1.0, 0.0),
//         ).animate(animation),
//         child: Container(
//           color: Colors.white,
//           child: Transform(
//             transform: Matrix4.identity()
//               ..setEntry(3, 2, 0.003)
//               ..rotateY(pi / 2 * animation.value),
//             alignment: FractionalOffset.centerRight,
//             child: StoryPage(
//               index: context.findAncestorWidgetOfExactType<StoryPage>()?.index ?? 0,
//               totalLength: context.findAncestorWidgetOfExactType<StoryPage>()?.totalLength ?? 0,
//             ),
//           ),
//         ),
//       ),
//       SlideTransition(
//         position: Tween<Offset>(
//           begin: const Offset(1.0, 0.0),
//           end: Offset.zero,
//         ).animate(animation),
//         child: Container(
//           color: Colors.white,
//           child: Transform(
//             transform: Matrix4.identity()
//               ..setEntry(3, 2, 0.003)
//               ..rotateY(pi / 2 * (animation.value - 1)),
//             alignment: FractionalOffset.centerLeft,
//             child: child,
//           ),
//         ),
//       )
//     ],
//   );
// }
// // }
