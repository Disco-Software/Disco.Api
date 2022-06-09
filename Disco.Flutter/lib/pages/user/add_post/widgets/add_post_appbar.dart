import 'package:auto_route/auto_route.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';

AppBar addPostAppBar(BuildContext context, [VoidCallback? actionCallback]) {
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
        onPressed: () {
          context.router
              .pushAndPopUntil(HomeRoute(shouldLoadData: false), predicate: (route) => false);
        },
        icon: SvgPicture.asset(
          "assets/ic_back_button.svg",
          width: 32,
          height: 30,
        )),
    actions: [
      if (actionCallback != null)
        IconButton(
            padding: const EdgeInsets.only(right: 10.0),
            onPressed: actionCallback,
            icon: SvgPicture.asset(
              "assets/ic_okay.svg",
              width: 32,
              height: 30,
            ))
    ],
  );
}
