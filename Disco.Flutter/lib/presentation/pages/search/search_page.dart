import 'dart:async';

import 'package:disco_app/res/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';

class SearchPage extends StatefulWidget {
  const SearchPage({Key? key}) : super(key: key);

  @override
  State<SearchPage> createState() => _SearchPageState();
}

class _SearchPageState extends State<SearchPage> {
  final _searchController = TextEditingController();
  bool shouldShowSearchIcon = true;
  Timer? _debounce;

  @override
  void dispose() {
    _debounce?.cancel();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () {
        FocusScope.of(context).unfocus();
      },
      child: Scaffold(
        backgroundColor: Color(0xFF1C142D),
        body: CustomScrollView(
          slivers: [
            const SliverAppBar(
              backgroundColor: Color(0xFF1C142D),
              expandedHeight: 250,
              title: Text(
                "DISCO",
                style: TextStyle(
                  fontSize: 32,
                  fontFamily: 'Colonna',
                  fontWeight: FontWeight.bold,
                ),
                textAlign: TextAlign.start,
              ),
            ),
            SliverToBoxAdapter(
              child: Padding(
                padding: const EdgeInsets.symmetric(horizontal: 50),
                child: TextFormField(
                  onChanged: (value) {
                    _debounce = Timer(const Duration(milliseconds: 500), () {
                      // setState(() {});
                    });
                  },
                  style: const TextStyle(color: DcColors.darkWhite, fontSize: 30),
                  // autovalidateMode: AutovalidateMode.onUserInteraction,
                  // validator: (value) => _onPasswordValidate(_passwordController.text),
                  controller: _searchController,
                  decoration: InputDecoration(
                    isDense: true,
                    // errorText: state is LogInErrorState ? state.passwordError : null,
                    prefix: shouldShowSearchIcon
                        ? SvgPicture.asset(
                            'assets/ic_search.svg',
                            color: Colors.white,
                          )
                        : const SizedBox(),
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
