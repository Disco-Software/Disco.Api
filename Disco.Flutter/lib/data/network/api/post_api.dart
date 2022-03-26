import 'package:disco_app/data/network/network_client.dart';
import 'package:disco_app/data/network/network_models/post_network.dart';

class PostApi {
  Future<List<Post>?> GetAllUserPost(int id) => NetworkClient.instance.dio
          .get<List<Post>>('user/posts/${id}')
          .then((response) {
        return response.data;
      });

  Future<List<Post>?> GetAllPosts(int id) => NetworkClient.instance.dio
          .get<List<Post>>("user/posts/${id}/line")
          .then((response) {
        return response.data;
      });
}
