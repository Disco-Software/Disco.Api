import 'package:carousel_slider/carousel_controller.dart';
import 'package:disco_app/data/network/network_models/song_network.dart';
import 'package:flutter/cupertino.dart';
import 'package:just_audio/just_audio.dart';

class PostProvider extends ChangeNotifier {
  PostSong _currentPostSong = PostSong();

  final AudioPlayer _currentAudio = AudioPlayer();
  CarouselController _carouselController = CarouselController();
  String oldUrl = '';
  String _currentSinger = '';
  PostSong oldPost = PostSong();
  List<String> _songSources = [''];
  List<String> _songTitles = [''];
  int _currentSongIndex = 0;

  PostSong get post => _currentPostSong;

  AudioPlayer get player => _currentAudio;

  CarouselController get carouselController => _carouselController;

  String get singer => _currentSinger;

  List<String> get songSources => _songSources;

  List<String> get songTitles => _songTitles;

  int get currentSongIndex => _currentSongIndex;

  void setUrl(String url) {
    if (oldUrl.isNotEmpty && oldUrl == url) {
      if (_currentAudio.playerState.processingState == ProcessingState.idle) {
        _currentAudio.setUrl(url);
      }
      return;
    }
    oldUrl = url;

    _currentAudio.setUrl(url);
    notifyListeners();
  }

  void setPostSong(PostSong post) {
    if (oldPost.id != null && oldPost.id == post.id) {
      return;
    }
    oldPost = post;
    _currentPostSong = post;
    notifyListeners();
  }

  void setSinger(String singer) {
    _currentSinger = singer;
    notifyListeners();
  }

  void setAudioSources(List<String> songSources) {
    _songSources = songSources;
    notifyListeners();
  }

  void setAudioTitles(List<String> songTitles) {
    _songTitles = songTitles;
    notifyListeners();
  }

  void setCarouselController(CarouselController carouselController) {
    _carouselController = carouselController;
  }

  void setSongIndex(int index) {
    if (index >= 0) {
      _currentSongIndex = index;
    }
  }
}
