import 'package:auto_route/auto_route.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/dialogs/add_audio/add_audio.dart';
import 'package:disco_app/pages/user/add_post/widgets/add_post_appbar.dart';
import 'package:disco_app/providers/add_post_provider.dart';
import 'package:disco_app/res/colors.dart';
import 'package:file_picker/file_picker.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:provider/src/provider.dart';

class AddPostPage extends StatelessWidget {
  const AddPostPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xff1C142E),
      appBar: addPostAppBar(context),
      body: Column(children: [
        const Spacer(
          flex: 3,
        ),
        AddPostButton(
          icon: SvgPicture.asset('assets/ic_music.svg'),
          text: 'Music',
          onTap: () {
            showDialog(
              context: context,
              builder: (ctx) => AddAudio(
                onSelectAudioTap: () async {
                  await _selectFile(context, (result) {
                    context
                        .read<AddPostProvider>()
                        .currentCreatedPost
                        .postSongs
                        .add(result?.files.single.path ?? '');
                  });
                },
                onRecordTap: () {
                  Navigator.of(context, rootNavigator: true).pop();
                  context.router.push(const RecordAudioRoute());
                },
              ),
            );
          },
        ),
        const Spacer(),
        AddPostButton(
          icon: SvgPicture.asset('assets/ic_video.svg'),
          text: 'Video',
          onTap: () async {
            await _selectFile(context, (result) {
              context
                  .read<AddPostProvider>()
                  .currentCreatedPost
                  .postVideos
                  .add(result?.files.single.path ?? '');
            });
          },
        ),
        const Spacer(),
        AddPostButton(
          icon: SvgPicture.asset('assets/ic_picture.svg'),
          text: 'Picture',
          onTap: () async {
            await _selectFile(context, (result) {
              context
                  .read<AddPostProvider>()
                  .currentCreatedPost
                  .postImages
                  .add(result?.files.single.path ?? '');
            });
          },
        ),
        const Spacer(
          flex: 3,
        ),
      ]),
    );
  }

  Future<void> _selectFile(
      BuildContext context, Function(FilePickerResult? result) saveCallback) async {
    FilePickerResult? result = await FilePicker.platform.pickFiles();

    if (result != null) {
      saveCallback(result);

      Navigator.of(context, rootNavigator: true).pop();
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
