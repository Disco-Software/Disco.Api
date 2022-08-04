import 'package:disco_app/data/network/network_models/create_post_model.dart';
import 'package:disco_app/data/network/repositories/post_repository.dart';
import 'package:disco_app/injection.dart';
import 'package:flutter/cupertino.dart';

class AddPostProvider extends ChangeNotifier {
  CreatePostModel currentCreatedPost = CreatePostModel(
    description: '',
    postSongImages: [],
    postVideos: [],
    postImages: [],
    postSongNames: [],
    postSongs: [],
    executorNames: [],
  );

  void resetPost() {
    currentCreatedPost = CreatePostModel(
      description: '',
      postSongImages: [],
      postVideos: [],
      postImages: [],
      postSongNames: [],
      postSongs: [],
      executorNames: [],
    );
    notifyListeners();
  }

  void setSongImages(String image, int index) {
    currentCreatedPost.postSongImages[index] = image;
    notifyListeners();
  }

  void editSongTexts({required String name, required String executor, required int index}) {
    currentCreatedPost.postSongNames[index] = name;
    currentCreatedPost.executorNames[index] = executor;
    notifyListeners();
  }

  Future<void> createPost() async {
    await getIt.get<PostRepository>().createPost(currentCreatedPost);
  }
}
