import 'dart:async';

import 'package:auto_route/auto_route.dart';
import 'package:carousel_slider/carousel_controller.dart';
import 'package:carousel_slider/carousel_slider.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/presentation/pages/user/add_post/widgets/add_post_appbar.dart';
import 'package:disco_app/presentation/pages/user/add_post/widgets/audio_card.dart';
import 'package:disco_app/presentation/pages/user/add_post/widgets/image_card.dart';
import 'package:disco_app/presentation/providers/add_post_provider.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:image_picker/image_picker.dart';
import 'package:just_audio/just_audio.dart';
import 'package:provider/provider.dart';
import 'package:provider/src/provider.dart';

import 'widgets/video_card.dart';

class SelectFilesPage extends StatefulWidget {
  const SelectFilesPage({Key? key}) : super(key: key);

  @override
  State<SelectFilesPage> createState() => _SelectFilesPageState();
}

class _SelectFilesPageState extends State<SelectFilesPage> {
  final textController = TextEditingController();
  final CarouselController audioCarouselController = CarouselController();
  final CarouselController videoCarouselController = CarouselController();
  Timer? _debounce;
  List<bool> _editModes = [];
  bool _isLoading = false;

  int _songIndex = 0;
  int _videoIndex = 0;
  int _imageIndex = 0;

  @override
  void initState() {
    context.read<AddPostProvider>().currentCreatedPost.postSongNames.forEach((element) {
      _editModes.add(false);
    });
    super.initState();
  }

  @override
  void dispose() {
    textController.dispose();
    _debounce?.cancel();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    final post = context.read<AddPostProvider>().currentCreatedPost;
    return Scaffold(
      floatingActionButton: FloatingActionButton(
        backgroundColor: DcColors.violet,
        onPressed: () {
          context.router.pushAndPopUntil(const AddPostRoute(), predicate: (route) => false);
        },
        child: Padding(
          padding: const EdgeInsets.only(top: 5.0),
          child: SvgPicture.asset(
            "assets/ic_plus.svg",
            width: 40,
            height: 40,
          ),
        ),
      ),
      backgroundColor: const Color(0xff1C142E),
      appBar: addPostAppBar(
        context: context,
        actionCallback: () =>
            context.router.pushAndPopUntil(const AddPostRoute(), predicate: (route) => false),
        actionSave: () async {
          try {
            setState(() {
              _isLoading = true;
            });
            await context.read<AddPostProvider>().createPost();
            context.read<AddPostProvider>().resetPost();
            context.router.pushAndPopUntil(HomeRoute(), predicate: (route) => false);
          } catch (err) {
            setState(() {
              _isLoading = false;
            });
          }
        },
        ignoreSave: _isLoading,
      ),
      body: Stack(
        children: [
          Container(
            decoration: const BoxDecoration(
              gradient: RadialGradient(
                colors: [Color(0xFF2D2053), Color(0xFF211637)],
              ),
            ),
            child: GestureDetector(
              onTap: () => FocusScope.of(context).unfocus(),
              child: ListView(
                children: [
                  const SizedBox(height: 30.0),
                  Padding(
                    padding: const EdgeInsets.symmetric(horizontal: 48.0),
                    child: TextFormField(
                      controller: textController,
                      maxLines: 2,
                      style: const TextStyle(color: DcColors.darkWhite),
                      onChanged: (value) {
                        if (_debounce?.isActive ?? false) _debounce?.cancel();
                        _debounce = Timer(const Duration(milliseconds: 500), () {
                          context.read<AddPostProvider>().currentCreatedPost.description = value;
                        });
                      },
                      decoration: InputDecoration(
                        hintText: 'description...',
                        border: OutlineInputBorder(
                            borderRadius: BorderRadius.circular(10.0),
                            borderSide: const BorderSide(color: DcColors.darkWhite)),
                      ),
                    ),
                  ),
                  const SizedBox(height: 40.0),
                  if (post.postSongs.isNotEmpty)
                    Padding(
                      padding: const EdgeInsets.symmetric(horizontal: 35.0),
                      child: CarouselSlider(
                        items: _getSongItems(context),
                        options: CarouselOptions(
                          viewportFraction: 1.0,
                          enableInfiniteScroll: false,
                          onScrolled: (position) {},
                          onPageChanged: (index, reason) {
                            setState(() {
                              _songIndex = index;
                            });
                          },
                        ),
                      ),
                    ),
                  Consumer<AddPostProvider>(
                    builder: (ctx, data, child) => data.currentCreatedPost.postSongs.length > 1
                        ? DotsProgressBar(
                            itemIndex: _songIndex,
                            length: data.currentCreatedPost.postSongs.length,
                          )
                        : const SizedBox(),
                  ),
                  const SizedBox(height: 20.0),
                  if (post.postVideos.isNotEmpty)
                    Padding(
                      padding: const EdgeInsets.symmetric(horizontal: 35.0),
                      child: CarouselSlider(
                        items: _getVideoItems(context),
                        options: CarouselOptions(
                          viewportFraction: 1.0,
                          enableInfiniteScroll: false,
                          onPageChanged: (index, reason) {
                            setState(() {
                              _videoIndex = index;
                            });
                          },
                        ),
                      ),
                    ),
                  const SizedBox(height: 20.0),
                  Consumer<AddPostProvider>(
                    builder: (ctx, data, child) => data.currentCreatedPost.postVideos.length > 1
                        ? DotsProgressBar(
                            itemIndex: _videoIndex,
                            length: data.currentCreatedPost.postSongs.length,
                          )
                        : const SizedBox(),
                  ),
                  const SizedBox(height: 20.0),
                  if (post.postImages.isNotEmpty)
                    Padding(
                      padding: const EdgeInsets.symmetric(horizontal: 35.0),
                      child: CarouselSlider(
                        items: _getImageItems(context),
                        options: CarouselOptions(
                          viewportFraction: 1.0,
                          enableInfiniteScroll: false,
                          onPageChanged: (index, reason) {
                            setState(() {
                              _imageIndex = index;
                            });
                          },
                        ),
                      ),
                    ),
                  const SizedBox(height: 20.0),
                  Consumer<AddPostProvider>(
                    builder: (ctx, data, child) => data.currentCreatedPost.postImages.length > 1
                        ? DotsProgressBar(
                            itemIndex: _imageIndex,
                            length: data.currentCreatedPost.postSongs.length,
                          )
                        : const SizedBox(),
                  ),
                  const SizedBox(height: 40.0),
                ],
              ),
            ),
          ),
          if (_isLoading)
            const Center(
                child: SizedBox(height: 100.0, width: 100.0, child: CircularProgressIndicator())),
        ],
      ),
    );
  }

  _getSongItems(BuildContext ctx) {
    final List<Widget> songs = [];
    final post = ctx.read<AddPostProvider>().currentCreatedPost;
    for (int i = 0; i < post.postSongs.length; i++) {
      songs.add(AudioCard(
        onSaved: (name, singer) {
          context.read<AddPostProvider>().editSongTexts(
                name: name,
                executor: singer,
                index: i,
              );
          _editModes = _editModes.map((e) => e = false).toList();
          setState(() {});
        },
        key: ValueKey('$i'),
        title: post.postSongNames[i],
        singer: post.executorNames[i],
        onTap: () async {
          final ImagePicker _picker = ImagePicker();
          final XFile? image = await _picker.pickImage(source: ImageSource.gallery);
          context.read<AddPostProvider>().setSongImages(image?.path ?? '', i);
          setState(() {});
        },
        onThreeDotsTap: () {
          showCupertinoModalPopup(
              context: context,
              builder: (context) => CupertinoActionSheet(
                    cancelButton: CupertinoActionSheetAction(
                      onPressed: () => Navigator.of(context, rootNavigator: true).pop(),
                      child: const Text('Cancel'),
                    ),
                    actions: [
                      CupertinoActionSheetAction(
                        onPressed: () {
                          _editModes[i] = true;
                          Navigator.of(context, rootNavigator: true).pop();
                          setState(() {});
                        },
                        child: const Text('Rename track'),
                      ),
                      CupertinoActionSheetAction(
                        onPressed: () {},
                        child: const Text('Edit track'),
                      ),
                      CupertinoActionSheetAction(
                        onPressed: () {},
                        child: const Text('Delete'),
                      ),
                    ],
                  ));
        },
        songImage: post.postSongImages[i],
        onPlay: (_currentAudio) {
          final path = context.read<AddPostProvider>().currentCreatedPost.postSongs[i];
          try {
            _currentAudio.setFilePath(path);
            if (_currentAudio.playing) {
              _currentAudio.pause();
            } else {
              _currentAudio.play();
            }
          } on PlayerException catch (e) {
            // iOS/macOS: maps to NSError.code
            // Android: maps to ExoPlayerException.type
            // Web: maps to MediaError.code
            // Linux/Windows: maps to PlayerErrorCode.index
            print("Error code: ${e.code}");
            // iOS/macOS: maps to NSError.localizedDescription
            // Android: maps to ExoPlaybackException.getMessage()
            // Web/Linux: a generic message
            // Windows: MediaPlayerError.message
            print("Error message: ${e.message}");
          } on PlayerInterruptedException catch (e) {
            // This call was interrupted since another audio source was loaded or the
            // player was stopped or disposed before this audio source could complete
            // loading.
            print("Connection aborted: ${e.message}");
          } catch (e) {
            // Fallback for all errors
            print(e);
          }
          setState(() {});
        },
        editMode: _editModes[i],
      ));
    }
    return songs;
  }

  _getVideoItems(BuildContext ctx) {
    final List<Widget> videos = [];
    final post = ctx.read<AddPostProvider>().currentCreatedPost;
    for (int i = 0; i < post.postVideos.length; i++) {
      videos.add(VideoCard(
        source: post.postVideos[i],
        onThreeDotsTap: () {},
      ));
    }

    return videos;
  }

  _getImageItems(BuildContext ctx) {
    final List<Widget> images = [];
    final post = ctx.read<AddPostProvider>().currentCreatedPost;
    for (int i = 0; i < post.postImages.length; i++) {
      images.add(ImageCard(
        source: post.postImages[i],
        onThreeDotsTap: () {},
      ));
    }

    return images;
  }
}

class DotsProgressBar extends StatelessWidget {
  const DotsProgressBar({
    Key? key,
    required this.itemIndex,
    required this.length,
  }) : super(key: key);

  final int itemIndex;
  final int length;

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: 10.0,
      child: Row(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          SizedBox(
            height: 10.0,
            child: ListView.builder(
                shrinkWrap: true,
                itemCount: length,
                scrollDirection: Axis.horizontal,
                itemBuilder: (ctx, index) {
                  return Padding(
                    padding: const EdgeInsets.symmetric(horizontal: 3.0),
                    child: ProgressCircle(
                      colors: index == itemIndex
                          ? const [Color(0xFFE08D11), Color(0xFFF6EA7D)]
                          : const [Color(0xFFC9D6FF)],
                    ),
                  );
                }),
          ),
        ],
      ),
    );
  }
}

class ThreeDots extends StatelessWidget {
  const ThreeDots({
    Key? key,
    required this.onTap,
  }) : super(key: key);

  final VoidCallback onTap;

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: onTap,
      child: Padding(
        padding: const EdgeInsets.all(8.0),
        child: Row(
          mainAxisSize: MainAxisSize.min,
          children: [
            for (int i = 0; i < 3; i++)
              Container(
                  width: 4,
                  height: 4,
                  margin: const EdgeInsets.symmetric(horizontal: 1.0),
                  decoration: const BoxDecoration(
                    shape: BoxShape.circle,
                    color: DcColors.darkWhite,
                  ))
          ],
        ),
      ),
    );
  }
}

class ProgressCircle extends StatelessWidget {
  final List<Color> colors;

  const ProgressCircle({
    Key? key,
    required this.colors,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      width: 12.0,
      height: 12.0,
      decoration: colors.length > 1
          ? BoxDecoration(
              shape: BoxShape.circle,
              gradient: LinearGradient(colors: colors),
            )
          : BoxDecoration(
              shape: BoxShape.circle,
              color: colors.first,
            ),
    );
  }
}
