import 'package:disco_app/data/network/network_models/search_item.dart';

abstract class SearchItemState {}

class InitialSearchItemState implements SearchItemState {}

class LoadingSearchItemState implements SearchItemState {}

class SuccessSearchItemState implements SearchItemState {
  SearchItem items;

  SuccessSearchItemState({
    required this.items,
  });
}

class ErrorSearchItemState implements SearchItemState {}
