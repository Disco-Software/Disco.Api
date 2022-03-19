import 'package:disco_app/data/network/network_models/post_network.dart';

class PostModel {
  Post? post;
  String? varificationResult;

  PostModel({this.post, this.varificationResult});

  PostModel.fromJson(Map<String, dynamic> json) {
    post = json['post'] != null ? Post.fromJson(json['post']) : null;
    varificationResult = json['varificationResult'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    if (post != null) {
      data['post'] = post!.toJson();
    }
    data['varificationResult'] = varificationResult;
    return data;
  }
}
