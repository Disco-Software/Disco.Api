import 'package:dio/dio.dart';

class NetworkClient{
  NetworkClient._();
  static final instance = NetworkClient._();

  final dio = Dio(BaseOptions(baseUrl: "https://discoapi20211205192712.azurewebsites.net/api/"));
}