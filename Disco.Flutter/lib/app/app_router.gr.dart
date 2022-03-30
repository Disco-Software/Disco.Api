// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// AutoRouteGenerator
// **************************************************************************

import 'package:auto_route/auto_route.dart' as _i1;
import 'package:flutter/material.dart' as _i2;

import '../pages/authentication/login/login_page.dart' as _i5;
import '../pages/authentication/registration/registration.dart' as _i7;
import '../pages/authentication/search_registration/search_registration_page.dart'
    as _i6;
import '../pages/start/splash_page.dart' as _i3;
import '../pages/start/start_page.dart' as _i4;
import '../pages/user/add_post/add_post_page.dart' as _i12;
import '../pages/user/chat/chat.dart' as _i13;
import '../pages/user/home_page.dart' as _i9;
import '../pages/user/main/main_page.dart' as _i10;
import '../pages/user/profile/profile.dart' as _i14;
import '../pages/user/saved/saved.dart' as _i11;
import '../pages/user/saved/saved_item_page/saved_item.dart' as _i8;

class AppRouter extends _i1.RootStackRouter {
  AppRouter([_i2.GlobalKey<_i2.NavigatorState>? navigatorKey])
      : super(navigatorKey);

  @override
  final Map<String, _i1.PageFactory> pagesMap = {
    SplashRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i3.SplashPage();
        }),
    StartRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i4.StartPage();
        }),
    LoginRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i5.LoginPage();
        }),
    SearchRegistrationRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i6.SearchRegistrationPage();
        }),
    RegistrationRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i7.RegistrationPage();
        }),
    SavedItemRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (data) {
          final pathParams = data.pathParams;
          final args = data.argsAs<SavedItemRouteArgs>(
              orElse: () =>
                  SavedItemRouteArgs(itemId: pathParams.getInt('itemId')));
          return _i8.SavedItem(key: args.key, itemId: args.itemId);
        }),
    HomeRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i9.HomePage();
        }),
    LineRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (data) {
          final args =
              data.argsAs<LineRouteArgs>(orElse: () => const LineRouteArgs());
          return _i10.MainPage(key: args.key);
        }),
    SavedItemsRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i11.SavedItemsPage();
        }),
    PostRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i12.AddPostPage();
        }),
    ChatRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i13.ChatPage();
        }),
    ProfileRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i14.ProfilePage();
        })
  };

  @override
  List<_i1.RouteConfig> get routes => [
        _i1.RouteConfig(SplashRoute.name, path: '/'),
        _i1.RouteConfig(StartRoute.name, path: '/start'),
        _i1.RouteConfig(LoginRoute.name, path: '/log-in'),
        _i1.RouteConfig(SearchRegistrationRoute.name, path: '/search'),
        _i1.RouteConfig(RegistrationRoute.name, path: '/registration'),
        _i1.RouteConfig(SavedItemRoute.name, path: ':itemId'),
        _i1.RouteConfig(HomeRoute.name, path: '/home', children: [
          _i1.RouteConfig(LineRoute.name, path: 'line'),
          _i1.RouteConfig(SavedItemsRoute.name, path: 'saved'),
          _i1.RouteConfig(PostRoute.name, path: 'post'),
          _i1.RouteConfig(ChatRoute.name, path: 'chat'),
          _i1.RouteConfig(ProfileRoute.name, path: 'profile')
        ])
      ];
}

class SplashRoute extends _i1.PageRouteInfo<void> {
  const SplashRoute() : super(name, path: '/');

  static const String name = 'SplashRoute';
}

class StartRoute extends _i1.PageRouteInfo<void> {
  const StartRoute() : super(name, path: '/start');

  static const String name = 'StartRoute';
}

class LoginRoute extends _i1.PageRouteInfo<void> {
  const LoginRoute() : super(name, path: '/log-in');

  static const String name = 'LoginRoute';
}

class SearchRegistrationRoute extends _i1.PageRouteInfo<void> {
  const SearchRegistrationRoute() : super(name, path: '/search');

  static const String name = 'SearchRegistrationRoute';
}

class RegistrationRoute extends _i1.PageRouteInfo<void> {
  const RegistrationRoute() : super(name, path: '/registration');

  static const String name = 'RegistrationRoute';
}

class SavedItemRoute extends _i1.PageRouteInfo<SavedItemRouteArgs> {
  SavedItemRoute({_i2.Key? key, required int itemId})
      : super(name,
            path: ':itemId',
            args: SavedItemRouteArgs(key: key, itemId: itemId),
            rawPathParams: {'itemId': itemId});

  static const String name = 'SavedItemRoute';
}

class SavedItemRouteArgs {
  const SavedItemRouteArgs({this.key, required this.itemId});

  final _i2.Key? key;

  final int itemId;
}

class HomeRoute extends _i1.PageRouteInfo<void> {
  const HomeRoute({List<_i1.PageRouteInfo>? children})
      : super(name, path: '/home', initialChildren: children);

  static const String name = 'HomeRoute';
}

class LineRoute extends _i1.PageRouteInfo<LineRouteArgs> {
  LineRoute({_i2.Key? key})
      : super(name, path: 'line', args: LineRouteArgs(key: key));

  static const String name = 'LineRoute';
}

class LineRouteArgs {
  const LineRouteArgs({this.key});

  final _i2.Key? key;
}

class SavedItemsRoute extends _i1.PageRouteInfo<void> {
  const SavedItemsRoute() : super(name, path: 'saved');

  static const String name = 'SavedItemsRoute';
}

class PostRoute extends _i1.PageRouteInfo<void> {
  const PostRoute() : super(name, path: 'post');

  static const String name = 'PostRoute';
}

class ChatRoute extends _i1.PageRouteInfo<void> {
  const ChatRoute() : super(name, path: 'chat');

  static const String name = 'ChatRoute';
}

class ProfileRoute extends _i1.PageRouteInfo<void> {
  const ProfileRoute() : super(name, path: 'profile');

  static const String name = 'ProfileRoute';
}
