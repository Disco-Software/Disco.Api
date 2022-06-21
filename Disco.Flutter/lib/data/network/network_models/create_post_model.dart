class CreatePostModel {
  String description;
  List<String> postImages;
  List<String> postSongs;
  List<String> postSongImages;
  List<String> postSongNames;
  List<String> postVideos;
  List<String> executorNames;

  CreatePostModel({
    required this.description,
    required this.postSongs,
    required this.postVideos,
    required this.postImages,
    required this.postSongImages,
    required this.postSongNames,
    required this.executorNames,
  });
}
