class StatusModel {
  String? lastStatus;
  int? followersCount;
  int? nextStatusId;
  int? userTarget;
  int? id;

  StatusModel({this.lastStatus, this.followersCount, this.nextStatusId, this.userTarget, this.id});

  StatusModel.fromJson(Map<String, dynamic> json) {
    lastStatus = json['lastStatus'];
    followersCount = json['followersCount'];
    nextStatusId = json['nextStatusId'];
    userTarget = json['userTarget'];
    id = json['id'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['lastStatus'] = lastStatus;
    data['followersCount'] = followersCount;
    data['nextStatusId'] = nextStatusId;
    data['userTarget'] = userTarget;
    data['id'] = id;
    return data;
  }
}
