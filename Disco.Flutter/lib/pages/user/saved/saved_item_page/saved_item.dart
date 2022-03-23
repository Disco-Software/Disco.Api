import 'package:auto_route/annotations.dart';
import 'package:flutter/material.dart';

class SavedItem extends StatelessWidget {
  const SavedItem({Key? key, @PathParam() required this.itemId})
      : super(key: key);
  final int itemId;
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(),
    );
  }
}
