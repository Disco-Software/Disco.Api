import 'dart:developer';

import 'package:disco_app/data/network/network_models/friend_model.dart';
import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/data/network/network_models/status_model.dart';
import 'package:disco_app/data/network/network_models/user_network.dart';

class Account {
  StatusModel? status;
  String? photo;
  String? creed;
  List<Post>? posts;
  List<FriendModel>? followers;
  List<FriendModel>? following;
  int? userId;
  User? user;
  int? id;

  Account(
      {this.status,
      this.photo,
      this.posts,
      this.followers,
      this.following,
      this.userId,
      this.user,
      this.creed,
      this.id});

  Account.fromJson(Map<String, dynamic> json) {
    try {
      status = json['status'] != null ? StatusModel.fromJson(json['status']) : null;
      creed = json['cread'];
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
    } catch (err) {
      log("$err", name: 'Account parsing error');
    }
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['status'] = status;
    data['photo'] = photo;
    data['creed'] = creed;
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

    if (status != null) {
      data['status'] = status!.toJson();
    }
    data['id'] = id;
    return data;
  }
}
