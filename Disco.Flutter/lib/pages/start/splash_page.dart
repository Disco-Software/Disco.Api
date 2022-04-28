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
  );
  late TextStyle _secondTextStyle;
  late TextStyle _thirdTextStyle;
  bool shoudlChangeBackGround = false;
  bool shoudlChangeCircle = false;

  final BoxDecoration _firstDecoration = const BoxDecoration(
      gradient: RadialGradient(
    center: Alignment.topRight,
    tileMode: TileMode.repeated,
    radius: 8,
    colors: [
      Color(0xFF78737D),
      Color(0xFFA7A7A7),
      Color(0xFF0F0C1B),
    ],
  ));

  final BoxDecoration _secondDecoration = const BoxDecoration(
    gradient: RadialGradient(
      center: Alignment.topRight,
      radius: 8,
      tileMode: TileMode.repeated,
      colors: [
        Color(0xFF402053),
        Color(0xFF0F0C1B),
        Color(0xFF0F0C1B),
      ],
    ),
    boxShadow: [
      BoxShadow(
        color: Colors.black,
        // color: Color(0xFFA044FF),
        offset: Offset(0, 4),
        blurRadius: 7.0,
        spreadRadius: 5.0,
      ),
    ],
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
    );
    _thirdTextStyle = TextStyle(
      foreground: Paint()..shader = linearGradient,
      fontSize: 72,
      fontFamily: 'Colonna',
    );
    _textStyle = _firstTextStyle;
    _decoration = _firstDecoration;
    if (mounted) {
      Future.delayed(const Duration(milliseconds: 500)).then((value) {
        setState(() {
          _decoration = _secondDecoration;
          _textStyle = _secondTextStyle;
        });
      });
      Future.delayed(const Duration(seconds: 2)).then((value) {
        setState(() {
          _textStyle = _thirdTextStyle;
          shoudlChangeBackGround = true;
        });
      });
      Future.delayed(const Duration(milliseconds: 4000)).then((value) {
        controller.reverse();
      });
    }

    // WidgetsBinding.instance!.addPostFrameCallback((_) {
    //   Future.delayed(const Duration(seconds: 10)).then((value) {
    //     context.router.navigate(const StartRoute());
    //   });
    // });
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
              child: !shoudlChangeBackGround
                  ? AnimatedContainer(
                      duration: const Duration(seconds: 1),
                      decoration: _decoration,
                    )
                  : const _BackGroundBody(),
            ),
            AnimatedPositioned(
              bottom: shoudlChangeBackGround ? 500.0 : 400.0,
              duration: const Duration(seconds: 1),
              child: AnimatedDefaultTextStyle(
                child: const Text('DISCO'),
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
            padding: const EdgeInsets.symmetric(horizontal: 100.0),
            child: OutlinedButton(onPressed: () {}, child: const Text("Log In")),
          ),
          const SizedBox(height: 36),
          TextButton(onPressed: () {}, child: const Text("Registration")),
        ],
      ),
    );
  }
}
