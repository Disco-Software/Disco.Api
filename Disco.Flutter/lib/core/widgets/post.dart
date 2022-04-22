import 'package:cached_network_image/cached_network_image.dart';
import 'package:carousel_slider/carousel_slider.dart';
import 'package:disco_app/core/widgets/post_button.dart';
import 'package:disco_app/data/network/network_models/image_network.dart';
import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/data/network/network_models/song_network.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_audio_waveforms/flutter_audio_waveforms.dart';
import 'package:flutter_svg/svg.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:just_audio/just_audio.dart';
import 'package:percent_indicator/linear_percent_indicator.dart';

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

  @override
  void initState() {
    super.initState();
    controller =
        AnimationController(value: 0.3, vsync: this, duration: const Duration(milliseconds: 300));
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
            items: [
              if (widget.post.postImages != null && widget.post.postImages!.isNotEmpty)
                ...widget.post.postImages!
                    .map((postImage) => _ImageBody(
                          postImage: postImage,
                        ))
                    .toList(),
              if (widget.post.postSongs != null && widget.post.postSongs!.isNotEmpty)
                ...widget.post.postSongs!
                    .map((postSong) => _SongBody(
                          postSong: postSong,
                        ))
                    .toList(),
              //  const _VideoBody()
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
              if (widget.post.postImages != null && widget.post.postImages!.isNotEmpty)
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
  const _SongBody({Key? key, required this.postSong}) : super(key: key);

  final PostSong postSong;

  @override
  State<_SongBody> createState() => _SongBodyState();
}

class _SongBodyState extends State<_SongBody> with SingleTickerProviderStateMixin {
  AudioPlayer audioPlayer = AudioPlayer();
  late AnimationController controller;
  late Animation<double> animation;

  @override
  void initState() {
    super.initState();

    controller = AnimationController(
      vsync: this,
      duration: const Duration(seconds: 1),
      value: 1.0,
    );
    animation = CurvedAnimation(
      parent: controller,
      curve: Curves.fastOutSlowIn,
    );
    audioPlayer.setAudioSource(AudioSource.uri(Uri.parse(widget.postSong.source ?? '')));
  }

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.start,
      children: [
        if (widget.postSong.imageUrl != null && widget.postSong.imageUrl!.isNotEmpty)
          SizeTransition(
            sizeFactor: animation,
            axis: Axis.horizontal,
            axisAlignment: -1,
            child: CachedNetworkImage(
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
            ),
          )
        else
          Container(
            color: Colors.green,
            height: 105,
            width: 110,
          ),
        if (animation.isCompleted)
          AnimatedBuilder(
            builder: (ctx, child) => const Spacer(),
            animation: animation,
          ),
        Padding(
          padding: const EdgeInsets.only(bottom: 50.0),
          child: Stack(
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
                        audioPlayer.pause();
                        controller.forward();
                      } else {
                        controller.reverse();
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
                        child: Padding(
                          padding: const EdgeInsets.all(4.0),
                          child: SvgPicture.asset(
                            'assets/ic_play.svg',
                            color: Color(0xffDE9237),
                          ),
                        ),
                      ),
                    ),
                  ),
                ),
              ),
            ],
          ),
        ),
        const Spacer(),
        AnimatedBuilder(
          builder: (context, child) => AnimatedSwitcher(
            duration: const Duration(seconds: 1),
            transitionBuilder: (Widget child, Animation<double> animation) {
              return FadeTransition(opacity: animation, child: child);
            },
            child: animation.status != AnimationStatus.completed
                ? SquigglyWaveform(
                    absolute: true,
                    maxDuration: audioPlayer.duration,
                    activeColor: Colors.purple,
                    strokeWidth: 2,
                    showActiveWaveform: true,
                    inactiveColor: Colors.grey,
                    elapsedDuration: audioPlayer.position,
                    samples: [1, 2, 3, 4, 5],
                    height: 80.0,
                    width: 150.0,
                  )
                : Padding(
                    padding: const EdgeInsets.only(bottom: 10.0),
                    child: Column(
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
                          'singer',
                          maxLines: 1,
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
          animation: animation,
        ),
        const Spacer(flex: 3),
      ],
    );
  }
}

class _VideoBody extends StatelessWidget {
  const _VideoBody({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(color: Colors.green);
  }
}
