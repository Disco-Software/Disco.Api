import 'package:auto_route/auto_route.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/data/local/local_storage.dart';
import 'package:flutter/material.dart';

import '../../../injection.dart';

class ProfilePage extends StatelessWidget {
  const ProfilePage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Center(
            child: OutlinedButton(
                onPressed: () async {
                  await getIt.get<SecureStorageRepository>().deleteAll();
                  context.router.replace(const SplashRoute());
                },
                child: const Text('LogOut')),
          )
        ],
      ),
    );
  }
}
