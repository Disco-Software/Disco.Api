import 'package:dio/dio.dart';
import 'package:injectable/injectable.dart';

@injectable
class PostApi {
  final Dio dio;

  PostApi({required this.dio});

  Future<List<dynamic>?> getAllUserPost(int id) async =>
      await dio.get('user/posts/$id').then((response) {
        return response.data;
      });

  Future<List<dynamic>?> getAllPosts(int pageNumber, int pageSize) async => await dio.get(
        "user/posts/line",
        queryParameters: {
          'pageNumber': '$pageNumber',
          'pageSize': '$pageSize',
        },
      ).then((response) {
        return response.data;
      });

  Future<dynamic> createPost(FormData post) =>
      dio.post("user/posts/create", data: post).then((response) {
        return response.data;
      });

  Future<dynamic> addLike(int postId) =>
      dio.post("user/likes/create", queryParameters: {'postId': postId}).then((response) {
        return response.data;
      });

  Future<dynamic> removeLike(int postId) =>
      dio.delete("user/likes/remove", queryParameters: {'postId': postId}).then((response) {
        return response.data;
      });
}
