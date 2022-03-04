import 'package:disco_app/core/widgets/custom_bottom_bar.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/material.dart';

class MainPage extends StatelessWidget {
  const MainPage({Key? key}) : super(key: key);
  static const String route = "/main";

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          backgroundColor: const Color(0xFF29193E),
          title: const Text('DISCO',
              style: TextStyle(fontSize: 28, color: DcColors.darkWhite)),
        ),
        body: Container(
          color: const Color(0xFF1C142D),
        ),
        bottomNavigationBar: const CustomBottomBar());
  }
}
