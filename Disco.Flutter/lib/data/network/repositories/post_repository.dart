import 'package:disco_app/data/network/api/post_api.dart';
import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:injectable/injectable.dart';

@injectable
class PostRepository {
  final PostApi postApi;

  PostRepository({required this.postApi});

  Future<List<Post>?> getAllPosts(int userId) async {
    return postApi.getAllPosts(userId).then((posts) {
      return posts?.map((e) => Post.fromJson(e)).toList();
    });
  }

  Future<List<Post>?> getAllUserPosts(int userId) async {
    return postApi
        .getAllUserPost(userId)
        .then((posts) => posts?.map((e) => Post.fromJson(e)).toList());
  }
}
