import 'package:disco_app/data/network/network_models/friend_model.dart';
import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/data/network/network_models/user_network.dart';

class Profile {
  String? status;
  String? photo;
  List<Post>? posts;
  List<FriendModel>? followers;
  List<FriendModel>? following;
  int? userId;
  User? user;
  int? id;

  Profile(
      {this.status,
      this.photo,
      this.posts,
      this.followers,
      this.following,
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
    if (json['followers'] != null) {
      followers = <FriendModel>[];
      json['followers'].forEach((v) {
        followers!.add(FriendModel.fromJson(v));
      });
    }
    if (json['following'] != null) {
      following = <FriendModel>[];
      json['following'].forEach((v) {
        following!.add(FriendModel.fromJson(v));
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
    if (followers != null) {
      data['followers'] = followers!.map((v) => v.toJson()).toList();
    }
    if (following != null) {
      data['following'] = following!.map((v) => v.toJson()).toList();
    }
    data['userId'] = userId;
    if (user != null) {
      data['user'] = user!.toJson();
    }
    data['id'] = id;
    return data;
  }
}
