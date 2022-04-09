import 'package:disco_app/app/app.dart';
import 'package:disco_app/data/network/request_models/login_request.dart';
import 'package:disco_app/injection.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

import 'data/network/interceptors/header_interceptor.dart';

void main() {
  WidgetsFlutterBinding.ensureInitialized();
  configureDependencies();
  HeaderInterceptor.instance.init(
    onRequest: (options, _) async {
      print('lol1req ${(options.data as LogInRequestModel).email}');
    },
    onResponse: (response, _) async {
      print('lol1resp ${response.data}');
    },
    onError: (error, _) async {
      print('lol1err');
    },
  );
  runApp(MyApp());
}
