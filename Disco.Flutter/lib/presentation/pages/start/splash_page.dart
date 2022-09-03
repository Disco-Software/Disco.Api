import 'package:auto_route/auto_route.dart';
import 'package:disco_app/app/app_router.gr.dart';
import 'package:disco_app/data/local/local_storage.dart';
import 'package:disco_app/injection.dart';
import 'package:disco_app/res/strings.dart';
import 'package:flutter/material.dart';

class SplashPage extends StatefulWidget {
  const SplashPage({Key? key}) : super(key: key);

  static const routeName = '/splash';

  @override
  _SplashPageState createState() => _SplashPageState();
}

class _SplashPageState extends State<SplashPage> with SingleTickerProviderStateMixin {
  late AnimationController controller;
  late Animation heightAnimation;
  late Animation widthAnimation;
  final Shader linearGradient = const LinearGradient(
    colors: <Color>[Color(0xffFFF170), Color(0xffDE871F)],
  ).createShader(const Rect.fromLTWH(0.0, 0.0, 200.0, 70.0));

  late BoxDecoration _decoration;
  late TextStyle _textStyle;
  final TextStyle _firstTextStyle = const TextStyle(
    color: Color(0xFFE7E5DF),
    fontFamily: 'Colonna',
    fontSize: 65,
    letterSpacing: 0.1,
  );
  late TextStyle _secondTextStyle;
  late TextStyle _thirdTextStyle;
  bool shouldChangeBackGround = false;
  bool shouldChangeCircle = false;

  final BoxDecoration _firstDecoration = const BoxDecoration(
      gradient: RadialGradient(
    tileMode: TileMode.repeated,
    focal: Alignment(1.0, -1.0),
    radius: 2.4,
    center: Alignment(1.2, 0.0),
    colors: [
      Color(0xFFA0A0A1),
      Color(0xFF242333),
      Color(0xFF100C1C),
    ],
  ));

  final BoxDecoration _secondDecoration = const BoxDecoration(
    gradient: RadialGradient(
      radius: 2.4,
      tileMode: TileMode.repeated,
      center: Alignment(1.2, -1.0),
      colors: [
        Color(0xFF432461),
        Color(0xFF402053),
        Color(0xFF0F0C1B),
      ],
    ),
  );

  @override
  void initState() {
    super.initState();
    controller = AnimationController(
      vsync: this,
      duration: const Duration(seconds: 1),
      value: 1.0,
    );
    heightAnimation = Tween<double>(begin: 1000.0, end: 20.0).animate(controller);
    widthAnimation = Tween<double>(begin: 1000.0, end: 20.0).animate(controller);
    _secondTextStyle = TextStyle(
      foreground: Paint()..shader = linearGradient,
      fontSize: 96,
      fontFamily: 'Colonna',
      shadows: const [
        BoxShadow(
          color: Color(0xFFa044ff),
          offset: Offset(0, 4),
          blurRadius: 7.0,
          spreadRadius: 2.0,
        ),
      ],
    );
    _thirdTextStyle = TextStyle(
      foreground: Paint()..shader = linearGradient,
      fontSize: 67,
      fontFamily: 'Colonna',
      shadows: const [
        BoxShadow(
          color: Color(0xFFa044ff),
          // color: Color(0xFFA044FF),
          offset: Offset(0, 4),
          blurRadius: 7.0,
          spreadRadius: 2.0,
        ),
      ],
    );
    _textStyle = _firstTextStyle;
    _decoration = _firstDecoration;
    if (mounted) {
      Future.delayed(Duration.zero, () async {
        final token = await _getToken();
        setState(() {
          _decoration = _secondDecoration;
          _textStyle = _secondTextStyle;
        });
        if (token.isEmpty) {
          await Future.delayed(const Duration(milliseconds: 550));
        } else {
          await Future.delayed(const Duration(seconds: 1));
        }

        if (token.isEmpty) {
          await Future.delayed(const Duration(seconds: 2));
          setState(() {
            _textStyle = _thirdTextStyle;
            shouldChangeBackGround = true;
          });
        }
        if (token.isEmpty) {
          await Future.delayed(const Duration(seconds: 4));
          controller.reverse();
        }
        if (token.isNotEmpty) {
          context.router.pushAndPopUntil(HomeRoute(), predicate: (route) => false);
        }
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Material(
      child: Scaffold(
        body: Stack(
          alignment: Alignment.center,
          children: [
            Container(
              color: Colors.white,
            ),
            AnimatedBuilder(
              builder: (context, _) {
                return Container(
                  decoration: BoxDecoration(
                    borderRadius: BorderRadius.circular(controller.value * 300),
                    color: const Color(0xFF0F0C1B),
                  ),
                  // height: MediaQuery.of(context).size.height * controller.value,
                  height: heightAnimation.value,
                  width: widthAnimation.value,
                );
              },
              animation: controller,
            ),
            AnimatedSwitcher(
              duration: const Duration(seconds: 1),
              transitionBuilder: (child, animation) => FadeTransition(
                opacity: animation,
                child: child,
              ),
              child: !shouldChangeBackGround
                  ? AnimatedContainer(
                      duration: const Duration(seconds: 1),
                      decoration: _decoration,
                    )
                  : const _BackGroundBody(),
            ),
            AnimatedPositioned(
              bottom: shouldChangeBackGround
                  ? MediaQuery.of(context).size.height * 0.6
                  : MediaQuery.of(context).size.height * 0.5,
              duration: const Duration(seconds: 1),
              child: AnimatedDefaultTextStyle(
                child: const Text(
                  'DISCO',
                ),
                maxLines: 1,
                style: _textStyle,
                duration: const Duration(seconds: 1),
              ),
            ),
            // CustomPaint(
            //   painter: MakeCircle(strokeWidth: 100.0),
            // ),
          ],
        ),
      ),
    );
  }

  Future<String> _getToken() async {
    return await getIt.get<SecureStorageRepository>().read(key: Strings.token);
  }
}

class _BackGroundBody extends StatelessWidget {
  const _BackGroundBody({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: const BoxDecoration(
        image: DecorationImage(
          image: AssetImage("assets/main.png"),
          fit: BoxFit.fill,
        ),
      ),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.stretch,
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          const SizedBox(height: 36),
          const SizedBox(height: 36),
          Padding(
            padding: EdgeInsets.symmetric(horizontal: MediaQuery.of(context).size.width * 0.27),
            child: OutlinedButton(onPressed: () => _onLogin(context), child: const Text("Log In")),
          ),
          const SizedBox(height: 36),
          TextButton(onPressed: () => _onRegistration(context), child: const Text("Registration")),
        ],
      ),
    );
  }

  void _onRegistration(BuildContext context) {
    context.router.navigate(const SearchRegistrationRoute());
  }

  void _onLogin(BuildContext context) {
    context.router.navigate(const LoginRoute());
  }
}
