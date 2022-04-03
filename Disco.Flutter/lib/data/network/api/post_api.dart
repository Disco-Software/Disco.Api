import 'package:dio/dio.dart';
import 'package:disco_app/data/network/network_models/post_network.dart';

class PostApi {
  final Dio dio;

  PostApi({required this.dio});

  Future<List<Post>?> GetAllUserPost(int id) =>
      dio.get<List<Post>>('user/posts/$id').then((response) {
        return response.data;
      });

  Future<List<Post>?> GetAllPosts(int id) =>
      dio.get<List<Post>>("user/posts/$id/line").then((response) {
        return response.data;
      });
}
