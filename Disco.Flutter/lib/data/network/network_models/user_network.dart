import 'dart:developer';

import 'package:disco_app/data/network/network_models/account_network.dart';

class UserTokenResponse {
  User? user;
  String? accesToken;
  String? refreshToken;

  UserTokenResponse({
    this.user,
    this.accesToken,
    this.refreshToken,
  });

  UserTokenResponse.fromJson(Map<String, dynamic> json) {
    try {
      user = json['user'] != null ? User.fromJson(json['user']) : null;
      accesToken = json['accessToken'];
      refreshToken = json['refreshToken'];
    } catch (err) {
      print('loginError--> $err');
    }
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    if (user != null) {
      data['user'] = user!.toJson();
    }
    data['accesToken'] = accesToken;
    data['refreshToken'] = refreshToken;
    return data;
  }
}

class User {
  int? id;
  String? userName;
  String? normalizedUserName;
  String? email;
  String? normalizedEmail;
  String? roleName;
  bool? emailConfirmed;
  String? passwordHash;
  String? securityStamp;
  String? concurrencyStamp;
  String? phoneNumber;
  bool? phoneNumberConfirmed;
  bool? twoFactorEnabled;
  String? lockoutEnd;
  String? refreshToken;
  bool? lockoutEnabled;
  int? accessFailedCount;
  Account? account;

  User(
      {this.id,
      this.userName,
      this.normalizedUserName,
      this.email,
      this.refreshToken,
      this.normalizedEmail,
      this.emailConfirmed,
      this.passwordHash,
      this.securityStamp,
      this.concurrencyStamp,
      this.phoneNumber,
      this.phoneNumberConfirmed,
      this.twoFactorEnabled,
      this.lockoutEnd,
      this.lockoutEnabled,
      this.accessFailedCount,
      this.roleName,
      this.account});

  User.fromJson(Map<String, dynamic> json) {
    try {
      id = json['id'];
      userName = json['userName'];
      roleName = json['roleName'];
      normalizedUserName = json['normalizedUserName'];
      email = json['email'];
      normalizedEmail = json['normalizedEmail'];
      emailConfirmed = json['emailConfirmed'];
      passwordHash = json['passwordHash'];
      securityStamp = json['securityStamp'];
      refreshToken = json['refreshToken'];
      concurrencyStamp = json['concurrencyStamp'];
      phoneNumber = json['phoneNumber'];
      phoneNumberConfirmed = json['phoneNumberConfirmed'];
      twoFactorEnabled = json['twoFactorEnabled'];
      lockoutEnd = json['lockoutEnd'];
      lockoutEnabled = json['lockoutEnabled'];
      accessFailedCount = json['accessFailedCount'];
      account = json['account'] != null ? Account.fromJson(json['account']) : null;
    } catch (ex) {
      log(ex.toString(), name: "user from json error");
    }
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['id'] = id;
    data['userName'] = userName;
    data['roleName'] = roleName;
    data['normalizedUserName'] = normalizedUserName;
    data['email'] = email;
    data['normalizedEmail'] = normalizedEmail;
    data['emailConfirmed'] = emailConfirmed;
    data['passwordHash'] = passwordHash;
    data['refreshToken'] = refreshToken;
    data['securityStamp'] = securityStamp;
    data['concurrencyStamp'] = concurrencyStamp;
    data['phoneNumber'] = phoneNumber;
    data['phoneNumberConfirmed'] = phoneNumberConfirmed;
    data['twoFactorEnabled'] = twoFactorEnabled;
    data['lockoutEnd'] = lockoutEnd;
    data['lockoutEnabled'] = lockoutEnabled;
    data['accessFailedCount'] = accessFailedCount;
    if (account != null) {
      data['account'] = account!.toJson();
    }
    return data;
  }
}

// class Profile {
//   int? id;
//   String? status;
//   String? photo;
//   List<Posts>? posts;
//   int? userId;
//   String? user;
//
//   Profile({this.id, this.status, this.photo, this.posts, this.userId, this.user});
//
//   Profile.fromJson(Map<String, dynamic> json) {
//     id = json['id'];
//     status = json['status'];
//     photo = json['photo'];
//     if (json['posts'] != null) {
//       posts = <Posts>[];
//       json['posts'].forEach((v) {
//         posts!.add(Posts.fromJson(v));
//       });
//     }
//     userId = json['userId'];
//     user = json['user'];
//   }
//
//   Map<String, dynamic> toJson() {
//     final Map<String, dynamic> data = <String, dynamic>{};
//     data['id'] = id;
//     data['status'] = status;
//     data['photo'] = photo;
//     if (posts != null) {
//       data['posts'] = posts!.map((v) => v.toJson()).toList();
//     }
//     data['userId'] = userId;
//     data['user'] = user;
//     return data;
//   }
// }

class Posts {
  int? id;
  String? description;
  List<PostImages>? postImages;
  List<PostSongs>? postSongs;
  List<PostVideos>? postVideos;
  int? profileId;
  String? profile;

  Posts(
      {this.id,
      this.description,
      this.postImages,
      this.postSongs,
      this.postVideos,
      this.profileId,
      this.profile});

  Posts.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    description = json['description'];
    if (json['postImages'] != null) {
      postImages = <PostImages>[];
      json['postImages'].forEach((v) {
        postImages?.add(PostImages.fromJson(v));
      });
    }
    if (json['postSongs'] != null) {
      postSongs = <PostSongs>[];
      json['postSongs'].forEach((v) {
        postSongs?.add(PostSongs.fromJson(v));
      });
    }
    if (json['postVideos'] != null) {
      postVideos = <PostVideos>[];
      json['postVideos'].forEach((v) {
        postVideos?.add(PostVideos.fromJson(v));
      });
    }
    profileId = json['profileId'];
    profile = json['profile'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['id'] = id;
    data['description'] = description;
    if (postImages != null) {
      data['postImages'] = postImages?.map((v) => v.toJson()).toList();
    }
    if (postSongs != null) {
      data['postSongs'] = postSongs?.map((v) => v.toJson()).toList();
    }
    if (postVideos != null) {
      data['postVideos'] = postVideos?.map((v) => v.toJson()).toList();
    }
    data['profileId'] = profileId;
    data['profile'] = profile;
    return data;
  }
}

class PostImages {
  int? id;
  String? source;
  int? postId;
  String? post;

  PostImages({this.id, this.source, this.postId, this.post});

  PostImages.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    source = json['source'];
    postId = json['postId'];
    post = json['post'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['id'] = id;
    data['source'] = source;
    data['postId'] = postId;
    data['post'] = post;
    return data;
  }
}

class PostSongs {
  int? id;
  String? imageUrl;
  String? source;
  int? postId;
  String? post;

  PostSongs({this.id, this.imageUrl, this.source, this.postId, this.post});

  PostSongs.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    imageUrl = json['imageUrl'];
    source = json['source'];
    postId = json['postId'];
    post = json['post'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['id'] = id;
    data['imageUrl'] = imageUrl;
    data['source'] = source;
    data['postId'] = postId;
    data['post'] = post;
    return data;
  }
}

class PostVideos {
  int? id;
  String? videoSource;
  int? postId;
  String? post;

  PostVideos({this.id, this.videoSource, this.postId, this.post});

  PostVideos.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    videoSource = json['videoSource'];
    postId = json['postId'];
    post = json['post'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['id'] = id;
    data['videoSource'] = videoSource;
    data['postId'] = postId;
    data['post'] = post;
    return data;
  }
}
