import 'package:disco_app/data/network/network_models/post_network.dart';

abstract class SearchState {}

class InitialSearchState implements SearchState {}

class LoadingSearchState implements SearchState {}

class SuccessSearchState implements SearchState {
  List<Post> search;
  final bool hasLoading;

  SuccessSearchState({
    required this.search,
    required this.hasLoading,
  });
}

class ErrorSearchState implements SearchState {}
