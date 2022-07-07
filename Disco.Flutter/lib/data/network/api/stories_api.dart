import 'package:dio/dio.dart';
import 'package:injectable/injectable.dart';

@injectable
class StoriesApi {
  final Dio dio;

  StoriesApi({required this.dio});

  Future<List<dynamic>?> fetchStories(int pageNumber, int pageSize) =>
      dio.get("user/story/all", queryParameters: {
        'pageNumber': pageNumber,
        'pageSize': pageSize,
      }).then((response) {
        return response.data;
      });
}
