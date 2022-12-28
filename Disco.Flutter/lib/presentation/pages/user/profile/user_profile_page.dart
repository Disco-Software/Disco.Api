import 'dart:math';

import 'package:auto_route/auto_route.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/data/local/local_storage.dart';
import 'package:disco_app/data/network/network_models/friend_model.dart';
import 'package:disco_app/presentation/common_widgets/post/post.dart';
import 'package:disco_app/presentation/pages/user/profile/bloc/profile_cubit.dart';
import 'package:disco_app/presentation/pages/user/profile/bloc/profile_state.dart';
import 'package:disco_app/presentation/pages/user/profile/bloc/subscribe_cubit.dart';
import 'package:disco_app/presentation/pages/user/profile/bloc/subscribe_state.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../../injection.dart';

class UserProfilePage extends StatefulWidget implements AutoRouteWrapper {
  const UserProfilePage({Key? key, required this.userId}) : super(key: key);

  final int userId;

  @override
  State<UserProfilePage> createState() => _UserProfilePageState();

  @override
  Widget wrappedRoute(context) {
    return MultiBlocProvider(
      providers: [
        BlocProvider<SubscribeCubit>(
          create: (context) => getIt(),
          child: this,
        ),
        BlocProvider<ProfileCubit>(
          create: (context) => getIt()..loadUser(userId),
          child: this,
        ),
      ],
      child: this,
    );
  }
}

class _UserProfilePageState extends State<UserProfilePage> {
  final storedUsername = getIt.get<SecureStorageRepository>().getStoredUserModel();

  String _lastStatus = '';
  String _creed = '';
  int _userTarget = 50;
  int _currentFollowers = 0;
  String _photo = '';
  String _userName = '';
  int _id = 0;
  int _userId = 0;

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
            leading: IconButton(
              icon: Image.asset(
                'assets/back_button.png',
                fit: BoxFit.cover,
              ),
              onPressed: () {
                context.router.pop();
              },
            ),
            //leadingWidth: 0,
            centerTitle: true,
            title: const Text(
              "Account",
              style: TextStyle(
                fontSize: 32,
                fontWeight: FontWeight.bold,
              ),
            ),
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
                      child: Image.network(
                        _photo,
                        height: 270,
                        width: 300,
                        fit: BoxFit.cover,
                        alignment: Alignment.center,
                        errorBuilder: (ctx, onj, trace) => Container(
                          color: Colors.white,
                          child: Image.asset(
                            'assets/ic_photo.png',
                            height: 270,
                            width: 300,
                            fit: BoxFit.fill,
                            alignment: Alignment.center,
                          ),
                        ),
                      ),
                    ),
                  ),
                  BlocListener<ProfileCubit, ProfileState>(
                    listener: (context, state) {
                      state.maybeMap(
                          orElse: () {},
                          loaded: (userState) {
                            setState(() {
                              _id = userState.user.account?.followers
                                      ?.firstWhere(
                                          (element) =>
                                              element.followingAccount?.userId == widget.userId,
                                          orElse: () => FriendModel())
                                      .id ??
                                  0;
                              _userId = userState.user.account?.userId ?? 0;
                              _lastStatus = userState.user.account?.status?.lastStatus ?? '';
                              _photo = userState.user.account?.photo ?? '';
                              _userName = userState.user.userName ?? '';
                              _creed = userState.user.account?.creed ?? '';
                              _userTarget = userState.user.account?.status?.userTarget ?? 0;
                              _currentFollowers =
                                  userState.user.account?.status?.followersCount ?? 0;
                            });
                            context.read<SubscribeCubit>().init(userState.user);
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
                      _userName,
                      style: GoogleFonts.aBeeZee(color: DcColors.white, fontSize: 30),
                    ),
                  ),
                ],
              ),
              const SizedBox(height: 20),
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 65),
                child: Text(
                  _creed,
                  style: GoogleFonts.textMeOne(color: DcColors.white, fontSize: 20),
                  textAlign: TextAlign.center,
                ),
              ),
              const SizedBox(
                height: 10,
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  BlocBuilder<SubscribeCubit, SubscribeState>(
                    builder: (context, state) {
                      if (state is SubscribeStateUnsubscribed) {
                        return ElevatedButton.icon(
                          onPressed: () {
                            context.read<SubscribeCubit>().subscribe(_userId);
                          },
                          style: ButtonStyle(
                              padding: MaterialStateProperty.all(
                                const EdgeInsets.symmetric(horizontal: 8),
                              ),
                              backgroundColor: MaterialStateProperty.all(DcColors.violet)),
                          icon: const Icon(CupertinoIcons.add),
                          label: Text(
                            'Subscribe',
                            style: GoogleFonts.aBeeZee(fontSize: 24, color: DcColors.white),
                          ),
                        );
                      } else if (state is SubscribeStateSubscribed) {
                        return ElevatedButton.icon(
                          onPressed: () => context.read<SubscribeCubit>().unsubscribe(_id),
                          style: ButtonStyle(
                              padding: MaterialStateProperty.all(
                                const EdgeInsets.symmetric(horizontal: 8),
                              ),
                              backgroundColor: MaterialStateProperty.all(DcColors.violet)),
                          icon: const Icon(CupertinoIcons.minus),
                          label: Text(
                            'Unsubscribe',
                            style: GoogleFonts.aBeeZee(fontSize: 24, color: DcColors.white),
                          ),
                        );
                      } else {
                        return const SizedBox();
                      }
                    },
                  ),
                  const SizedBox(
                    width: 10,
                  ),
                  OutlinedButton.icon(
                    onPressed: () => context.read<SubscribeCubit>().unsubscribe(_id),
                    style: ButtonStyle(
                        padding:
                            MaterialStateProperty.all(const EdgeInsets.symmetric(horizontal: 8))),
                    icon: const Icon(CupertinoIcons.chat_bubble_text),
                    label: Text(
                      'Message',
                      style: GoogleFonts.aBeeZee(fontSize: 24, color: DcColors.white),
                    ),
                  ),
                ],
              ),
              const SizedBox(height: 30),
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
                      return UnicornPost(
                          userName: state.user.userName, post: state.user.account!.posts![index]);
                    },
                    childCount: state.user.account!.posts!.length,
                  ),
                );
              }

              if (state is ProfileStateLoading) {
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
                arc: _getCurrentValue(widget.current, widget.target) * _animationController.value,
                isBackground: false,
                screenWidth: width,
              ),
            );
          },
        ),
        Positioned(
            top: 280,
            left: width > 400 ? width - 260 : width - 220,
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

  double _getCurrentValue(int current, int followerTarget) => current / (followerTarget / 3.15);
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
