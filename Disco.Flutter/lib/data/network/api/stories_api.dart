import 'package:disco_app/data/network/network_client.dart';
import 'package:disco_app/data/network/network_models/story_network.dart';

class StoriesApi {
  Future<List<StoriesModel>?> fetchStories(int userId) =>
      NetworkClient.instance.dio
          .get<List<StoriesModel>>("user/story/all/${userId}")
          .then((response) => response.data);
}
