import 'package:disco_app/data/network/network_models/account_network.dart';

class FollowerResponseModel {
  Account? followingAccount;
  Account? followerAccount;
  bool? isFollowing;

  FollowerResponseModel({
    this.followingAccount,
    this.followerAccount,
    this.isFollowing,
  });

  FollowerResponseModel.fromJson(Map<String, dynamic> json) {
    followingAccount =
        json['followingAccount'] != null ? Account.fromJson(json['followingAccount']) : null;

    followerAccount =
        json['followerAccount'] != null ? Account.fromJson(json['followerAccount']) : null;
    isFollowing = json['isFollowing'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = Map<String, dynamic>();
    if (followingAccount != null) {
      data['followingAccount'] = this.followingAccount!.toJson();
    }
    if (followerAccount != null) {
      data['followerAccount'] = this.followerAccount!.toJson();
    }
    data['isFollowing'] = this.isFollowing;
    return data;
  }
}
