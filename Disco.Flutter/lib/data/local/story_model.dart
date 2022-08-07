enum StoryType {
  image,
  video,
}

class StoryModel {
  final String source;
  final StoryType storyType;
  final DateTime dateOfCreation;

  StoryModel({
    required this.source,
    required this.storyType,
    required this.dateOfCreation,
  });

  @override
  String toString() {
    return 'StoryModel{source: $source, storyType: $storyType, dateOfCreation: $dateOfCreation}';
  }
}
