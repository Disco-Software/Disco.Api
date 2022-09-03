import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';

AppBar addPostAppBar(
    {required BuildContext context,
    VoidCallback? actionCallback,
    VoidCallback? actionSave,
    bool ignoreSave = false}) {
  return AppBar(
    backgroundColor: const Color(0xFF211637),
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
        padding: const EdgeInsets.only(left: 10.0),
        onPressed: actionCallback,
        icon: SvgPicture.asset(
          "assets/ic_back_button.svg",
          width: 32,
          height: 30,
        )),
    actions: [
      if (actionSave != null)
        IgnorePointer(
          ignoring: ignoreSave,
          child: IconButton(
              padding: const EdgeInsets.only(right: 10.0),
              onPressed: actionSave,
              icon: SvgPicture.asset(
                "assets/ic_okay.svg",
                width: 32,
                height: 30,
              )),
        )
    ],
  );
}
