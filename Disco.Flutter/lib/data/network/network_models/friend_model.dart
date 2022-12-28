import 'package:disco_app/data/network/network_models/account_network.dart';

class FriendModel {
  int? followingAccountId;
  int? followerAccountId;
  Account? followingAccount;
  Account? followerAccount;
  int? id;

  FriendModel({
    this.followingAccountId,
    this.followerAccountId,
    this.followingAccount,
    this.followerAccount,
    this.id,
  });

  FriendModel.fromJson(Map<String, dynamic> json) {
    followingAccountId = json['followingAccountId'];
    id = json['id'];
    followerAccountId = json['followerAccountId'];
    followingAccount =
        json['followingAccount'] != null ? Account.fromJson(json['followingAccount']) : null;
    followerAccount =
        json['followerAccount'] != null ? Account.fromJson(json['followerAccount']) : null;
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    if (followingAccountId != null) {
      data['followingAccountId'] = followingAccountId;
    }
    if (followerAccountId != null) {
      data['followingAccountId'] = followerAccountId;
    }
    if (id != null) {
      data['id'] = id;
    }
    if (followingAccount != null) {
      data['followingAccount'] = followingAccount!.toJson();
    }
    if (followerAccount != null) {
      data['followerAccount'] = followerAccount!.toJson();
    }
    return data;
  }
}
