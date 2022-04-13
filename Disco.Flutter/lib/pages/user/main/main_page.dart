import 'package:cached_network_image/cached_network_image.dart';
import 'package:disco_app/core/widgets/unicorn_image.dart';
import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/data/network/network_models/story_network.dart';
import 'package:disco_app/pages/user/main/bloc/main_bloc.dart';
import 'package:disco_app/pages/user/main/bloc/main_event.dart';
import 'package:disco_app/pages/user/main/bloc/main_state.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:google_fonts/google_fonts.dart';

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
  @override
  void initState() {
    // TODO: implement initState
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
        listener: (context, state) {},
        builder: (context, state) {
          if (state is LoadingState) {
            return const CircularProgressIndicator.adaptive();
          } else if (state is SuccessState) {
            print(
                "${state.stories.length}-->${state.posts.length}   SuccessState");

            return _SuccessStateWidget(
              stories: state.stories,
              posts: state.posts,
              userImageUrl: state.userImageUrl,
            );
          } else {
            return Container(
              height: 100.0,
              width: 100.0,
              color: Colors.red,
            );
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
  final String userImageUrl;

  const _SuccessStateWidget(
      {Key? key,
      required this.stories,
      required this.posts,
      required this.userImageUrl})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        backgroundColor: const Color(0xff1C142E),
        body: Column(
          children: [
            const SizedBox(
              height: 6,
            ),
            if (stories.isNotEmpty)
              SizedBox(
                  height: 105,
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
                              imageUrl: stories[index].profile?.photo ??
                                  "assets/ic_photo.png",
                              title:
                                  stories[index].profile?.user?.userName ?? "",
                            ),
                          );
                        }
                      }))
            else
              Padding(
                padding: const EdgeInsets.only(right: 8, top: 8),
                child: Row(
                  children: [
                    const SizedBox(
                      width: 12,
                    ),
                    UnicornImage(
                      title: "Your story",
                      imageUrl: userImageUrl,
                      shouldHaveGradientBorder: false,
                      shouldHavePlus: true,
                    ),
                  ],
                ),
              ),
            const SizedBox(
              height: 11,
            ),
            Column(
              mainAxisSize: MainAxisSize.min,
              children: [
                Row(
                  mainAxisSize: MainAxisSize.min,
                  children: [
                    Container(
                      height: 71,
                      width: 56,
                      decoration: const BoxDecoration(
                          borderRadius: BorderRadius.only(
                            topRight: Radius.circular(100),
                            bottomRight: Radius.circular(100),
                          ),
                          boxShadow: [
                            BoxShadow(
                                color: Color(0xFFB21887D7),
                                offset: Offset(2, 3),
                                spreadRadius: 7,
                                blurRadius: 7)
                          ]),
                      child: posts.first.profile?.photo != null
                          ? CachedNetworkImage(
                              imageUrl: posts.first.profile?.photo ?? '',
                              placeholder: (context, url) =>
                                  Image.asset('assets/ic_photo.png'),
                              fit: BoxFit.cover,
                              height: 71,
                              width: 56,
                            )
                          : Container(
                              decoration: const BoxDecoration(
                                color: Colors.white,
                                borderRadius: BorderRadius.only(
                                  topRight: Radius.circular(100),
                                  bottomRight: Radius.circular(100),
                                ),
                              ),
                              child: Image.asset(
                                'assets/ic_photo.png',
                                fit: BoxFit.cover,
                              ),
                            ),
                    ),
                    const SizedBox(
                      width: 16,
                    ),
                    Text(posts.first.profile?.user?.userName ?? "",
                        style: GoogleFonts.aBeeZee(
                          color: const Color(0xFFE6E0D2),
                          fontSize: 24,
                        )),
                    const Spacer(),
                  ],
                ),
                const SizedBox(height: 27),
                Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 52),
                  child: Container(
                      height: 184,
                      decoration: BoxDecoration(
                        borderRadius: BorderRadius.circular(8),
                        boxShadow: const [
                          BoxShadow(
                              color: Color(0xFFB2A044FF),
                              offset: Offset(0, 4),
                              blurRadius: 7),
                        ],
                      ),
                      child: CachedNetworkImage(
                        imageUrl: posts.first.postImages?.first.source ?? '',
                      )),
                ),
                const SizedBox(
                  height: 10,
                ),
                Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 52),
                  child: Text(
                    posts.first.description ?? '',
                    style: GoogleFonts.textMeOne(
                      fontSize: 24,
                      fontWeight: FontWeight.w400,
                      color: Colors.white,
                    ),
                  ),
                ),
                Row(
                  children: [],
                )
              ],
            ),
          ],
        ));
  }
}
