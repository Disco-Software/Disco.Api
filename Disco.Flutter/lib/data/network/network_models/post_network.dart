import 'dart:developer';

import 'package:disco_app/data/network/network_models/account_network.dart';
import 'package:disco_app/data/network/network_models/song_network.dart';
import 'package:disco_app/data/network/network_models/video_network.dart';

import 'image_network.dart';
import 'like.dart';

class Post {
  String? description;
  List<PostImage>? postImages;
  List<PostSong>? postSongs;
  List<PostVideo>? postVideos;
  int? profileId;
  List<Like>? likes;
  Account? account;
  int? id;

  Post(
      {this.description,
      this.postImages,
      this.postSongs,
      this.postVideos,
      this.likes,
      this.profileId,
      this.account,
      this.id});

  Post.fromJson(Map<String, dynamic> json) {
    try {
      description = json['description'];
      if (json['postImages'] != null) {
        postImages = <PostImage>[];
        json['postImages'].forEach((v) {
          postImages!.add(PostImage.fromJson(v));
        });
      }
      if (json['likes'] != null) {
        likes = <Like>[];
        json['likes'].forEach((v) {
          likes!.add(Like.fromJson(v));
        });
      }
      if (json['postSongs'] != null) {
        postSongs = <PostSong>[];
        json['postSongs'].forEach((v) {
          postSongs!.add(PostSong.fromJson(v));
        });
      }
      if (json['postVideos'] != null) {
        postVideos = <PostVideo>[];
        json['postVideos'].forEach((v) {
          postVideos!.add(PostVideo.fromJson(v));
        });
      }
      profileId = json['profileId'];
      account = json['account'] != null ? Account.fromJson(json['account']) : null;
      id = json['id'];
    } catch (err) {
      log('$err', name: 'Post model error');
    }
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['description'] = description;
    if (postImages != null) {
      data['postImages'] = postImages!.map((v) => v.toJson()).toList();
    }
    if (likes != null) {
      data['likes'] = likes!.map((v) => v.toJson()).toList();
    }
    if (postSongs != null) {
      data['postSongs'] = postSongs!.map((v) => v.toJson()).toList();
    }
    if (postVideos != null) {
      data['postVideos'] = postVideos!.map((v) => v.toJson()).toList();
    }
    data['profileId'] = profileId;
    if (account != null) {
      data['account'] = account!.toJson();
    }
    data['id'] = id;
    return data;
  }
}
