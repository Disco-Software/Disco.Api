import 'package:disco_app/app/app.dart';
import 'package:disco_app/injection.dart';
import 'package:disco_app/pages/authentication/search_registration/bloc/search_cubit.dart';
import 'package:disco_app/providers/post_provider.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:provider/provider.dart';

import 'data/network/repositories/post_repository.dart';
import 'data/network/repositories/stories_repository.dart';
import 'pages/user/main/bloc/main_bloc.dart';
import 'pages/user/main/bloc/stories_bloc.dart';

void main() {
  WidgetsFlutterBinding.ensureInitialized();
  configureDependencies();
  runApp(ChangeNotifierProvider(
    create: (BuildContext context) => PostProvider(),
    child: MultiBlocProvider(providers: [
      BlocProvider<MainPageBloc>(
          create: (_) => MainPageBloc(
              postRepository: getIt.get<PostRepository>(),
              storiesRepository: getIt.get<StoriesRepository>())),
      BlocProvider<StoriesBloc>(
        create: (_) => StoriesBloc(
            postRepository: getIt.get<PostRepository>(),
            storiesRepository: getIt.get<StoriesRepository>()),
      ),
      BlocProvider(
        create: (context) => SearchCubit(),
      )
    ], child: MyApp()),
  ));
}
