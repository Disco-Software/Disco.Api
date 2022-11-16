import 'package:disco_app/data/network/network_models/account_network.dart';

class FriendModel {
  Account? userProfile;
  Account? friendProfile;
  bool? isConfirmed;

  FriendModel({this.userProfile, this.friendProfile, this.isConfirmed});

  FriendModel.fromJson(Map<String, dynamic> json) {
    userProfile = json['userProfile'] != null
        ? Account.fromJson(json['userProfile'])
        : null;
    friendProfile = json['friendProfile'] != null
        ? Account.fromJson(json['friendProfile'])
        : null;
    isConfirmed = json['isConfirmed'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    if (userProfile != null) {
      data['userProfile'] = userProfile!.toJson();
    }
    if (friendProfile != null) {
      data['friendProfile'] = friendProfile!.toJson();
    }
    data['isConfirmed'] = isConfirmed;
    return data;
  }
}
