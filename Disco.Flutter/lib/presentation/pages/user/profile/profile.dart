import 'dart:math';

import 'package:auto_route/auto_route.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/data/local/local_storage.dart';
import 'package:disco_app/data/network/request_models/google_login_request_model.dart';
import 'package:disco_app/domain/stored_user_model.dart';
import 'package:disco_app/presentation/common_widgets/post/post.dart';
import 'package:disco_app/presentation/pages/user/profile/bloc/profile_cubit.dart';
import 'package:disco_app/presentation/pages/user/profile/bloc/profile_state.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../../injection.dart';

class ProfilePage extends StatefulWidget implements AutoRouteWrapper {
  const ProfilePage({Key? key}) : super(key: key);

  @override
  State<ProfilePage> createState() => _ProfilePageState();

  @override
  Widget wrappedRoute(context) {
    return BlocProvider<ProfileCubit>(
      create: (context) => getIt()..loadMine(),
      child: this,
    );
  }
}

class _ProfilePageState extends State<ProfilePage> {
  bool _shouldShowSaved = false;
  final storedUsername = getIt.get<SecureStorageRepository>().getStoredUserModel();

  String _lastStatus = '';
  int _userTarget = 50;
  int _currentFollowers = 0;

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
      body: FutureBuilder(
          future: storedUsername,
          builder: (context, data) {
            if (data.hasData) {
              return CustomScrollView(
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
                                BoxShadow(
                                    color: Color(0xffb2a044ff),
                                    offset: Offset(0, 5),
                                    blurRadius: 10),
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
                              child: Image.network(
                                '${(data.data as StoredUserModel).userPhoto}',
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
                              ),
                            ),
                          ),
                          BlocListener<ProfileCubit, ProfileState>(
                            listener: (context, state) {
                              state.maybeMap(
                                  orElse: () {},
                                  loaded: (state) {
                                    setState(() {
                                      _lastStatus = state.user.account?.status?.lastStatus ?? '';
                                      _userTarget = state.user.account?.status?.userTarget ?? 0;
                                      _currentFollowers =
                                          state.user.account?.status?.followersCount ?? 0;
                                    });
                                  },
                                  saved: (state) {
                                    setState(() {
                                      _lastStatus = state.user.account?.status?.lastStatus ?? '';
                                      _userTarget = state.user.account?.status?.userTarget ?? 0;
                                      _currentFollowers =
                                          state.user.account?.status?.followersCount ?? 0;
                                    });
                                  });
                            },
                            child: _CircularPercentage(
                              status: _lastStatus,
                              target: _userTarget,
                              current: _currentFollowers,
                            ),
                          ),
                          Positioned(
                            top: 380,
                            child: Text(
                              '${(data.data as StoredUserModel).userName}',
                              style: GoogleFonts.aBeeZee(color: DcColors.white, fontSize: 30),
                            ),
                          ),
                        ],
                      ),
                      const SizedBox(height: 20),
                      Padding(
                        padding: const EdgeInsets.symmetric(horizontal: 65),
                        child: Text(
                          'Do somesthing with passion or not it all...',
                          style: GoogleFonts.textMeOne(color: DcColors.white, fontSize: 20),
                          textAlign: TextAlign.center,
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
                                        if (_shouldShowSaved) {
                                          context.read<ProfileCubit>().loadSaved();
                                        } else {
                                          context.read<ProfileCubit>().loadMine();
                                        }
                                      },
                                      child: AnimatedAlign(
                                        alignment: _shouldShowSaved
                                            ? Alignment.centerLeft
                                            : Alignment.centerRight,
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
                  BlocBuilder<ProfileCubit, ProfileState>(
                    builder: (context, state) {
                      if (state is ProfileStateLoaded &&
                          state.user.account != null &&
                          state.user.account!.posts != null) {
                        return SliverList(
                          delegate: SliverChildBuilderDelegate(
                            (ctx, index) {
                              return UnicornPost(post: state.user.account!.posts![index]);
                            },
                            childCount: state.user.account!.posts!.length,
                          ),
                        );
                      }

                      if (state is ProfileStateSaved &&
                          state.user.account != null &&
                          state.user.account!.posts != null) {
                        return state.savedPosts.isNotEmpty
                            ? SliverList(
                                delegate: SliverChildBuilderDelegate(
                                  (ctx, index) {
                                    return UnicornPost(post: state.savedPosts[index]);
                                  },
                                  childCount: state.user.account!.posts!.length,
                                ),
                              )
                            : SliverToBoxAdapter(
                                child: Center(
                                child: Text(
                                  'No Saved posts',
                                  style: GoogleFonts.aBeeZee(color: Colors.white, fontSize: 25),
                                ),
                              ));
                      }

                      if (state is ProfileStateLoaded) {
                        return SliverToBoxAdapter(
                          child: Center(
                            child: Image.asset('assets/music.gif'),
                          ),
                        );
                      }

                      return const SliverPadding(padding: EdgeInsets.all(1));
                    },
                  ),
                  const SliverPadding(padding: EdgeInsets.only(bottom: 200)),
                ],
              );
            }
            return const SizedBox();
          }),
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
  final int target;
  final int current;
  final String status;

  const _CircularPercentage({
    Key? key,
    required this.target,
    required this.current,
    required this.status,
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
    final width = MediaQuery.of(context).size.width;
    return Stack(
      children: [
        CustomPaint(
          size: const Size(
            420,
            420,
          ),
          painter: ProgressBar(
            screenWidth: width,
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
                arc: _getCurrentValue(widget.current) * _animationController.value,
                isBackground: false,
                screenWidth: width,
              ),
            );
          },
        ),
        Positioned(
            top: 280,
            left: width - 250,
            child: Text(
              widget.status,
              style: GoogleFonts.textMeOne(color: DcColors.white, fontSize: 22),
            )),
        Positioned(
            top: 190,
            left: 10,
            child: Text(
              '${widget.current}',
              style: GoogleFonts.textMeOne(color: DcColors.white, fontSize: 18),
            )),
        Positioned(
            top: 190,
            right: 10,
            child: Text(
              '${widget.target}',
              style: GoogleFonts.textMeOne(color: DcColors.white, fontSize: 18),
            )),
      ],
    );
  }

  double _getCurrentValue(int current) {
    return 2.15;
    //2.15
  }
}

class ProgressBar extends CustomPainter {
  final bool isBackground;
  final double arc;
  final Color progressColor;
  final double screenWidth;

  ProgressBar({
    required this.isBackground,
    required this.arc,
    required this.progressColor,
    required this.screenWidth,
  });

  @override
  void paint(Canvas canvas, Size size) {
    final rect = Rect.fromLTRB(20, 90, screenWidth - 25, 290);
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
