import 'package:cached_network_image/cached_network_image.dart';
import 'package:disco_app/data/network/network_models/image_network.dart';
import 'package:flutter/material.dart';

class ImageBody extends StatelessWidget {
  const ImageBody({Key? key, required this.postImage}) : super(key: key);

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
            fit: BoxFit.cover,
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
