import 'package:disco_app/data/network/network_models/post_network.dart';
import 'package:disco_app/data/network/network_models/user_network.dart';
import 'package:freezed_annotation/freezed_annotation.dart';

part 'subscribe_state.freezed.dart';

@freezed
class SubscribeState with _$SubscribeState {
  const factory SubscribeState.loading() = SubscribeStateLoading;

  const factory SubscribeState.subscribed() = SubscribeStateSubscribed;
  const factory SubscribeState.unsubscribed() = SubscribeStateUnsubscribed;
}
