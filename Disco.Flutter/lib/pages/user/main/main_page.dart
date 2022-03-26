import 'package:disco_app/core/widgets/unicorn_image.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';

class MainPage extends StatelessWidget {
  const MainPage({Key? key}) : super(key: key);
  static const String route = "/main";

  static const List<String> list = [
    "https://html5css.ru/howto/img_avatar.png",
    "https://html5css.ru/howto/img_avatar.png",
    "https://html5css.ru/howto/img_avatar.png",
    "https://html5css.ru/howto/img_avatar.png",
  ];

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
            SizedBox(
              height: 85,
              child: ListView.builder(
                  scrollDirection: Axis.horizontal,
                  itemCount: list.length,
                  itemBuilder: (context, index) {
                    if (index == 0) {
                      return Padding(
                        padding: const EdgeInsets.only(left: 12, right: 8),
                        child: UnicornImage(
                          imageUrl: list[index],
                          shouldHaveGradientBorder: false,
                          shouldHavePlus: true,
                        ),
                      );
                    } else {
                      return Padding(
                        padding: const EdgeInsets.symmetric(
                          horizontal: 8,
                        ),
                        child: UnicornImage(imageUrl: list[index]),
                      );
                    }
                  }),
            )
          ],
        ));
  }

  onSearch() {}
}
