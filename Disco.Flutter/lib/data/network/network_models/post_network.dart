import 'package:disco_app/data/network/network_models/profile_network.dart';
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
  Profile? profile;
  int? id;

  Post(
      {this.description,
      this.postImages,
      this.postSongs,
      this.postVideos,
      this.likes,
      this.profileId,
      this.profile,
      this.id});

  Post.fromJson(Map<String, dynamic> json) {
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
    profile = json['profile'] != null ? Profile.fromJson(json['profile']) : null;
    id = json['id'];
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
    if (profile != null) {
      data['profile'] = profile!.toJson();
    }
    data['id'] = id;
    return data;
  }
}
