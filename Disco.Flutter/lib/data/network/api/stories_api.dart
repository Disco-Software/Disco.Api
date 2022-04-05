import 'package:dio/dio.dart';
import 'package:injectable/injectable.dart';

@injectable
class StoriesApi {
  final Dio dio;

  StoriesApi({required this.dio});

  Future<List<dynamic>?> fetchStories(int userId) =>
      dio.get("user/story/all/$userId").then((response) {
        return response.data;
      });
}
