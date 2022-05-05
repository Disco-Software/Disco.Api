import 'package:disco_app/data/network/network_models/song_network.dart';
import 'package:flutter/cupertino.dart';
import 'package:just_audio/just_audio.dart';

class PostProvider extends ChangeNotifier {
  PostSong _currentPostSong = PostSong();
  final AudioPlayer _currentAudio = AudioPlayer();

  PostSong get post => _currentPostSong;

  void setUrl(String url) {
    _currentAudio.setUrl(url);
    notifyListeners();
  }

  void setPost(PostSong post) {
    _currentPostSong = post;
    notifyListeners();
  }
}
