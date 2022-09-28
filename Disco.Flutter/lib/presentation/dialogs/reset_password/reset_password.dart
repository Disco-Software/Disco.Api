import 'package:disco_app/data/network/api/auth_api.dart';
import 'package:disco_app/presentation/dialogs/reset_password/bloc/reset_password_bloc.dart';
import 'package:disco_app/presentation/dialogs/reset_password/bloc/reset_password_state.dart';
import 'package:disco_app/presentation/pages/authentication/search_registration/bloc/search_state.dart';
import 'package:disco_app/res/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:get_it/get_it.dart';

class ResetPassword extends StatefulWidget {
  const ResetPassword({Key? key}) : super(key: key);

  @override
  _ResetPasswordState createState() => _ResetPasswordState();
}

class _ResetPasswordState extends State<ResetPassword> {
  final _emailController = TextEditingController();
  final _passwordController = TextEditingController();
  final _bloc = ResetPasswordBloc(InitialState(), authApi: GetIt.I.get<AuthApi>());
  final _formKey = GlobalKey<FormState>();

  void _blocLisener(BuildContext context, Object? state) {
    WidgetsBinding.instance?.addPostFrameCallback((timeStamp) {});
  }

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<ResetPasswordBloc, ResetPasswordPageState>(
      key: _formKey,
      listener: _blocLisener,
      bloc: _bloc,
      builder: (context, state) => SizedBox(
        child: Center(
          child: SingleChildScrollView(
            child: Dialog(
              child: Column(
                children: [
                  Form(
                      key: _formKey,
                      child: Column(
                        children: [
                          const Padding(
                            padding: EdgeInsets.only(top: 31, bottom: 18),
                            child: Text(
                              "Restore password",
                              style: TextStyle(
                                color: DcColors.darkWhite,
                                fontSize: 28,
                              ),
                            ),
                          ),
                          const Padding(
                            padding: EdgeInsets.only(
                              top: 18,
                              bottom: 11,
                            ),
                            child: Text(
                              "New Password",
                              style: TextStyle(color: DcColors.darkWhite),
                            ),
                          ),
                          TextFormField(
                            controller: _emailController,
                            style: const TextStyle(
                              color: DcColors.darkWhite,
                            ),
                          ),
                          const Padding(
                            padding: EdgeInsets.only(
                              top: 18,
                              bottom: 11,
                            ),
                            child: Text(
                              "New Password",
                              style: TextStyle(color: DcColors.darkWhite),
                            ),
                          ),
                          TextFormField(
                            controller: _emailController,
                            obscureText: true,
                            style: const TextStyle(
                              color: DcColors.darkWhite,
                            ),
                          ),
                          SizedBox(
                              width: 144,
                              child: state is SuccessPageState
                                  ? const Center(child: CircularProgressIndicator.adaptive())
                                  : ElevatedButton(
                                      onPressed: onSend,
                                      child: const Text(
                                        "Send",
                                        style: TextStyle(color: DcColors.darkWhite, fontSize: 18),
                                      )))
                        ],
                      )),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }

  void onSend() {}
}
