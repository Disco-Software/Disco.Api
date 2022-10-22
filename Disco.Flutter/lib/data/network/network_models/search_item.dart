import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/data/network/network_models/profile_network.dart';

class SearchItem {
  List<Post>? posts;
  List<Profile>? users;

  SearchItem({
    this.posts,
    this.users,
  });

  SearchItem.fromJson(Map<String, dynamic> json) {
    if (json['posts'] != null) {
      posts = <Post>[];
      json['posts'].forEach((v) {
        posts!.add(Post.fromJson(v));
      });
    }
    if (json['profile'] != null) {
      users = <Profile>[];
      json['profile'].forEach((v) {
        users!.add(Profile.fromJson(v));
      });
    }
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    if (posts != null) {
      data['posts'] = posts!.map((v) => v.toJson()).toList();
    }
    if (users != null) {
      data['profile'] = users!.map((v) => v.toJson()).toList();
    }
    return data;
  }
}
