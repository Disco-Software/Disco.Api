import 'package:disco_app/res/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import 'package:google_fonts/google_fonts.dart';

class AddAudio extends StatelessWidget {
  const AddAudio({
    Key? key,
    required this.onRecordTap,
    required this.onSelectAudioTap,
  }) : super(key: key);
  final VoidCallback onRecordTap;
  final VoidCallback onSelectAudioTap;

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(15)),
      contentPadding: EdgeInsets.symmetric(vertical: 50.0, horizontal: 20.0),
      backgroundColor: const Color(0xFF2D1848),
      title: Center(
        child: Text('Music selection',
            style: GoogleFonts.aBeeZee(
              fontSize: 28.0,
              fontWeight: FontWeight.w400,
              color: DcColors.white,
            )),
      ),
      content: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          Row(
            children: [
              MusicSelectionButton(
                icon: SvgPicture.asset('assets/ic_micro.svg'),
                title: 'Record voice',
                onTap: onRecordTap,
              ),
              const Spacer(),
              MusicSelectionButton(
                icon: SvgPicture.asset('assets/ic_base.svg'),
                title: 'Select audio',
                onTap: onSelectAudioTap,
              ),
            ],
          )
        ],
      ),
    );
  }
}

class MusicSelectionButton extends StatelessWidget {
  const MusicSelectionButton({
    Key? key,
    required this.icon,
    required this.title,
    required this.onTap,
  }) : super(key: key);
  final Widget icon;
  final String title;
  final VoidCallback onTap;

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        InkWell(
          splashColor: Colors.transparent,
          highlightColor: Colors.transparent,
          onTap: onTap,
          child: Container(
            width: 87,
            height: 78,
            padding: const EdgeInsets.all(24.0),
            decoration: BoxDecoration(
              borderRadius: BorderRadius.circular(5.0),
              color: const Color(0xFF3D1F63),
              boxShadow: const [
                BoxShadow(
                  offset: Offset(0, 4),
                  blurRadius: 5.0,
                  color: Color(0xFFA044FF),
                )
              ],
            ),
            child: icon,
          ),
        ),
        const SizedBox(height: 16),
        Text(
          title,
          style: GoogleFonts.aBeeZee(
            fontSize: 16.0,
            fontWeight: FontWeight.w400,
            color: DcColors.white,
          ),
        ),
      ],
    );
  }
}
