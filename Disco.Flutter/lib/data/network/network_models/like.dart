import 'package:disco_app/data/network/network_models/post_network.dart';

class Like {
  String? userName;
  int? postId;
  Post? post;
  int? id;

  Like({this.userName, this.postId, this.id, this.post});

  Like.fromJson(Map<String, dynamic> json) {
    userName = json['userName'];
    postId = json['postId'];
    post = json['post'];
    id = json['id'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['userName'] = userName;
    data['postId'] = postId;
    data['post'] = post;
    data['id'] = id;
    return data;
  }
}
