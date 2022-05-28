import 'package:auto_route/auto_route.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';

class AddPostPage extends StatelessWidget {
  const AddPostPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xff1C142E),
      appBar: AppBar(
        backgroundColor: const Color(0xFF1C142D),
        centerTitle: true,
        title: const Text(
          "Add post",
          style: TextStyle(
            fontSize: 24,
          ),
          textAlign: TextAlign.start,
        ),
        automaticallyImplyLeading: false,
        leading: IconButton(
            padding: const EdgeInsets.only(right: 32),
            onPressed: () {
              context.router.pop();
            },
            icon: SvgPicture.asset(
              "assets/ic_back_button.svg",
              width: 32,
              height: 30,
            )),
      ),
    );
  }
}
