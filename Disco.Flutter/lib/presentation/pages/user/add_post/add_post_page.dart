import 'package:auto_route/auto_route.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/presentation/dialogs/add_audio/add_audio.dart';
import 'package:disco_app/presentation/pages/user/add_post/widgets/add_post_appbar.dart';
import 'package:disco_app/presentation/providers/add_post_provider.dart';
import 'package:disco_app/res/colors.dart';
import 'package:disco_app/res/strings.dart';
import 'package:file_picker/file_picker.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:provider/provider.dart';

class AddPostPage extends StatelessWidget {
  const AddPostPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final post = context.read<AddPostProvider>().currentCreatedPost;
    return Scaffold(
      backgroundColor: const Color(0xff1C142E),
      appBar: addPostAppBar(
          context: context,
          actionCallback: () {
            context.router
                .pushAndPopUntil(HomeRoute(shouldLoadData: false), predicate: (route) => false);
            context.read<AddPostProvider>().resetPost();
          }),
      body: Column(children: [
        const Spacer(
          flex: 3,
        ),
        AddPostButton(
          icon: SvgPicture.asset('assets/ic_music.svg'),
          text: 'Music',
          onTap: () => showDialog(
            context: context,
            builder: (ctx) => AddAudio(
              onSelectAudioTap: () async {
                await _selectFile(
                  shouldPop: true,
                  context: context,
                  saveCallback: (result) {
                    post.postSongs.add(result?.files.single.path ?? '');
                    post.postSongImages.add(Strings.defaultSongImage);
                    post.postSongNames.add(Strings.defaultSongName);
                    post.executorNames.add(Strings.defaultSinger);
                  },
                  type: FileType.custom,
                  allowedExtensions: ['mp3', 'mp4', 'wav', 'aac'],
                );
              },
              onRecordTap: () {
                Navigator.of(context, rootNavigator: true).pop();
                context.router.push(const RecordAudioRoute());
              },
            ),
          ),
        ),
        const Spacer(),
        AddPostButton(
          icon: SvgPicture.asset('assets/ic_video.svg'),
          text: 'Video',
          onTap: () async {
            await _selectFile(
              context: context,
              saveCallback: (result) {
                post.postVideos.add(result?.files.single.path ?? '');
              },
              type: FileType.custom,
              allowedExtensions: [
                'WebM',
                'mp4',
                'mp3',
              ],
            );
          },
        ),
        const Spacer(),
        AddPostButton(
          icon: SvgPicture.asset('assets/ic_picture.svg'),
          text: 'Picture',
          onTap: () async {
            await _selectFile(
              context: context,
              saveCallback: (result) {
                context
                    .read<AddPostProvider>()
                    .currentCreatedPost
                    .postImages
                    .add(result?.files.single.path ?? '');
              },
              type: FileType.image,
            );
          },
        ),
        const Spacer(
          flex: 3,
        ),
      ]),
    );
  }

  Future<void> _selectFile({
    required BuildContext context,
    required Function(FilePickerResult? result) saveCallback,
    required FileType type,
    List<String>? allowedExtensions,
    bool shouldPop = false,
  }) async {
    FilePickerResult? result =
        await FilePicker.platform.pickFiles(type: type, allowedExtensions: allowedExtensions);

    if (result != null) {
      saveCallback(result);

      if (shouldPop) Navigator.of(context, rootNavigator: true).pop();
      context.router.push(const SelectFilesRoute());
    } else {
      // User canceled the picker
    }
  }
}

class AddPostButton extends StatelessWidget {
  const AddPostButton({
    Key? key,
    required this.onTap,
    required this.icon,
    required this.text,
  }) : super(key: key);
  final VoidCallback onTap;
  final Widget icon;
  final String text;

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: onTap,
      highlightColor: Colors.transparent,
      splashColor: Colors.transparent,
      child: Container(
        margin: const EdgeInsets.symmetric(horizontal: 93.0),
        height: 58.0,
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(30.0),
          border: Border.all(color: DcColors.white, width: 2.0),
        ),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
          children: [
            icon,
            Text(
              text,
              style: GoogleFonts.aBeeZee(
                fontSize: 28.0,
                color: const Color(0xFFE6E0D2),
              ),
            ),
            SvgPicture.asset('assets/ic_big_plus.svg'),
          ],
        ),
      ),
    );
  }
}
