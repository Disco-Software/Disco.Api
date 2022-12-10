import 'package:disco_app/data/network/network_models/account_network.dart';

class FollowerResponseModel {
  int? followingAccountId;
  Account? followingAccount;
  int? followerAccountId;
  Account? followerAccount;
  bool? isFollowing;
  int? id;

  FollowerResponseModel(
      {this.followingAccountId,
      this.followingAccount,
      this.followerAccountId,
      this.followerAccount,
      this.isFollowing,
      this.id});

  FollowerResponseModel.fromJson(Map<String, dynamic> json) {
    followingAccountId = json['followingAccountId'];
    followingAccount = json['followingAccount'] != null
        ? Account.fromJson(json['followingAccount'])
        : null;
    followerAccountId = json['followerAccountId'];
    followerAccount = json['followerAccount'] != null
        ? Account.fromJson(json['followerAccount'])
        : null;
    isFollowing = json['isFollowing'];
    id = json['id'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = Map<String, dynamic>();
    data['followingAccountId'] = followingAccountId;
    if (followingAccount != null) {
      data['followingAccount'] = this.followingAccount!.toJson();
    }
    data['followerAccountId'] = this.followerAccountId;
    if (followerAccount != null) {
      data['followerAccount'] = this.followerAccount!.toJson();
    }
    data['isFollowing'] = this.isFollowing;
    data['id'] = id;
    return data;
  }
}
