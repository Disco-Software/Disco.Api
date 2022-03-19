class PostVideo {
  String? videoSource;
  int? postId;
  int? id;

  PostVideo({this.videoSource, this.postId, this.id});

  PostVideo.fromJson(Map<String, dynamic> json) {
    videoSource = json['videoSource'];
    postId = json['postId'];
    id = json['id'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['videoSource'] = videoSource;
    data['postId'] = postId;
    data['id'] = id;
    return data;
  }
}
