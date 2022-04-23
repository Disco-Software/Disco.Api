import 'package:flutter/cupertino.dart';

abstract class MainPageEvent {}

class InitialEvent implements MainPageEvent {
  final int id;

  InitialEvent({required this.id});
}

class LoadPostsEvent implements MainPageEvent {
  final int id;
  final bool hasLoading;
  final VoidCallback onLoaded;

  LoadPostsEvent({
    required this.id,
    required this.hasLoading,
    required this.onLoaded,
  });
}

class ErrorEvent implements MainPageEvent {}
