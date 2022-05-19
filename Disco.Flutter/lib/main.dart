import 'package:disco_app/app/app.dart';
import 'package:disco_app/injection.dart';
import 'package:disco_app/pages/authentication/search_registration/bloc/search_cubit.dart';
import 'package:disco_app/providers/post_provider.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:provider/provider.dart';

void main() {
  WidgetsFlutterBinding.ensureInitialized();
  configureDependencies();
  runApp(ChangeNotifierProvider(
    create: (BuildContext context) => PostProvider(),
    child: MultiBlocProvider(providers: [
      BlocProvider(
        create: (context) => SearchCubit(),
      )
    ], child: MyApp()),
  ));
}
