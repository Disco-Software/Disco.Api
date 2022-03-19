class PostImage {
  String? source;
  int? postId;
  int? id;

  PostImage({this.source, this.postId, this.id});

  PostImage.fromJson(Map<String, dynamic> json) {
    source = json['source'];
    postId = json['postId'];
    id = json['id'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['source'] = source;
    data['postId'] = postId;
    data['id'] = id;
    return data;
  }
}
