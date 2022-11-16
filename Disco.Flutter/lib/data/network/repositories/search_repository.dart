import 'package:disco_app/data/network/api/search_api.dart';
import 'package:disco_app/data/network/network_models/search_item.dart';
import 'package:injectable/injectable.dart';

@injectable
class SearchRepository {
  final SearchApi searchApi;

  SearchRepository({required this.searchApi});

  Future<SearchItem?> search(String text) async {
    return searchApi.searchItem(text).then((data) {
      return SearchItem.fromJson(data ?? {});
    });
  }
}
