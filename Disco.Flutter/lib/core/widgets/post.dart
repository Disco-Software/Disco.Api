import 'dart:async';

import 'package:cached_network_image/cached_network_image.dart';
import 'package:carousel_slider/carousel_slider.dart';
import 'package:chewie/chewie.dart';
import 'package:disco_app/core/widgets/post_button.dart';
import 'package:disco_app/data/local/local_storage.dart';
import 'package:disco_app/data/network/network_models/image_network.dart';
import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/data/network/network_models/song_network.dart';
import 'package:disco_app/data/network/network_models/video_network.dart';
import 'package:disco_app/providers/post_provider.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:just_audio/just_audio.dart';
import 'package:percent_indicator/linear_percent_indicator.dart';
import 'package:provider/provider.dart';
import 'package:signalr_netcore/hub_connection.dart';
import 'package:signalr_netcore/ihub_protocol.dart';
import 'package:signalr_netcore/signalr_client.dart';
import 'package:video_player/video_player.dart';

import '../../injection.dart';

const String serverUrl = 'https://devdiscoapi.azurewebsites.net/hub/like';

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
  late HubConnection hubConnection;

  @override
  void initState() {
    super.initState();
    initSignalR();
    // hubConnectionStart();
    controller =
        AnimationController(value: 0.3, vsync: this, duration: const Duration(milliseconds: 300));
  }

  void initSignalR() {
    final headers = MessageHeaders();
    // headers.setHeaderValue('Authorization', token);
    hubConnection = HubConnectionBuilder()
        .withUrl(serverUrl,
            options: HttpConnectionOptions(
                accessTokenFactory: () =>
                    Future.value(getIt.get<SecureStorageRepository>().read(key: 'token'))))
        .build();
    hubConnection.onclose(
      ({error}) => print('Connection close'),
    );
    // hubConnection.on('', (args) {});
  }

  // Future<void> hubConnectionStart() async => await hubConnection.start();

  @override
  Widget build(BuildContext context) {
    return Column(
      mainAxisSize: MainAxisSize.min,
      children: [
        Container(
          padding: const EdgeInsets.symmetric(vertical: 8),
          color: const Color(0xFF201636),
          child: Row(
            mainAxisSize: MainAxisSize.min,
            children: [
              Container(
                height: 60,
                width: 80,
                decoration: const BoxDecoration(
                    borderRadius: BorderRadius.only(
                      topRight: Radius.circular(80),
                      bottomRight: Radius.circular(80),
                    ),
                    boxShadow: [
                      BoxShadow(
                          color: Color(0xFFB21887D7),
                          offset: Offset(2, 3),
                          spreadRadius: 7,
                          blurRadius: 7)
                    ]),
                child: widget.post.profile?.photo != null
                    ? CachedNetworkImage(
                        imageUrl: widget.post.profile?.photo ?? '',
                        placeholder: (context, url) => Image.asset('assets/ic_photo.png'),
                        fit: BoxFit.fill,
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
                          fit: BoxFit.fill,
                        ),
                      ),
              ),
              const SizedBox(
                width: 16,
              ),
              Text(widget.post.profile?.user?.userName ?? "",
                  style: GoogleFonts.aBeeZee(
                    color: const Color(0xFFE6E0D2),
                    fontSize: 24,
                  )),
              const Spacer(),
            ],
          ),
        ),
        const SizedBox(height: 27),
        Padding(
          padding: const EdgeInsets.symmetric(horizontal: 35),
          child: CarouselSlider(
            carouselController: carouselController,
            items: [
              if (widget.post.postSongs != null && widget.post.postSongs!.isNotEmpty)
                ...widget.post.postSongs!
                    .map((postSong) => _SongBody(
                          userName: widget.post.profile?.user?.userName ?? "",
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
                    .map((postImage) => _ImageBody(
                          postImage: postImage,
                        ))
                    .toList(),
              if (widget.post.postVideos != null && widget.post.postVideos!.isNotEmpty)
                ...widget.post.postVideos!
                    .map((postVideo) => _VideoBody(
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
                    try {
                      await hubConnection.start();
                    } catch (err) {
                      print('$err lol1 ${hubConnection.state}');
                      if (hubConnection.state == HubConnectionState.Connected) {
                        hubConnection.invoke('create', args: <Object>[widget.post.id ?? 0]);
                      }
                    }
                    setState(() {});
                  },
                  imagePath: "assets/ic_star.svg"),
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 15),
                child: Text(
                  '1.5k',
                  style: GoogleFonts.textMeOne(
                    color: Colors.white,
                    fontSize: 18,
                    fontWeight: FontWeight.w400,
                  ),
                ),
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
                    top: 10,
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

  void _hanldeNewLikes(List<Object> arguments) {}
}

class _ImageBody extends StatelessWidget {
  const _ImageBody({Key? key, required this.postImage}) : super(key: key);

  final PostImage postImage;

  @override
  Widget build(BuildContext context) {
    return Column(
      mainAxisSize: MainAxisSize.min,
      children: [
        Padding(
          padding: const EdgeInsets.symmetric(horizontal: 17),
          child: CachedNetworkImage(
            imageBuilder: (context, imageProvider) => Container(
              height: 175,
              decoration: BoxDecoration(
                image: DecorationImage(image: imageProvider, fit: BoxFit.fill),
                borderRadius: BorderRadius.circular(12),
                boxShadow: const [
                  BoxShadow(color: Color(0xFFB2A044FF), offset: Offset(0, 4), blurRadius: 7),
                ],
              ),
            ),
            imageUrl: postImage.source ?? '',
          ),
        ),
        // const SizedBox(
        //   height: 5,
        // ),
      ],
    );
  }
}

class _SongBody extends StatefulWidget {
  const _SongBody({
    Key? key,
    required this.postSong,
    required this.userName,
    required this.songSources,
    required this.songTitles,
    required this.carouselController,
    required this.post,
    required this.currentPageIndex,
  }) : super(key: key);
  final String userName;
  final PostSong postSong;
  final List<String> songSources;
  final List<String> songTitles;
  final CarouselController carouselController;
  final Post post;
  final int currentPageIndex;

  @override
  State<_SongBody> createState() => _SongBodyState();
}

class _SongBodyState extends State<_SongBody> {
  late StreamSubscription subscription;

  final Widget _switchedPause = Padding(
    key: const ValueKey(1),
    padding: const EdgeInsets.all(4.0),
    child: Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Image.asset('assets/ic_rectangle.png'),
        Image.asset('assets/ic_rectangle.png'),
      ],
    ),
  );

  final Widget _switchedPlay = Padding(
    padding: const EdgeInsets.all(4.0),
    child: Image.asset(
      'assets/ic_play.png',
      color: const Color(0xffDE9237),
    ),
  );

  @override
  void initState() {
    super.initState();

    subscription =
        context.read<PostProvider>().player.playerStateStream.listen((PlayerState state) async {
      final provider = Provider.of<PostProvider>(context, listen: false);
      if (state.processingState == ProcessingState.completed) {
        await provider.player.stop();
        setState(() {});
      }

      // if (event) {
      //   animationController.forward();
      //   setState(() {
      //     isPlaying = true;
      //   });
      // } else if (!event) {
      //   setState(() {
      //     isPlaying = false;
      //   });
      // }
    });
  }

  @override
  void dispose() {
    super.dispose();
    subscription.cancel();
  }

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.start,
      children: [
        if (widget.postSong.imageUrl != null && widget.postSong.imageUrl!.isNotEmpty)
          CachedNetworkImage(
            imageBuilder: (context, imageProvider) => Container(
              height: 105,
              width: 110,
              decoration: BoxDecoration(
                image: DecorationImage(image: imageProvider, fit: BoxFit.fill),
                borderRadius: BorderRadius.circular(12),
                boxShadow: const [
                  BoxShadow(color: Color(0xFFB2A044FF), offset: Offset(0, 4), blurRadius: 7),
                ],
              ),
            ),
            imageUrl: widget.postSong.imageUrl ?? '',
            errorWidget: (context, url, error) => const SizedBox(),
          )
        else
          Container(
            color: Colors.green,
            height: 105,
            width: 110,
          ),
        //const Spacer(),
        const SizedBox(
          width: 14,
        ),
        Stack(
          children: [
            Container(
              height: 55.0,
              width: 55.0,
              decoration: const BoxDecoration(
                shape: BoxShape.circle,
                gradient: LinearGradient(colors: [
                  Color(0xffDE9237),
                  Color(0xFFF6EA7D),
                ]),
              ),
              child: Material(
                color: Colors.transparent,
                borderRadius: BorderRadius.circular(360),
                child: InkWell(
                  onTap: () {
                    final provider = Provider.of<PostProvider>(context, listen: false);

                    final oldPost = provider.oldPost;
                    if (widget.postSong.id != oldPost.id) {
                      provider.setSongIndex(0);
                    }
                    provider.setUrl(widget.postSong.source ?? '');
                    provider.setPostSong(widget.postSong);
                    provider.setSinger(widget.userName);
                    provider.setAudioSources(widget.songSources);
                    provider.setAudioTitles(widget.songTitles);
                    provider.setSongIndex(widget.currentPageIndex);
                    provider.setCarouselController(widget.carouselController);
                    if (provider.player.playing) {
                      print('lolPAUSE');
                      provider.player.pause();
                    } else {
                      print('lolPLAY');

                      provider.player.play();
                    }
                  },
                  borderRadius: BorderRadius.circular(360),
                  child: Center(
                    child: Container(
                      height: 50.0,
                      width: 50.0,
                      decoration: const BoxDecoration(
                        shape: BoxShape.circle,
                        color: DcColors.bottomBarLeft,
                      ),
                      child: AnimatedSwitcher(
                        duration: const Duration(milliseconds: 300),
                        transitionBuilder: (child, animation) => FadeTransition(
                          opacity: animation,
                          child: child,
                        ),
                        child: Consumer<PostProvider>(
                          builder: (BuildContext context, value, Widget? child) {
                            if (value.songSources[value.currentSongIndex] ==
                                    widget.postSong.source &&
                                value.player.playing) {
                              return _switchedPause;
                            } else {
                              return _switchedPlay;
                            }
                          },
                        ),
                      ),
                    ),
                  ),
                ),
              ),
            ),
          ],
        ),
        const Spacer(),
        ConstrainedBox(
          constraints: BoxConstraints(maxWidth: MediaQuery.of(context).size.width * 0.3),
          child: Padding(
            padding: const EdgeInsets.only(bottom: 10.0, left: 13),
            child: Consumer<PostProvider>(
              builder: (context, data, child) => Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                mainAxisSize: MainAxisSize.min,
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: [
                  Text(
                    widget.postSong.name ?? "",
                    maxLines: 1,
                    style: GoogleFonts.aBeeZee(
                      color: DcColors.darkWhite,
                      fontWeight: FontWeight.w400,
                      fontSize: 24,
                    ),
                    overflow: TextOverflow.ellipsis,
                  ),
                  Text(
                    widget.userName,
                    maxLines: 1,
                    textAlign: TextAlign.start,
                    overflow: TextOverflow.ellipsis,
                    style: GoogleFonts.textMeOne(
                      color: DcColors.white,
                      fontWeight: FontWeight.w400,
                      fontSize: 24,
                    ),
                  ),
                ],
              ),
            ),
          ),
        ),
        const Spacer(flex: 3),
      ],
    );
  }
}

class _VideoBody extends StatefulWidget {
  const _VideoBody({Key? key, required this.postVideo}) : super(key: key);

  final PostVideo postVideo;

  @override
  State<_VideoBody> createState() => _VideoBodyState();
}

class _VideoBodyState extends State<_VideoBody> {
  late VideoPlayerController _controller;
  late ChewieController _chewieController;

  @override
  void initState() {
    super.initState();
    _controller = VideoPlayerController.network(widget.postVideo.videoSource ?? '')
      ..initialize().then((value) {
        setState(() {});
      });
    _chewieController = ChewieController(
      videoPlayerController: _controller,
      autoPlay: true,
      deviceOrientationsAfterFullScreen: [DeviceOrientation.portraitUp],
    );
  }

  @override
  void dispose() {
    super.dispose();
    _controller.dispose();
    _chewieController.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Container(
        decoration: BoxDecoration(
          color: Colors.black,
          borderRadius: BorderRadius.circular(12.0),
        ),
        child: Chewie(
          controller: _chewieController,
        ));
  }
}
