import 'package:dio/dio.dart';
import 'package:injectable/injectable.dart';

@injectable
class SearchApi {
  final Dio dio;

  SearchApi({required this.dio});

  Future<Map<String, dynamic>?> searchItem(String text) async =>
      await dio.get('user/global/search', queryParameters: {'search': text}).then((response) {
        return response.data;
      });
}
