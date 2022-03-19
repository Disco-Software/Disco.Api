// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// AutoRouteGenerator
// **************************************************************************

import 'package:auto_route/auto_route.dart' as _i1;
import 'package:flutter/material.dart' as _i2;

import '../pages/user/chat/chat.dart' as _i5;
import '../pages/user/home_page.dart' as _i3;
import '../pages/user/main/main_page.dart' as _i4;
import '../pages/user/profile/profile.dart' as _i6;
import '../pages/user/saved/saved.dart' as _i7;
import '../pages/user/saved/saved_item_page/saved_item.dart' as _i8;

class AppRouter extends _i1.RootStackRouter {
  AppRouter([_i2.GlobalKey<_i2.NavigatorState>? navigatorKey])
      : super(navigatorKey);

  @override
  final Map<String, _i1.PageFactory> pagesMap = {
    HomeRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i3.HomePage();
        }),
    MainRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i4.MainPage();
        }),
    EmptyRouterRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i1.EmptyRouterPage();
        }),
    ChatRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i5.ChatPage();
        }),
    ProfileRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i6.ProfilePage();
        }),
    SavedItemsRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i7.SavedItemsPage();
        }),
    SavedItem.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (data) {
          final pathParams = data.pathParams;
          final args = data.argsAs<SavedItemArgs>(
              orElse: () => SavedItemArgs(itemId: pathParams.getInt('itemId')));
          return _i8.SavedItem(key: args.key, itemId: args.itemId);
        })
  };

  @override
  List<_i1.RouteConfig> get routes => [
        _i1.RouteConfig(HomeRoute.name, path: '/', children: [
          _i1.RouteConfig(MainRoute.name, path: 'line'),
          _i1.RouteConfig(EmptyRouterRoute.name, path: 'saved', children: [
            _i1.RouteConfig(SavedItemsRoute.name, path: ''),
            _i1.RouteConfig(SavedItem.name, path: ':itemId')
          ]),
          _i1.RouteConfig(ChatRoute.name, path: 'chat'),
          _i1.RouteConfig(ProfileRoute.name, path: 'profile')
        ])
      ];
}

class HomeRoute extends _i1.PageRouteInfo<void> {
  const HomeRoute({List<_i1.PageRouteInfo>? children})
      : super(name, path: '/', initialChildren: children);

  static const String name = 'HomeRoute';
}

class MainRoute extends _i1.PageRouteInfo<void> {
  const MainRoute() : super(name, path: 'line');

  static const String name = 'MainRoute';
}

class EmptyRouterRoute extends _i1.PageRouteInfo<void> {
  const EmptyRouterRoute({List<_i1.PageRouteInfo>? children})
      : super(name, path: 'saved', initialChildren: children);

  static const String name = 'EmptyRouterRoute';
}

class ChatRoute extends _i1.PageRouteInfo<void> {
  const ChatRoute() : super(name, path: 'chat');

  static const String name = 'ChatRoute';
}

class ProfileRoute extends _i1.PageRouteInfo<void> {
  const ProfileRoute() : super(name, path: 'profile');

  static const String name = 'ProfileRoute';
}

class SavedItemsRoute extends _i1.PageRouteInfo<void> {
  const SavedItemsRoute() : super(name, path: '');

  static const String name = 'SavedItemsRoute';
}

class SavedItem extends _i1.PageRouteInfo<SavedItemArgs> {
  SavedItem({_i2.Key? key, required int itemId})
      : super(name,
            path: ':itemId',
            args: SavedItemArgs(key: key, itemId: itemId),
            rawPathParams: {'itemId': itemId});

  static const String name = 'SavedItem';
}

class SavedItemArgs {
  const SavedItemArgs({this.key, required this.itemId});

  final _i2.Key? key;

  final int itemId;
}
