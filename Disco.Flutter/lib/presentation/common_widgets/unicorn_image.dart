import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

class UnicornImage extends StatelessWidget {
  const UnicornImage({
    Key? key,
    this.shouldHaveGradientBorder = true,
    this.shouldHavePlus = false,
    required this.imageUrl,
    required this.title,
  }) : super(key: key);

  final bool shouldHavePlus;
  final bool shouldHaveGradientBorder;
  final String imageUrl;
  final String title;

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Stack(
          alignment: Alignment.bottomRight,
          children: [
            Container(
              decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(12),
                  border: Border.all(color: const Color(0xFF825DCD))),
              child: Container(
                height: 76,
                width: 76,
                margin: const EdgeInsets.all(4.0),
                alignment: Alignment.center,
                decoration: shouldHaveGradientBorder
                    ? BoxDecoration(
                        gradient: const LinearGradient(colors: [
                          Color(0xFF825DCD),
                          Color(0xFFE08D11),
                          Color(0xFFF6EA7D),
                        ]),
                        borderRadius: BorderRadius.circular(12),
                      )
                    : null,
                child: Container(
                  alignment: Alignment.center,
                  decoration: BoxDecoration(
                    borderRadius: BorderRadius.circular(12),
                  ),
                  child: ClipRRect(
                    borderRadius: BorderRadius.circular(12),
                    child: CachedNetworkImage(
                      fit: BoxFit.cover,
                      imageUrl: imageUrl,
                      height: 69,
                      width: 69,
                      errorWidget: (context, string, err) =>
                          Container(color: Colors.white, child: Image.asset('assets/ic_photo.png')),
                    ),
                  ),
                ),
              ),
            ),
            Visibility(
              visible: shouldHavePlus,
              child: Align(
                alignment: Alignment.bottomRight,
                child: Container(
                  decoration: const BoxDecoration(
                    gradient: LinearGradient(
                      colors: [
                        Color(0xFFDE8820),
                        Color(0xFFF6EA7D),
                      ],
                    ),
                    shape: BoxShape.circle,
                  ),
                  child: const Icon(CupertinoIcons.add),
                ),
              ),
            ),
          ],
        ),
        Text(
          title,
          style: GoogleFonts.aBeeZee(
              color: const Color(0xFFE6E0D2), fontWeight: FontWeight.w400, fontSize: 14),
        ),
      ],
    );
  }
}
