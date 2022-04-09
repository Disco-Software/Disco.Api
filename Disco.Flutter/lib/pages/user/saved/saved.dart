import 'package:flutter/material.dart';

final Gradient gradient = LinearGradient(
  colors: <Color>[
    Colors.orangeAccent.withOpacity(1.0),
    Colors.yellowAccent.withOpacity(1.0),
  ],
  stops: [
    0.0,
    0.5,
    1.0,
  ],
);

class SavedItemsPage extends StatefulWidget {
  const SavedItemsPage({Key? key}) : super(key: key);

  @override
  State<SavedItemsPage> createState() => _SavedItemsPageState();
}

class _SavedItemsPageState extends State<SavedItemsPage> with SingleTickerProviderStateMixin {
  late Animation<double> animation;
  late AnimationController animController;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();

    animController = AnimationController(duration: Duration(seconds: 3), vsync: this);

    final curvedAnimation = CurvedAnimation(parent: animController, curve: Curves.easeInOutCubic);

    animation = Tween<double>(begin: 0.0, end: 3.14).animate(curvedAnimation)
      ..addListener(() {
        setState(() {});
      });
    animController.repeat(reverse: true);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold();
  }
}
