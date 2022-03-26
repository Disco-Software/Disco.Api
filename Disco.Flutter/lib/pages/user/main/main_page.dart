import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';

class MainPage extends StatelessWidget {
  const MainPage({Key? key}) : super(key: key);
  static const String route = "/main";

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        backgroundColor: const Color(0xff1C142E),
        appBar: AppBar(
          backgroundColor: const Color(0xFF1C142D),
          title: const Text(
            "DISCO",
            style: TextStyle(
                fontSize: 32,
                fontFamily: 'Colonna',
                fontWeight: FontWeight.bold),
          ),
          automaticallyImplyLeading: false,
          actions: [
            IconButton(
                padding: const EdgeInsets.only(right: 32),
                onPressed: onSearch(),
                icon: SvgPicture.asset(
                  "assets/ic_search.svg",
                  width: 32,
                  height: 30,
                )),
          ],
        ),
        body: Column(
          children: [
            CachedNetworkImage(
              imageUrl:
                  "https://cdn.vectorstock.com/i/1000x1000/46/77/person-gray-photo-placeholder-girl-material-design-vector-23804677.webp",
            )
          ],
        ));
  }

  onSearch() {}
}
