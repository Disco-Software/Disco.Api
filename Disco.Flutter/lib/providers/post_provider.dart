import 'package:disco_app/data/network/network_models/song_network.dart';
import 'package:flutter/cupertino.dart';
import 'package:just_audio/just_audio.dart';

class PostProvider extends ChangeNotifier {
  PostSong _currentPostSong = PostSong();
  final AudioPlayer _currentAudio = AudioPlayer();
  String oldUrl = '';
  String _currentSinger = '';
  PostSong oldPost = PostSong();

  PostSong get post => _currentPostSong;

  AudioPlayer get player => _currentAudio;

  String get singer => _currentSinger;

  void setUrl(String url) {
    if (oldUrl.isNotEmpty && oldUrl == url) {
      return;
    }
    oldUrl = url;

    _currentAudio.setUrl(url);
    notifyListeners();
  }

  void setPost(PostSong post) {
    if (oldPost.id != null && oldPost.id == post.id) {
      return;
    }
    oldPost = post;
    _currentPostSong = post;
    notifyListeners();
  }

  void setSinger(String singer) {
    _currentSinger = singer;
  }
}
