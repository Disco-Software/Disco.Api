import 'package:disco_app/data/network/network_models/search_item.dart';
import 'package:disco_app/data/network/repositories/search_repository.dart';
import 'package:disco_app/presentation/pages/search/bloc/search_page_state.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:injectable/injectable.dart';

import 'search_page_state.dart';

@injectable
class SearchItemCubit extends Cubit<SearchItemState> {
  SearchItemCubit({required this.searchRepository}) : super(InitialSearchItemState());

  final SearchRepository searchRepository;


  Future<void> search(String text) async {
    try {
      emit(LoadingSearchItemState());

      final items = await searchRepository.search(text);

      emit(SuccessSearchItemState(items: items ?? SearchItem()));
    } catch (err) {
      emit(ErrorSearchItemState());
      debugPrint('$err');
    }
  }
}
