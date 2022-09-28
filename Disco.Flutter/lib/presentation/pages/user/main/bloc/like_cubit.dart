import 'dart:developer' as developer;

import 'package:collection/collection.dart';
import 'package:disco_app/data/local/local_storage.dart';
import 'package:disco_app/data/network/network_models/like.dart';
import 'package:disco_app/data/network/repositories/post_repository.dart';
import 'package:disco_app/presentation/pages/user/main/bloc/like_state.dart';
import 'package:disco_app/res/strings.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:injectable/injectable.dart';

import '../../../../../injection.dart';
import 'like_state.dart';

@injectable
class LikeCubit extends Cubit<LikeState> {
  LikeCubit({required this.postRepository}) : super(const LikeState.initialNotSelected());

  final PostRepository postRepository;

  Future<void> init(List<Like>? likes) async {
    final userName = await getIt.get<SecureStorageRepository>().read(key: Strings.userName);
    final isPostSelected = likes?.firstWhereOrNull((element) {
          final likeUsername = element.userName ?? '';
          return likeUsername == userName;
        }) !=
        null;
    if (isPostSelected) {
      emit(const LikeState.initialSelected());
    } else {
      emit(const LikeState.initialNotSelected());
    }
  }

  Future<int?> like(int postId, List<Like>? likes) async {
    try {
      if (state is LikeStateInitialSelected) {
        final likes = await postRepository.removeLike(postId);
        emit(LikeState.notSelected(
          likes: likes ?? 0,
        ));
        return likes ?? 0;
      } else if (state is LikeStateInitialNotSelected) {
        final likes = await postRepository.addLike(postId);
        emit(LikeState.selected(
          likes: likes ?? 0,
        ));
        return likes ?? 0;
      } else if (state is LikeSelectedState) {
        final likes = await postRepository.removeLike(postId);
        emit(LikeState.notSelected(
          likes: likes ?? 0,
        ));
      } else if (state is LikeNotSelectedState) {
        final likes = await postRepository.addLike(postId);
        emit(LikeState.selected(
          likes: likes ?? 0,
        ));
      }
    } catch (err) {
      emit(const LikeState.error());
      developer.log('$err', name: 'Like cubit error');
    }
  }
}
