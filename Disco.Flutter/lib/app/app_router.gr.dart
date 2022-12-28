// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// AutoRouteGenerator
// **************************************************************************

import 'package:auto_route/auto_route.dart' as _i1;
import 'package:flutter/material.dart' as _i2;
import 'package:video_player/video_player.dart' as _i20;

import '../presentation/pages/authentication/login/login_page.dart' as _i4;
import '../presentation/pages/authentication/registration/registration.dart'
    as _i6;
import '../presentation/pages/authentication/search_registration/search_registration_page.dart'
    as _i5;
import '../presentation/pages/search/search_page.dart' as _i9;
import '../presentation/pages/start/splash_page.dart' as _i3;
import '../presentation/pages/user/add_post/add_post_page.dart' as _i17;
import '../presentation/pages/user/add_post/record_audio_page.dart' as _i18;
import '../presentation/pages/user/add_post/select_files_page.dart' as _i19;
import '../presentation/pages/user/add_post/widgets/fullscreen_video.dart'
    as _i7;
import '../presentation/pages/user/chat/chat.dart' as _i15;
import '../presentation/pages/user/home_page.dart' as _i12;
import '../presentation/pages/user/main/main_page.dart' as _i13;
import '../presentation/pages/user/main/pages/stories/story_page.dart' as _i10;
import '../presentation/pages/user/profile/profile_page.dart' as _i16;
import '../presentation/pages/user/profile/user_profile_page.dart' as _i8;
import '../presentation/pages/user/saved/saved.dart' as _i14;
import '../presentation/pages/user/saved/saved_item_page/saved_item.dart'
    as _i11;

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
    LoginRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i4.LoginPage();
        }),
    SearchRegistrationRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i5.SearchRegistrationPage();
        }),
    RegistrationRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i6.RegistrationPage();
        }),
    FullScreenVideoRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (data) {
          final args = data.argsAs<FullScreenVideoRouteArgs>();
          return _i7.FullScreenVideoPage(
              key: args.key, source: args.source, controller: args.controller);
        }),
    UserProfileRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (data) {
          final args = data.argsAs<UserProfileRouteArgs>();
          return _i8.UserProfilePage(key: args.key, userId: args.userId);
        }),
    SearchRoute.name: (routeData) => _i1.CustomPage<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i9.SearchPage();
        },
        transitionsBuilder: _i1.TransitionsBuilders.fadeIn,
        durationInMilliseconds: 800,
        reverseDurationInMilliseconds: 500,
        opaque: true,
        barrierDismissible: false),
    StoryRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (data) {
          final args = data.argsAs<StoryRouteArgs>();
          return _i10.StoryPage(
              index: args.index, totalLength: args.totalLength, key: args.key);
        }),
    AnimatedStoryRoute.name: (routeData) => _i1.CustomPage<dynamic>(
        routeData: routeData,
        builder: (data) {
          final args = data.argsAs<AnimatedStoryRouteArgs>();
          return _i10.StoryPage(
              index: args.index, totalLength: args.totalLength, key: args.key);
        },
        transitionsBuilder: _i1.TransitionsBuilders.fadeIn,
        opaque: true,
        barrierDismissible: false),
    SavedItemRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (data) {
          final pathParams = data.pathParams;
          final args = data.argsAs<SavedItemRouteArgs>(
              orElse: () =>
                  SavedItemRouteArgs(itemId: pathParams.getInt('itemId')));
          return _i11.SavedItem(key: args.key, itemId: args.itemId);
        }),
    HomeRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (data) {
          final args =
              data.argsAs<HomeRouteArgs>(orElse: () => const HomeRouteArgs());
          return _i12.HomePage(
              key: args.key, shouldLoadData: args.shouldLoadData);
        }),
    FeedRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i13.MainPage();
        }),
    SavedItemsRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i14.SavedItemsPage();
        }),
    AddPostRouter.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i1.EmptyRouterPage();
        }),
    ChatRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i15.ChatPage();
        }),
    ProfileRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i16.ProfilePage();
        }),
    AddPostRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i17.AddPostPage();
        }),
    RecordAudioRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i18.RecordAudioPage();
        }),
    SelectFilesRoute.name: (routeData) => _i1.MaterialPageX<dynamic>(
        routeData: routeData,
        builder: (_) {
          return const _i19.SelectFilesPage();
        })
  };

  @override
  List<_i1.RouteConfig> get routes => [
        _i1.RouteConfig(SplashRoute.name, path: '/'),
        _i1.RouteConfig(LoginRoute.name, path: '/log-in'),
        _i1.RouteConfig(SearchRegistrationRoute.name, path: '/search'),
        _i1.RouteConfig(RegistrationRoute.name, path: '/registration'),
        _i1.RouteConfig(FullScreenVideoRoute.name, path: '/fullscreen-video'),
        _i1.RouteConfig(UserProfileRoute.name, path: '/follower-account'),
        _i1.RouteConfig(SearchRoute.name, path: '/search_page'),
        _i1.RouteConfig(StoryRoute.name, path: '/story'),
        _i1.RouteConfig(AnimatedStoryRoute.name, path: '/story_anim'),
        _i1.RouteConfig(SavedItemRoute.name, path: ':itemId'),
        _i1.RouteConfig(HomeRoute.name, path: '/home', children: [
          _i1.RouteConfig(FeedRoute.name, path: 'feed'),
          _i1.RouteConfig(SavedItemsRoute.name, path: 'saved'),
          _i1.RouteConfig(AddPostRouter.name, path: 'addPost', children: [
            _i1.RouteConfig(AddPostRoute.name, path: ''),
            _i1.RouteConfig(RecordAudioRoute.name, path: 'record-audio'),
            _i1.RouteConfig(SelectFilesRoute.name, path: 'select-audio')
          ]),
          _i1.RouteConfig(ChatRoute.name, path: 'chat'),
          _i1.RouteConfig(ProfileRoute.name, path: 'profile')
        ])
      ];
}

class SplashRoute extends _i1.PageRouteInfo<void> {
  const SplashRoute() : super(name, path: '/');

  static const String name = 'SplashRoute';
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

class FullScreenVideoRoute extends _i1.PageRouteInfo<FullScreenVideoRouteArgs> {
  FullScreenVideoRoute(
      {_i2.Key? key,
      required String source,
      required _i20.VideoPlayerController controller})
      : super(name,
            path: '/fullscreen-video',
            args: FullScreenVideoRouteArgs(
                key: key, source: source, controller: controller));

  static const String name = 'FullScreenVideoRoute';
}

class FullScreenVideoRouteArgs {
  const FullScreenVideoRouteArgs(
      {this.key, required this.source, required this.controller});

  final _i2.Key? key;

  final String source;

  final _i20.VideoPlayerController controller;
}

class UserProfileRoute extends _i1.PageRouteInfo<UserProfileRouteArgs> {
  UserProfileRoute({_i2.Key? key, required int userId})
      : super(name,
            path: '/follower-account',
            args: UserProfileRouteArgs(key: key, userId: userId));

  static const String name = 'UserProfileRoute';
}

class UserProfileRouteArgs {
  const UserProfileRouteArgs({this.key, required this.userId});

  final _i2.Key? key;

  final int userId;
}

class SearchRoute extends _i1.PageRouteInfo<void> {
  const SearchRoute() : super(name, path: '/search_page');

  static const String name = 'SearchRoute';
}

class StoryRoute extends _i1.PageRouteInfo<StoryRouteArgs> {
  StoryRoute({required int index, required int totalLength, _i2.Key? key})
      : super(name,
            path: '/story',
            args: StoryRouteArgs(
                index: index, totalLength: totalLength, key: key));

  static const String name = 'StoryRoute';
}

class StoryRouteArgs {
  const StoryRouteArgs(
      {required this.index, required this.totalLength, this.key});

  final int index;

  final int totalLength;

  final _i2.Key? key;
}

class AnimatedStoryRoute extends _i1.PageRouteInfo<AnimatedStoryRouteArgs> {
  AnimatedStoryRoute(
      {required int index, required int totalLength, _i2.Key? key})
      : super(name,
            path: '/story_anim',
            args: AnimatedStoryRouteArgs(
                index: index, totalLength: totalLength, key: key));

  static const String name = 'AnimatedStoryRoute';
}

class AnimatedStoryRouteArgs {
  const AnimatedStoryRouteArgs(
      {required this.index, required this.totalLength, this.key});

  final int index;

  final int totalLength;

  final _i2.Key? key;
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

class HomeRoute extends _i1.PageRouteInfo<HomeRouteArgs> {
  HomeRoute(
      {_i2.Key? key,
      bool shouldLoadData = true,
      List<_i1.PageRouteInfo>? children})
      : super(name,
            path: '/home',
            args: HomeRouteArgs(key: key, shouldLoadData: shouldLoadData),
            initialChildren: children);

  static const String name = 'HomeRoute';
}

class HomeRouteArgs {
  const HomeRouteArgs({this.key, this.shouldLoadData = true});

  final _i2.Key? key;

  final bool shouldLoadData;
}

class FeedRoute extends _i1.PageRouteInfo<void> {
  const FeedRoute() : super(name, path: 'feed');

  static const String name = 'FeedRoute';
}

class SavedItemsRoute extends _i1.PageRouteInfo<void> {
  const SavedItemsRoute() : super(name, path: 'saved');

  static const String name = 'SavedItemsRoute';
}

class AddPostRouter extends _i1.PageRouteInfo<void> {
  const AddPostRouter({List<_i1.PageRouteInfo>? children})
      : super(name, path: 'addPost', initialChildren: children);

  static const String name = 'AddPostRouter';
}

class ChatRoute extends _i1.PageRouteInfo<void> {
  const ChatRoute() : super(name, path: 'chat');

  static const String name = 'ChatRoute';
}

class ProfileRoute extends _i1.PageRouteInfo<void> {
  const ProfileRoute() : super(name, path: 'profile');

  static const String name = 'ProfileRoute';
}

class AddPostRoute extends _i1.PageRouteInfo<void> {
  const AddPostRoute() : super(name, path: '');

  static const String name = 'AddPostRoute';
}

class RecordAudioRoute extends _i1.PageRouteInfo<void> {
  const RecordAudioRoute() : super(name, path: 'record-audio');

  static const String name = 'RecordAudioRoute';
}

class SelectFilesRoute extends _i1.PageRouteInfo<void> {
  const SelectFilesRoute() : super(name, path: 'select-audio');

  static const String name = 'SelectFilesRoute';
}
