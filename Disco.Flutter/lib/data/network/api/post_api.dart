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

  Future<List<dynamic>?> getAllPosts(int id) async =>
      await dio.get("user/posts/$id/line").then((response) {
        return response?.data;
      });
}
