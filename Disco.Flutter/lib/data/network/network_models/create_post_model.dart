class CreatePostModel {
  String description;
  List<String> postImages;
  List<String> postSongs;
  List<String> postSongImages;
  List<String> postSongNames;
  List<String> postVideos;

  CreatePostModel({
    required this.description,
    required this.postSongs,
    required this.postVideos,
    required this.postImages,
    required this.postSongImages,
    required this.postSongNames,
  });
}
