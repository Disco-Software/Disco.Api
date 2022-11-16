import 'package:disco_app/data/network/network_models/account_network.dart';

class StoriesModel {
  List<StoryImages>? storyImages;
  List<StoryVideos>? storyVideos;
  String? dateOfCreation;
  int? profileId;
  Account? profile;
  int? id;

  StoriesModel(
      {this.storyImages,
      this.storyVideos,
      this.dateOfCreation,
      this.profileId,
      this.profile,
      this.id});

  StoriesModel.fromJson(Map<String, dynamic> json) {
    if (json['storyImages'] != null) {
      storyImages = <StoryImages>[];
      json['storyImages'].forEach((v) {
        storyImages?.add(StoryImages.fromJson(v));
      });
    }
    if (json['storyVideos'] != null) {
      storyVideos = <StoryVideos>[];
      json['storyVideos'].forEach((v) {
        storyVideos?.add(StoryVideos.fromJson(v));
      });
    }
    dateOfCreation = json['dateOfCreation'];
    profileId = json['profileId'];
    profile = json['profile'] != null ? Account.fromJson(json['profile']) : null;
    id = json['id'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    if (storyImages != null) {
      data['storyImages'] = storyImages?.map((v) => v.toJson()).toList();
    }
    if (storyVideos != null) {
      data['storyVideos'] = storyVideos?.map((v) => v.toJson()).toList();
    }
    data['dateOfCreation'] = dateOfCreation;
    data['profileId'] = profileId;
    if (profile != null) {
      data['profile'] = profile?.toJson();
    }
    data['id'] = id;
    return data;
  }
}

class StoryImages {
  String? source;
  int? storyId;
  int? id;
  String? dateOfCreation;

  StoryImages({
    this.source,
    this.storyId,
    this.id,
    this.dateOfCreation,
  });

  StoryImages.fromJson(Map<String, dynamic> json) {
    source = json['source'];
    storyId = json['storyId'];
    id = json['id'];
    dateOfCreation = json['dateOfCreation'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['source'] = source;
    data['storyId'] = storyId;
    data['id'] = id;
    data['dateOfCreation'] = dateOfCreation;
    return data;
  }
}

class StoryVideos {
  String? source;
  int? storyId;
  int? id;
  String? dateOfCreation;

  StoryVideos({
    this.source,
    this.storyId,
    this.id,
    this.dateOfCreation,
  });

  StoryVideos.fromJson(Map<String, dynamic> json) {
    source = json['source'];
    storyId = json['storyId'];
    id = json['id'];
    dateOfCreation = json['dateOfCreation'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['source'] = source;
    data['storyId'] = storyId;
    data['id'] = id;
    data['dateOfCreation'] = dateOfCreation;
    return data;
  }
}

class Stories {
  List<StoryImages>? storyImages;
  List<StoryVideos>? storyVideos;
  String? dateOfCreation;
  int? profileId;
  int? id;

  Stories({this.storyImages, this.storyVideos, this.dateOfCreation, this.profileId, this.id});

  Stories.fromJson(Map<String, dynamic> json) {
    if (json['storyImages'] != null) {
      storyImages = <StoryImages>[];
      json['storyImages'].forEach((v) {
        storyImages?.add(StoryImages.fromJson(v));
      });
    }
    if (json['storyVideos'] != null) {
      storyVideos = <StoryVideos>[];
      json['storyVideos'].forEach((v) {
        storyVideos?.add(StoryVideos.fromJson(v));
      });
    }
    dateOfCreation = json['dateOfCreation'];
    profileId = json['profileId'];
    id = json['id'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    if (storyImages != null) {
      data['storyImages'] = storyImages?.map((v) => v.toJson()).toList();
    }
    if (storyVideos != null) {
      data['storyVideos'] = storyVideos?.map((v) => v.toJson()).toList();
    }
    data['dateOfCreation'] = dateOfCreation;
    data['profileId'] = profileId;
    data['id'] = id;
    return data;
  }
}
