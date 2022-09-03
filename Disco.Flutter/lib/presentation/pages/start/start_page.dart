// import 'package:auto_route/src/router/auto_router_x.dart';
// import 'package:disco_app/app/app_router.gr.dart';
// import 'package:disco_app/res/colors.dart';
// import 'package:flutter/material.dart';
//
// class StartPage extends StatefulWidget {
//   const StartPage({Key? key}) : super(key: key);
//
//   static const routeName = '/start';
//
//   @override
//   State<StartPage> createState() => _StartPageState();
// }
//
// class _StartPageState extends State<StartPage> {
//   @override
//   Widget build(BuildContext context) {
//     return Scaffold(
//       backgroundColor: DcColors.white, //Color(0xFF29193E),
//       body: Container(
//         decoration: const BoxDecoration(
//           image: DecorationImage(
//             image: AssetImage("assets/main.png"),
//             fit: BoxFit.fill,
//           ),
//         ),
//         height: double.infinity,
//         width: double.infinity,
//         //color: const Color(0xFF29193E),
//         child: Center(
//           child: IntrinsicWidth(
//             child: Column(
//               crossAxisAlignment: CrossAxisAlignment.stretch,
//               mainAxisAlignment: MainAxisAlignment.center,
//               children: [
//                 Image.asset("assets/logo.png"),
//                 const SizedBox(height: 36),
//                 Padding(
//                   padding: const EdgeInsets.symmetric(horizontal: 15),
//                   child: OutlinedButton(onPressed: _onLogin, child: const Text("Log In")),
//                 ),
//                 const SizedBox(height: 36),
//                 TextButton(onPressed: _onRegistration, child: const Text("Registration")),
//               ],
//             ),
//           ),
//         ),
//       ),
//     );
//   }
//
//   void _onLogin() {
//     context.router.replace(const LoginRoute());
//   }
//
//   void _onRegistration() {
//     context.router.replace(const SearchRegistrationRoute());
//   }
// }
