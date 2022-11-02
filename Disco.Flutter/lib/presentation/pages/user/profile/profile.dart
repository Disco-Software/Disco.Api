import 'dart:math';

import 'package:auto_route/auto_route.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/data/local/local_storage.dart';
import 'package:disco_app/res/colors.dart';
import 'package:disco_app/res/strings.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../../injection.dart';

class ProfilePage extends StatefulWidget {
  const ProfilePage({Key? key}) : super(key: key);

  @override
  State<ProfilePage> createState() => _ProfilePageState();
}

class _ProfilePageState extends State<ProfilePage> {
  bool _shouldShowSaved = false;
  final userName = getIt.get<SecureStorageRepository>().read(key: Strings.userName);
  final userPhoto = getIt.get<SecureStorageRepository>().read(key: Strings.userPhoto);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: Drawer(
        child: ColoredBox(
          color: DcColors.darkViolet,
          child: SafeArea(
            child: Column(
              children: [
                _IconButton(
                  text: 'Edit',
                  icon: CupertinoIcons.pen,
                  onTap: () {},
                ),
                const SizedBox(height: 20),
                _IconButton(
                  text: 'Log Out',
                  icon: CupertinoIcons.greaterthan_circle,
                  onTap: () async {
                    await getIt.get<SecureStorageRepository>().deleteAll();
                    context.router.replace(const SplashRoute());
                  },
                ),
              ],
            ),
          ),
        ),
      ),
      backgroundColor: DcColors.darkViolet,
      body: CustomScrollView(
        slivers: [
          SliverAppBar(
            backgroundColor: DcColors.darkViolet,
            leading: const SizedBox(),
            leadingWidth: 0,
            centerTitle: false,
            title: const Text(
              "DISCO",
              style: TextStyle(
                fontSize: 32,
                fontFamily: 'Colonna',
                fontWeight: FontWeight.bold,
              ),
              textAlign: TextAlign.start,
            ),
            actions: [
              Builder(builder: (context) {
                return InkWell(
                    onTap: () {
                      Scaffold.of(context).openDrawer();
                    },
                    child: const Padding(
                      padding: EdgeInsets.only(right: 20),
                      child: Icon(CupertinoIcons.list_bullet),
                    ));
              })
            ],
          ),
          SliverList(
              delegate: SliverChildListDelegate(
            [
              Stack(
                alignment: Alignment.topCenter,
                children: [
                  DecoratedBox(
                    decoration: const BoxDecoration(
                      boxShadow: [
                        BoxShadow(color: Color(0xffb2a044ff), offset: Offset(0, 5), blurRadius: 10),
                      ],
                      borderRadius: BorderRadius.only(
                        bottomLeft: Radius.circular(100),
                        bottomRight: Radius.circular(100),
                      ),
                    ),
                    child: ClipRRect(
                      borderRadius: const BorderRadius.only(
                        bottomLeft: Radius.circular(100),
                        bottomRight: Radius.circular(100),
                      ),
                      child: FutureBuilder(
                          future: userPhoto,
                          builder: (context, data) {
                            if (data.hasData) {
                              return Image.network(
                                '${data.data}',
                                height: 270,
                                width: 300,
                                fit: BoxFit.cover,
                                alignment: Alignment.center,
                                errorBuilder: (ctx, onj, trace) => Image.network(
                                  'https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Image_created_with_a_mobile_phone.png/220px-Image_created_with_a_mobile_phone.png',
                                  height: 270,
                                  width: 300,
                                  fit: BoxFit.cover,
                                  alignment: Alignment.center,
                                ),
                              );
                            }
                            return CircularProgressIndicator();
                          }),
                    ),
                  ),
                  const _CircularPercentage(),
                  Positioned(
                    top: 380,
                    child: FutureBuilder(
                        future: userName,
                        builder: (context, data) {
                          if (data.hasData) {
                            return Text(
                              '${data.data}',
                              style: GoogleFonts.aBeeZee(color: DcColors.white, fontSize: 30),
                            );
                          }
                          return CircularProgressIndicator();
                        }),
                  ),
                ],
              ),
              const SizedBox(height: 20),
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 65),
                child: Text(
                  'Do somesthing with passion or not it all...',
                  style: GoogleFonts.textMeOne(color: DcColors.white, fontSize: 20),
                ),
              ),
              const SizedBox(height: 30),
              Padding(
                padding: const EdgeInsets.symmetric(vertical: 30),
                child: SizedBox(
                  width: 237,
                  child: Column(
                    children: [
                      Row(
                        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                        children: [
                          Text(
                            'Save',
                            style: GoogleFonts.aBeeZee(color: DcColors.white, fontSize: 18),
                          ),
                          Text(
                            'Mine',
                            style: GoogleFonts.aBeeZee(color: DcColors.white, fontSize: 18),
                          )
                        ],
                      ),
                      const SizedBox(height: 10),
                      SizedBox(
                        width: 237,
                        child: Stack(
                          alignment: Alignment.center,
                          children: [
                            Align(
                              alignment: Alignment.centerRight,
                              child: Container(
                                width: 237,
                                height: 13,
                                decoration: BoxDecoration(
                                  borderRadius: BorderRadius.circular(7),
                                  color: DcColors.sliderBackground,
                                ),
                              ),
                            ),
                            InkWell(
                              onTap: () {
                                setState(() {
                                  _shouldShowSaved = !_shouldShowSaved;
                                });
                              },
                              child: AnimatedAlign(
                                alignment:
                                    _shouldShowSaved ? Alignment.centerLeft : Alignment.centerRight,
                                duration: const Duration(milliseconds: 300),
                                child: Container(
                                  width: 237 / 2,
                                  height: 13,
                                  decoration: BoxDecoration(
                                    borderRadius: BorderRadius.circular(7),
                                    color: Colors.orange,
                                  ),
                                ),
                              ),
                            ),
                          ],
                        ),
                      ),
                    ],
                  ),
                ),
              ),
            ],
          )),
        ],
      ),
    );
  }
}

class _IconButton extends StatelessWidget {
  final VoidCallback onTap;
  final IconData icon;
  final String text;

  const _IconButton({
    Key? key,
    required this.onTap,
    required this.icon,
    required this.text,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return ListTile(
      onTap: onTap,
      title: Text(
        text,
        style: GoogleFonts.textMeOne(fontSize: 20, color: DcColors.white),
      ),
      leading: Icon(icon),
    );
  }
}

class _CircularPercentage extends StatefulWidget {
  const _CircularPercentage({
    Key? key,
  }) : super(key: key);

  @override
  State<_CircularPercentage> createState() => _CircularPercentageState();
}

class _CircularPercentageState extends State<_CircularPercentage>
    with SingleTickerProviderStateMixin {
  late AnimationController _animationController;

  @override
  void initState() {
    _animationController =
        AnimationController(vsync: this, duration: const Duration(milliseconds: 1500));
    _animationController.forward();
    super.initState();
  }

  @override
  void dispose() {
    _animationController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Stack(
      children: [
        CustomPaint(
          size: const Size(
            420,
            420,
          ),
          painter: ProgressBar(
            progressColor: const Color(0xFFC9D6FF),
            arc: 3.15,
            isBackground: false,
          ),
        ),
        AnimatedBuilder(
          animation: _animationController,
          builder: (context, child) {
            return CustomPaint(
              size: const Size(
                420,
                420,
              ),
              painter: ProgressBar(
                progressColor: Colors.orange,
                arc: 2.15 * _animationController.value,
                isBackground: false,
              ),
            );
          },
        ),
        Positioned(
            top: 280,
            left: 145,
            child: Text(
              'Music Lover',
              style: GoogleFonts.textMeOne(color: DcColors.white, fontSize: 22),
            )),
        Positioned(
            top: 190,
            left: 10,
            child: Text(
              '250',
              style: GoogleFonts.textMeOne(color: DcColors.white, fontSize: 18),
            )),
        Positioned(
            top: 190,
            right: 10,
            child: Text(
              '300',
              style: GoogleFonts.textMeOne(color: DcColors.white, fontSize: 18),
            )),
      ],
    );
  }
}

class ProgressBar extends CustomPainter {
  final bool isBackground;
  final double arc;
  final Color progressColor;

  ProgressBar({
    required this.isBackground,
    required this.arc,
    required this.progressColor,
  });

  @override
  void paint(Canvas canvas, Size size) {
    const rect = Rect.fromLTRB(25, 90, 370, 290);
    final startAngle = -pi;
    final sweepAngle = arc != null ? arc : pi;
    const userCenter = false;
    final paint = Paint()
      ..strokeCap = StrokeCap.round
      ..color = progressColor
      ..style = PaintingStyle.stroke
      ..strokeWidth = 15;

    if (isBackground) {}
    canvas.scale(1, -1);
    canvas.translate(0, -size.height);
    canvas.drawArc(rect, startAngle, sweepAngle, userCenter, paint);
  }

  @override
  bool shouldRepaint(covariant CustomPainter oldDelegate) {
    return true;
  }
}
