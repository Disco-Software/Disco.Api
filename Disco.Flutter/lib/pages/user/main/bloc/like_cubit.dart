import 'package:disco_app/data/network/repositories/post_repository.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:injectable/injectable.dart';

import 'like_state.dart';

@injectable
class LikeCubit extends Cubit<LikeState> {
  LikeCubit({required this.postRepository}) : super(const LikeState.initial());

  final PostRepository postRepository;

  Future<int?> addLike(int postId) async {
    try {
      // emit(const LikeState.loading());

      final likes = await postRepository.addLike(postId);

      emit(LikeState.success(
        likes: likes ?? 0,
      ));
      return likes ?? 0;
    } catch (err) {
      emit(const LikeState.error());
      debugPrint('$err');
    }
  }
}
