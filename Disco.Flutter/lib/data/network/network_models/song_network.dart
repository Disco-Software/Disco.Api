class PostSong {
  String? imageUrl;
  String? source;
  int? postId;
  int? id;

  PostSong({this.imageUrl, this.source, this.postId, this.id});

  PostSong.fromJson(Map<String, dynamic> json) {
    imageUrl = json['imageUrl'];
    source = json['source'];
    postId = json['postId'];
    id = json['id'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['imageUrl'] = imageUrl;
    data['source'] = source;
    data['postId'] = postId;
    data['id'] = id;
    return data;
  }
}
