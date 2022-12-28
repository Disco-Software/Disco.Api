class CreateFollowerDto {
  String? installationId;
  String? followerAccountId;

  CreateFollowerDto({this.followerAccountId, this.installationId});

  CreateFollowerDto.fromJson(Map<String, dynamic> json) {
    followerAccountId = json['followerAccountId'];
    installationId = json['installationId'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['followerAccountId'] = followerAccountId;
    data['installationId'] = installationId;
    return data;
  }

  @override
  String toString() {
    return 'CreateFollowerDto{installationId: $installationId, followerAccountId: $followerAccountId}';
  }
}
