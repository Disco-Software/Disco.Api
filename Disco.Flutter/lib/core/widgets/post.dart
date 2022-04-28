import 'package:cached_network_image/cached_network_image.dart';
import 'package:carousel_slider/carousel_slider.dart';
import 'package:disco_app/core/widgets/post_button.dart';
import 'package:disco_app/data/network/network_models/image_network.dart';
import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/data/network/network_models/song_network.dart';
import 'package:disco_app/data/network/network_models/video_network.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:just_audio/just_audio.dart';
import 'package:percent_indicator/linear_percent_indicator.dart';
import 'package:video_player/video_player.dart';

class UnicornPost extends StatefulWidget {
  const UnicornPost({
    Key? key,
    required this.post,
  }) : super(key: key);

  final Post post;

  @override
  State<UnicornPost> createState() => _UnicornPostState();
}

class _UnicornPostState extends State<UnicornPost>
    with SingleTickerProviderStateMixin {
  int bodyIndex = 1;
  late AnimationController controller;

  @override
  void initState() {
    super.initState();
    controller = AnimationController(
        value: 0.3, vsync: this, duration: const Duration(milliseconds: 300));
  }

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
                        placeholder: (context, url) =>
                            Image.asset('assets/ic_photo.png'),
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
            items: [
              if (widget.post.postImages != null &&
                  widget.post.postImages!.isNotEmpty)
                ...widget.post.postImages!
                    .map((postImage) => _ImageBody(
                          postImage: postImage,
                        ))
                    .toList(),
              if (widget.post.postSongs != null &&
                  widget.post.postSongs!.isNotEmpty)
                ...widget.post.postSongs!
                    .map((postSong) => _SongBody(
                          userName: widget.post.profile?.user?.userName ?? "",
                          postSong: postSong,
                        ))
                    .toList(),
              if (widget.post.postVideos != null &&
                  widget.post.postVideos!.isNotEmpty)
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
              PostButton(onTap: () {}, imagePath: "assets/ic_star.svg"),
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
              if (widget.post.postImages != null &&
                  widget.post.postImages!.isNotEmpty)
                AnimatedBuilder(
                  builder: (context, index) => LinearPercentIndicator(
                    width: 100,
                    percent: controller.value,
                    barRadius: const Radius.circular(7),
                    linearGradient: const LinearGradient(
                        colors: [Color(0xFFE08D11), Color(0xFFF6EA7D)]),
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
                  BoxShadow(
                      color: Color(0xFFB2A044FF),
                      offset: Offset(0, 4),
                      blurRadius: 7),
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
  }) : super(key: key);
  final String userName;
  final PostSong postSong;

  @override
  State<_SongBody> createState() => _SongBodyState();
}

class _SongBodyState extends State<_SongBody> {
  late AudioPlayer audioPlayer;

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

  late Widget _switchedWidget;

  @override
  void initState() {
    super.initState();
    _switchedWidget = _switchedPlay;
    audioPlayer = AudioPlayer();
    audioPlayer.setAudioSource(
        AudioSource.uri(Uri.parse(widget.postSong.source ?? '')));
  }

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.start,
      children: [
        if (widget.postSong.imageUrl != null &&
            widget.postSong.imageUrl!.isNotEmpty)
          CachedNetworkImage(
            imageBuilder: (context, imageProvider) => Container(
              height: 105,
              width: 110,
              decoration: BoxDecoration(
                image: DecorationImage(image: imageProvider, fit: BoxFit.fill),
                borderRadius: BorderRadius.circular(12),
                boxShadow: const [
                  BoxShadow(
                      color: Color(0xFFB2A044FF),
                      offset: Offset(0, 4),
                      blurRadius: 7),
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
                    if (audioPlayer.playing) {
                      setState(() {
                        _switchedWidget = _switchedPlay;
                      });
                      audioPlayer.pause();
                    } else {
                      setState(() {
                        _switchedWidget = _switchedPause;
                      });
                      audioPlayer.play();
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
                        child: _switchedWidget,
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
          constraints:
              BoxConstraints(maxWidth: MediaQuery.of(context).size.width * 0.3),
          child: Padding(
            padding: const EdgeInsets.only(bottom: 10.0, left: 13),
            child: Column(
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

  @override
  void initState() {
    super.initState();
    _controller = VideoPlayerController.network(
        "https://www.youtube.com/watch?v=cMIHLzuJ4Wg")
      ..initialize().then((value) => setState(() {}));
  }

  @override
  void dispose() {
    super.dispose();
    _controller.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return InkWell(
        onTap: () {
          if (_controller.value.isPlaying)
            _controller.pause();
          else
            _controller.play();
        },
        child: Container(
          child: _controller.value.isInitialized
              ? AspectRatio(
                  aspectRatio: _controller.value.aspectRatio,
                  child: VideoPlayer(_controller),
                )
              : const SizedBox(),
        ));
  }
}
