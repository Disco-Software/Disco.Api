import 'dart:io';

import 'package:carousel_slider/carousel_slider.dart';
import 'package:disco_app/core/widgets/post/widgets/image_body.dart';
import 'package:disco_app/core/widgets/post/widgets/post_author.dart';
import 'package:disco_app/core/widgets/post/widgets/song_body.dart';
import 'package:disco_app/core/widgets/post/widgets/video_body.dart';
import 'package:disco_app/core/widgets/post_button.dart';
import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/pages/user/main/bloc/like_cubit.dart';
import 'package:disco_app/pages/user/main/bloc/like_state.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:percent_indicator/linear_percent_indicator.dart';

const String serverUrl = 'https://devdiscoapi.azurewebsites.net/like';
const String token =
    'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJuYmYiOjE2NTQxOTk2OTMsImV4cCI6MTY1NDI3MTY5MywiaXNzIjoiZGlzY28tYXBpIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdC9EaXNjby5BcGkifQ.o0pUMkhRb5hm3ziPDNv1QCcLs-shMhAkc2dHGw_MkWI';

class UnicornPost extends StatefulWidget {
  const UnicornPost({
    Key? key,
    required this.post,
  }) : super(key: key);

  final Post post;

  @override
  State<UnicornPost> createState() => _UnicornPostState();
}

class _UnicornPostState extends State<UnicornPost> with SingleTickerProviderStateMixin {
  int bodyIndex = 1;
  late AnimationController controller;
  final CarouselController carouselController = CarouselController();
  int _currentPageIndex = 0;

  // final hubConnection = HubConnectionBuilder().withUrl(serverUrl).build();
  // late HubConnection hubConnection;

  // final hubProtLogger = Logger("SignalR - hub");

  // late IOWebSocketChannel _channel;

  @override
  void initState() {
    super.initState();
    // initLikeHub();
    controller =
        AnimationController(value: 0.3, vsync: this, duration: const Duration(milliseconds: 300));
  }

  // void initLikeHub() {
  //   // final headers = MessageHeaders();
  //   // headers.setHeaderValue('Authorization', token);
  //   // _channel = IOWebSocketChannel.connect(
  //   //   Uri.parse(serverUrl),
  //   //   headers: {'Authorization': token},
  //   // );
  //   final builder = HubConnectionBuilder()
  //       .withUrl(
  //         serverUrl,
  //         options: HttpConnectionOptions(
  //           accessTokenFactory: () async => token,
  //           requestTimeout: 100000,
  //           transport: IOClient(HttpClient()..badCertificateCallback = (x, y, z) => true),
  //         ),
  //       )
  //       .withAutomaticReconnect();
  //   hubConnection = builder.build()..serverTimeoutInMilliseconds = 100000;
  //   // hubConnection = HubConnectionBuilder()
  //   //     .withUrl(serverUrl,
  //   //         options: HttpConnectionOptions(
  //   //           accessTokenFactory: () async => token,
  //   //           transport: HttpTransportType.ServerSentEvents,
  //   //         ))
  //   //     .withAutomaticReconnect()
  //   //     .build();
  //   hubConnection.onclose(
  //     ({error}) => print('Connection close'),
  //   );
  //   hubConnection.on('create', (args) {
  //     print('HUBCONNECTION:  args');
  //   });
  // }

  @override
  void dispose() {
    // hubConnection.stop();
    super.dispose();
  }

  // Future<void> hubConnectionStart() async => await hubConnection.start();

  @override
  Widget build(BuildContext context) {
    return Column(
      mainAxisSize: MainAxisSize.min,
      children: [
        PostAuthor(post: widget.post),
        const SizedBox(height: 27),
        Padding(
          padding: const EdgeInsets.symmetric(horizontal: 35),
          child: CarouselSlider(
            carouselController: carouselController,
            items: [
              if (widget.post.postSongs != null && widget.post.postSongs!.isNotEmpty)
                ...widget.post.postSongs!
                    .map((postSong) => SongBody(
                          userName: widget.post.postSongs?[_currentPageIndex].executorName ??
                              widget.post.profile?.user?.userName ??
                              "",
                          postSong: postSong,
                          songSources:
                              widget.post.postSongs?.map((e) => e.source ?? '').toList() ?? [],
                          songTitles:
                              widget.post.postSongs?.map((e) => e.name ?? '').toList() ?? [],
                          carouselController: carouselController,
                          post: widget.post,
                          currentPageIndex: _currentPageIndex,
                        ))
                    .toList(),
              if (widget.post.postImages != null && widget.post.postImages!.isNotEmpty)
                ...widget.post.postImages!
                    .map((postImage) => ImageBody(
                          postImage: postImage,
                        ))
                    .toList(),
              if (widget.post.postVideos != null && widget.post.postVideos!.isNotEmpty)
                ...widget.post.postVideos!
                    .map((postVideo) => VideoBody(
                          postVideo: postVideo,
                        ))
                    .toList(),
            ],
            options: CarouselOptions(
                viewportFraction: 1.0,
                enableInfiniteScroll: false,
                onPageChanged: (index, reason) {
                  setState(() {
                    _currentPageIndex = index;
                  });
                  controller.animateTo(_getIndicatorPercent(index + 1));
                }),
          ),
        ),
        Padding(
          padding: const EdgeInsets.symmetric(horizontal: 52),
          child: Text(
            widget.post.description ?? '',
            style: GoogleFonts.textMeOne(
              fontSize: 24,
              fontWeight: FontWeight.w400,
              color: Colors.white,
            ),
          ),
        ),
        const SizedBox(
          height: 9,
        ),
        Padding(
          padding: const EdgeInsets.symmetric(horizontal: 37),
          child: Row(
            children: [
              PostButton(
                onTap: () async {
                  context.read<LikeCubit>().addLike(widget.post.id ?? 0);
                },
                imagePath: "assets/ic_star.svg",
              ),
              BlocBuilder<LikeCubit, LikeState>(
                builder: (context, state) {
                  return state.maybeMap(
                    orElse: () => const SizedBox(),
                    success: _likeSuccessState,
                    initial: _initialState,
                    error: (_) => const Text('Error'),
                  );
                },
              ),
              PostButton(onTap: () {}, imagePath: 'assets/ic_comment.svg'),
              const SizedBox(width: 13),
              PostButton(onTap: () {}, imagePath: "assets/ic_share.svg"),
              const Spacer(),
              if (_shouldShowPercentIndicator(widget.post))
                AnimatedBuilder(
                  builder: (context, index) => LinearPercentIndicator(
                    width: 100,
                    percent: controller.value,
                    barRadius: const Radius.circular(7),
                    linearGradient:
                        const LinearGradient(colors: [Color(0xFFE08D11), Color(0xFFF6EA7D)]),
                    backgroundColor: const Color(0xFFC9D6FF),
                  ),
                  animation: controller,
                ),
              const Spacer(),
              Stack(
                children: [
                  const SizedBox(
                    width: 22,
                    height: 22,
                  ),
                  PostButton(onTap: () {}, imagePath: "assets/ic_save.svg"),
                  Positioned(
                    top: 8,
                    left: 8,
                    child: Container(
                      padding: const EdgeInsets.all(3),
                      decoration: const BoxDecoration(
                        gradient: LinearGradient(
                          colors: [
                            Color(0xFFDE8820),
                            Color(0xFFF6EA7D),
                          ],
                        ),
                        shape: BoxShape.circle,
                      ),
                      child: const Icon(
                        CupertinoIcons.add,
                        size: 7,
                      ),
                    ),
                  ),
                ],
              ),
            ],
          ),
        ),
        const SizedBox(
          height: 15,
        ),
      ],
    );
  }

  Widget _initialState(_) => Padding(
        padding: const EdgeInsets.symmetric(horizontal: 15),
        child: Text(
          '${widget.post.likes?.length ?? 0}',
          style: GoogleFonts.textMeOne(
            color: Colors.white,
            fontSize: 18,
            fontWeight: FontWeight.w400,
          ),
        ),
      );

  Widget _likeSuccessState(LikeStateSuccess state) {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 15),
      child: Text(
        '${state.likes}',
        style: GoogleFonts.textMeOne(
          color: Colors.white,
          fontSize: 18,
          fontWeight: FontWeight.w400,
        ),
      ),
    );
  }

  double _getIndicatorPercent(int index) {
    final imagesLength = widget.post.postImages?.length ?? 0;
    final songsLength = widget.post.postSongs?.length ?? 0;
    final videosLength = widget.post.postVideos?.length ?? 0;
    return index / (imagesLength + songsLength + videosLength);
  }

  _shouldShowPercentIndicator(Post post) {
    final imagesLength = post.postImages?.length ?? 0;
    final songsLength = post.postSongs?.length ?? 0;
    final videosLength = post.postVideos?.length ?? 0;

    final summ = imagesLength + songsLength + videosLength;

    return summ > 1;
  }

// void _hanldeNewLikes(List<Object> arguments) {}
//
// void _httpClientCreateCallback(Client httpClient) {
//   HttpOverrides.global = HttpOverrideCertificateVerificationInDev();
// }

}

class HttpOverrideCertificateVerificationInDev extends HttpOverrides {
  @override
  HttpClient createHttpClient(SecurityContext? context) {
    return super.createHttpClient(context)
      ..badCertificateCallback = (X509Certificate cert, String host, int port) => true;
  }
}
