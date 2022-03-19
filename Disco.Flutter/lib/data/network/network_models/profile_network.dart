import 'package:disco_app/data/network/network_models/friend_model.dart';
import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/data/network/network_models/user_network.dart';

class Profile {
  String? status;
  String? photo;
  List<Post>? posts;
  List<FriendModel>? friends;
  int? userId;
  User? user;
  int? id;

  Profile(
      {this.status,
      this.photo,
      this.posts,
      this.friends,
      this.userId,
      this.user,
      this.id});

  Profile.fromJson(Map<String, dynamic> json) {
    status = json['status'];
    photo = json['photo'];
    if (json['posts'] != null) {
      posts = <Post>[];
      json['posts'].forEach((v) {
        posts!.add(Post.fromJson(v));
      });
    }
    if (json['friends'] != null) {
      friends = <FriendModel>[];
      json['friends'].forEach((v) {
        friends!.add(FriendModel.fromJson(v));
      });
    }
    userId = json['userId'];
    user = json['user'] != null ? User.fromJson(json['user']) : null;
    id = json['id'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['status'] = status;
    data['photo'] = photo;
    if (posts != null) {
      data['posts'] = posts!.map((v) => v.toJson()).toList();
    }
    if (friends != null) {
      data['friends'] = friends!.map((v) => v.toJson()).toList();
    }
    data['userId'] = userId;
    if (user != null) {
      data['user'] = user!.toJson();
    }
    data['id'] = id;
    return data;
  }
}
