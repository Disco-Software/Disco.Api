import 'package:flutter/material.dart';

class MainPage extends StatelessWidget {
  const MainPage({Key? key}) : super(key: key);
  static const String route = "/main";

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
            backgroundColor: const Color(0xFF29193E),
            title: const Text(
              'DISCO',
              style: TextStyle(fontFamily: 'ColonnaMT'),
            )));
    // body: Container(
    //    color: const Color(0xFF1C142D),
    //   ),
    //    bottomNavigationBar: const CustomBottomBar());
    //}
  }
}
