import 'package:disco_app/app/app.dart';
import 'package:disco_app/injection.dart';
import 'package:disco_app/presentation/pages/authentication/search_registration/bloc/search_cubit.dart';
import 'package:disco_app/presentation/pages/user/main/bloc/posts_cubit.dart';
import 'package:disco_app/presentation/pages/user/main/bloc/stories_cubit.dart';
import 'package:disco_app/presentation/providers/add_post_provider.dart';
import 'package:disco_app/presentation/providers/post_provider.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:provider/provider.dart';

void main() {
  WidgetsFlutterBinding.ensureInitialized();
  configureDependencies();
  runApp(MultiProvider(
    providers: [
      ChangeNotifierProvider(create: (_) => PostProvider()),
      ChangeNotifierProvider(create: (_) => AddPostProvider()),
    ],
    child: MultiBlocProvider(providers: [
      BlocProvider<PostsCubit>(create: (_) => PostsCubit(postRepository: getIt())),
      // BlocProvider<LikeCubit>(create: (_) => LikeCubit(postRepository: getIt())),
      BlocProvider<StoriesCubit>(create: (_) => StoriesCubit(storiesRepository: getIt())),
      BlocProvider(create: (context) => SearchCubit())
    ], child: MyApp()),
  ));
}
