import 'package:cached_network_image/cached_network_image.dart';
import 'package:carousel_slider/carousel_slider.dart';
import 'package:disco_app/core/widgets/post_button.dart';
import 'package:disco_app/core/widgets/unicorn_outline_button.dart';
import 'package:disco_app/data/network/network_models/image_network.dart';
import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/data/network/network_models/song_network.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:google_fonts/google_fonts.dart';
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

class _UnicornPostState extends State<UnicornPost>
    with SingleTickerProviderStateMixin {
  int bodyIndex = 1;
  late AnimationController controller;

  @override
  void initState() {
    // TODO: implement initState
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
        CarouselSlider(
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
                        postSong: postSong,
                      ))
                  .toList(),
            //  const _VideoBody()
          ],
          options: CarouselOptions(
              viewportFraction: 1.0,
              onPageChanged: (index, reason) {
                controller.animateTo(_getIndicatorPercent(index + 1));
              }),
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
          padding: const EdgeInsets.symmetric(horizontal: 52),
          child: CachedNetworkImage(
            imageBuilder: (context, imageProvider) => Container(
              height: 184,
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

class _SongBody extends StatelessWidget {
  const _SongBody({Key? key, required this.postSong}) : super(key: key);

  final PostSong postSong;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 38),
      child: Row(
        children: [
          if (postSong.imageUrl != null && postSong.imageUrl!.isNotEmpty)
            CachedNetworkImage(
              imageBuilder: (context, imageProvider) => Container(
                height: 105,
                width: 110,
                decoration: BoxDecoration(
                  image:
                      DecorationImage(image: imageProvider, fit: BoxFit.fill),
                  borderRadius: BorderRadius.circular(12),
                  boxShadow: const [
                    BoxShadow(
                        color: Color(0xFFB2A044FF),
                        offset: Offset(0, 4),
                        blurRadius: 7),
                  ],
                ),
              ),
              imageUrl: postSong.imageUrl ?? '',
              errorWidget: (context, url, error) => const SizedBox(),
            ),
          const SizedBox(
            width: 14,
          ),
          Padding(
            padding: const EdgeInsets.symmetric(vertical: 80),
            child: UnicornOutlineButton(
                strokeWidth: 3.0,
                radius: 360,
                gradient: const LinearGradient(colors: [
                  Color(0xffDE9237),
                  Color(0xFFF6EA7D),
                ]),
                child: Center(
                  child: SvgPicture.asset(
                    'assets/ic_play.svg',
                    height: 50,
                    width: 50,
                  ),
                ),
                onPressed: () {}),
          ),
          const SizedBox(width: 14),
          SizedBox(
            width: 100,
            child: Column(
              mainAxisSize: MainAxisSize.min,
              children: [
                Text(
                  postSong.name ?? "",
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
          const SizedBox(
            width: 14,
          ),
        ],
      ),
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
