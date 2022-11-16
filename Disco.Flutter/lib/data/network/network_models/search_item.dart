import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/data/network/network_models/account_network.dart';

class SearchItem {
  List<Post>? posts;
  List<Account>? users;

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
    if (json['accounts'] != null) {
      users = <Account>[];
      json['accounts'].forEach((v) {
        users!.add(Account.fromJson(v));
      });
    }
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    if (posts != null) {
      data['posts'] = posts!.map((v) => v.toJson()).toList();
    }
    if (users != null) {
      data['accounts'] = users!.map((v) => v.toJson()).toList();
    }
    return data;
  }
}
