import 'package:cached_network_image/cached_network_image.dart';
import 'package:disco_app/core/widgets/post_button.dart';
import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

class UnicornPost extends StatelessWidget {
  const UnicornPost({
    Key? key,
    required this.post,
  }) : super(key: key);

  final Post post;

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
                child: post.profile?.photo != null
                    ? CachedNetworkImage(
                        imageUrl: post.profile?.photo ?? '',
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
              Text(post.profile?.user?.userName ?? "",
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
                imageUrl: post.postImages?.first.source ?? '',
              )),
        ),
        const SizedBox(
          height: 10,
        ),
        Padding(
          padding: const EdgeInsets.symmetric(horizontal: 52),
          child: Text(
            post.description ?? '',
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
}
