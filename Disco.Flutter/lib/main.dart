import 'package:disco_app/app/app.dart';
import 'package:disco_app/injection.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

void main() {
  configureDependencies();
  runApp(MyApp());
}
