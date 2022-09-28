import 'dart:async';

import 'package:disco_app/presentation/pages/user/main/bloc/stories_page_state.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class StoriesPageCubit extends Cubit<StoriesPageState> {
  StoriesPageCubit() : super(const StoriesPageStateInitial());

  StreamSubscription<int>? _tickerSubscription;
  final _Ticker _ticker = _Ticker();

  @override
  Future<void> close() {
    _tickerSubscription?.cancel();
    return super.close();
  }

  Future<void> startNewTimer(int storiesLength) async {
    emit(StoriesPageStateRunning(duration: storiesLength));

    _tickerSubscription?.cancel();
    _tickerSubscription = _ticker.tick(ticks: storiesLength).listen((duration) => emit(duration > 0
        ? StoriesPageStateRunning(duration: duration)
        : const StoriesPageStateFinished()));
  }
}

class _Ticker {
  Stream<int> tick({required int ticks}) {
    return Stream.periodic(const Duration(seconds: 3), (x) => ticks - x - 1).take(ticks);
  }
}
