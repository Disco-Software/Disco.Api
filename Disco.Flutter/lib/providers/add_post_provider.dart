import 'package:disco_app/data/network/network_models/create_post_model.dart';
import 'package:flutter/cupertino.dart';

class AddPostProvider extends ChangeNotifier {
  CreatePostModel currentCreatedPost = CreatePostModel(
    description: '',
    postSongImages: [],
    postVideos: [],
    postImages: [],
    postSongNames: [],
    postSongs: [],
  );

  void resetPost() {
    currentCreatedPost = CreatePostModel(
      description: '',
      postSongImages: [],
      postVideos: [],
      postImages: [],
      postSongNames: [],
      postSongs: [],
    );
  }
// int get currentCreatedPost => _currentCreatedPost;
//
// void setPost(String url) {
//   notifyListeners();
// }
}
