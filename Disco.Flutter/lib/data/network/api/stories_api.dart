import 'package:disco_app/data/network/network_client.dart';
import 'package:disco_app/data/network/network_models/story_network.dart';

class StoriesApi {
  final NetworkClient client;

  StoriesApi({required this.client});

  Future<List<StoriesModel>?> fetchStories(int userId) => client
      .get<List<StoriesModel>>("user/story/all/${userId}")
      .then((response) => response.data);
}
