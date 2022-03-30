import 'package:disco_app/core/widgets/unicorn_image.dart';
import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/data/network/network_models/story_network.dart';
import 'package:disco_app/pages/user/main/bloc/main_bloc.dart';
import 'package:disco_app/pages/user/main/bloc/main_event.dart';
import 'package:disco_app/pages/user/main/bloc/main_state.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_svg/flutter_svg.dart';

const String title = 'Your story';

class MainPage extends StatefulWidget {
  MainPage({Key? key}) : super(key: key);
  static const String route = "/main";
  static const List<String> list = [
    "https://html5css.ru/howto/img_avatar.png",
    "https://html5css.ru/howto/img_avatar.png",
    "https://html5css.ru/howto/img_avatar.png",
    "https://html5css.ru/howto/img_avatar.png",
  ];

  @override
  State<MainPage> createState() => _MainPageState();
}

class _MainPageState extends State<MainPage> {
  final _bloc = MainPageBloc();
  @override
  void initState() {
    // TODO: implement initState
    print("user intialisator");
    context.read<MainPageBloc>().add(InitialEvent(id: 1));
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xff1C142E),
      appBar: AppBar(
        backgroundColor: const Color(0xFF1C142D),
        title: const Text(
          "DISCO",
          style: TextStyle(
              fontSize: 32, fontFamily: 'Colonna', fontWeight: FontWeight.bold),
        ),
        automaticallyImplyLeading: false,
        actions: [
          IconButton(
              padding: const EdgeInsets.only(right: 32),
              onPressed: () {
                print('test 1 2 3');

                /// context.read<MainPageBloc>().add(InitialEvent(id: 1));
              },
              icon: SvgPicture.asset(
                "assets/ic_search.svg",
                width: 32,
                height: 30,
              )),
        ],
      ),
      body: BlocConsumer<MainPageBloc, MainPageState>(
        listener: (context, state) {
          print("$state lissener");
        },
        builder: (context, state) {
          print("$state  state");
          if (state is LoadingState) {
            return InkWell(
                onTap: () {
                  BlocProvider.of<MainPageBloc>(context)
                    ..add(InitialEvent(id: 1));
                },
                child: const CircularProgressIndicator.adaptive());
          } else if (state is SuccessState) {
            return _SuccessStateWidget(
              stories: state.stories,
              posts: state.posts,
            );
          } else {
            return const SizedBox();
          }
        },
      ),
    );
  }

  void _blocLisener(BuildContext context, Object? state) {
    WidgetsBinding.instance?.addPostFrameCallback((timeStamp) {
      if (state is SuccessState) {}
    });
  }

  onSearch() {}
}

class _SuccessStateWidget extends StatelessWidget {
  final List<StoriesModel> stories;
  final List<Post> posts;
  final String? userImageUrl;
  const _SuccessStateWidget(
      {Key? key, required this.stories, required this.posts, this.userImageUrl})
      : super(key: key);
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Column(
      children: [
        const SizedBox(
          height: 6,
        ),
        SizedBox(
          height: 85,
          child: ListView.builder(
              scrollDirection: Axis.horizontal,
              itemCount: stories.length,
              itemBuilder: (context, index) {
                if (index == 0) {
                  return Padding(
                    padding: const EdgeInsets.only(left: 12, right: 8),
                    child: UnicornImage(
                      title: "Your story",
                      imageUrl: userImageUrl ?? "",
                      shouldHaveGradientBorder: false,
                      shouldHavePlus: true,
                    ),
                  );
                } else {
                  return Padding(
                    padding: const EdgeInsets.symmetric(
                      horizontal: 8,
                    ),
                    child: UnicornImage(
                      imageUrl: stories[index].profile?.photo ?? "",
                      title: stories[index].profile?.user?.userName ?? "",
                    ),
                  );
                }
              }),
        )
      ],
    ));
  }
}
