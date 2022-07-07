import 'package:disco_app/data/network/api/stories_api.dart';
import 'package:disco_app/data/network/network_models/story_network.dart';
import 'package:injectable/injectable.dart';

@injectable
class StoriesRepository {
  final StoriesApi storiesApi;

  StoriesRepository({required this.storiesApi});

  Future<List<StoriesModel>?> fetchStories(int pageNumber, int pageSize) async => await storiesApi
      .fetchStories(pageNumber, pageSize)
      .then((stories) => stories?.map((e) => StoriesModel.fromJson(e)).toList());
}
