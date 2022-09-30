import 'dart:ui';

import 'package:disco_app/data/network/api/auth_api.dart';
import 'package:disco_app/presentation/dialogs/forgot_password/bloc/forgot_password_bloc.dart';
import 'package:disco_app/presentation/dialogs/forgot_password/bloc/forgot_password_event.dart';
import 'package:disco_app/presentation/dialogs/forgot_password/bloc/forgot_password_state.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:get_it/get_it.dart';

class ForgotPassword extends StatefulWidget {
  const ForgotPassword({Key? key}) : super(key: key);

  @override
  _ForgotPasswordState createState() => _ForgotPasswordState();
}

class _ForgotPasswordState extends State<ForgotPassword> {
  final _bloc = ForgotPasswordBloc(InitState(), authApi: GetIt.I.get<AuthApi>());
  final _emailController = TextEditingController();
  final _formKey = GlobalKey<FormState>();

  void _blocLisener(BuildContext context, Object? state) {
    WidgetsBinding.instance?.addPostFrameCallback((timeStamp) {});
  }

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<ForgotPasswordBloc, ForgotPasswordState>(
      listener: _blocLisener,
      bloc: _bloc,
      builder: (context, state) => SizedBox(
        child: Center(
          child: SingleChildScrollView(
            child: Dialog(
              insetPadding: const EdgeInsets.symmetric(horizontal: 30),
              shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(10)),
              backgroundColor: DcColors.darkViolet,
              child: Padding(
                padding: const EdgeInsets.only(top: 37, bottom: 37),
                child: Column(
                  children: [
                    const Text(
                      "Password",
                      style: TextStyle(color: DcColors.darkWhite, fontSize: 28),
                    ),
                    Padding(
                      padding: const EdgeInsets.only(top: 23, bottom: 17),
                      child: Image.asset("assets/ic_lock.png"),
                    ),
                    const Padding(
                      padding: EdgeInsets.only(left: 51, right: 51, bottom: 14),
                      child: Text(
                        "Enter your e-mail and you will receive a link to create a new password",
                        textAlign: TextAlign.center,
                        style: TextStyle(color: DcColors.darkWhite, fontSize: 12),
                      ),
                    ),
                    const Text(
                      "E-mail",
                      style: TextStyle(
                        color: DcColors.darkWhite,
                      ),
                    ),
                    const SizedBox(
                      height: 10,
                    ),
                    Padding(
                      padding: const EdgeInsets.only(left: 30, right: 30, bottom: 24),
                      child: Form(
                        key: _formKey,
                        child: TextFormField(
                            controller: _emailController,
                            style: const TextStyle(color: DcColors.darkWhite)),
                      ),
                    ),
                    SizedBox(
                        width: 144,
                        child: state is ForgotPasswordEmailSendingState
                            ? const Center(child: CircularProgressIndicator.adaptive())
                            : ElevatedButton(
                                onPressed: onSend,
                                child: const Text(
                                  "Send",
                                  style: TextStyle(color: DcColors.darkWhite, fontSize: 18),
                                )))
                  ],
                ),
              ),
            ),
          ),
        ),
      ),
    );
  }

  void onSend() {
    if (_formKey.currentState?.validate() ?? false) {
      final email = _emailController.text;
      _bloc.add(ForgotPasswordOnSendingEvent(email: email));
    }
  }
}
