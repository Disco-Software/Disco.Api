// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target

part of 'subscribe_state.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more informations: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

/// @nodoc
class _$SubscribeStateTearOff {
  const _$SubscribeStateTearOff();

  SubscribeStateLoading loading() {
    return const SubscribeStateLoading();
  }

  SubscribeStateSubscribed subscribed() {
    return const SubscribeStateSubscribed();
  }

  SubscribeStateUnsubscribed unsubscribed() {
    return const SubscribeStateUnsubscribed();
  }
}

/// @nodoc
const $SubscribeState = _$SubscribeStateTearOff();

/// @nodoc
mixin _$SubscribeState {
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() loading,
    required TResult Function() subscribed,
    required TResult Function() unsubscribed,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? loading,
    TResult Function()? subscribed,
    TResult Function()? unsubscribed,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? loading,
    TResult Function()? subscribed,
    TResult Function()? unsubscribed,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(SubscribeStateLoading value) loading,
    required TResult Function(SubscribeStateSubscribed value) subscribed,
    required TResult Function(SubscribeStateUnsubscribed value) unsubscribed,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(SubscribeStateLoading value)? loading,
    TResult Function(SubscribeStateSubscribed value)? subscribed,
    TResult Function(SubscribeStateUnsubscribed value)? unsubscribed,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(SubscribeStateLoading value)? loading,
    TResult Function(SubscribeStateSubscribed value)? subscribed,
    TResult Function(SubscribeStateUnsubscribed value)? unsubscribed,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $SubscribeStateCopyWith<$Res> {
  factory $SubscribeStateCopyWith(
          SubscribeState value, $Res Function(SubscribeState) then) =
      _$SubscribeStateCopyWithImpl<$Res>;
}

/// @nodoc
class _$SubscribeStateCopyWithImpl<$Res>
    implements $SubscribeStateCopyWith<$Res> {
  _$SubscribeStateCopyWithImpl(this._value, this._then);

  final SubscribeState _value;
  // ignore: unused_field
  final $Res Function(SubscribeState) _then;
}

/// @nodoc
abstract class $SubscribeStateLoadingCopyWith<$Res> {
  factory $SubscribeStateLoadingCopyWith(SubscribeStateLoading value,
          $Res Function(SubscribeStateLoading) then) =
      _$SubscribeStateLoadingCopyWithImpl<$Res>;
}

/// @nodoc
class _$SubscribeStateLoadingCopyWithImpl<$Res>
    extends _$SubscribeStateCopyWithImpl<$Res>
    implements $SubscribeStateLoadingCopyWith<$Res> {
  _$SubscribeStateLoadingCopyWithImpl(
      SubscribeStateLoading _value, $Res Function(SubscribeStateLoading) _then)
      : super(_value, (v) => _then(v as SubscribeStateLoading));

  @override
  SubscribeStateLoading get _value => super._value as SubscribeStateLoading;
}

/// @nodoc

class _$SubscribeStateLoading implements SubscribeStateLoading {
  const _$SubscribeStateLoading();

  @override
  String toString() {
    return 'SubscribeState.loading()';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType && other is SubscribeStateLoading);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() loading,
    required TResult Function() subscribed,
    required TResult Function() unsubscribed,
  }) {
    return loading();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? loading,
    TResult Function()? subscribed,
    TResult Function()? unsubscribed,
  }) {
    return loading?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? loading,
    TResult Function()? subscribed,
    TResult Function()? unsubscribed,
    required TResult orElse(),
  }) {
    if (loading != null) {
      return loading();
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(SubscribeStateLoading value) loading,
    required TResult Function(SubscribeStateSubscribed value) subscribed,
    required TResult Function(SubscribeStateUnsubscribed value) unsubscribed,
  }) {
    return loading(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(SubscribeStateLoading value)? loading,
    TResult Function(SubscribeStateSubscribed value)? subscribed,
    TResult Function(SubscribeStateUnsubscribed value)? unsubscribed,
  }) {
    return loading?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(SubscribeStateLoading value)? loading,
    TResult Function(SubscribeStateSubscribed value)? subscribed,
    TResult Function(SubscribeStateUnsubscribed value)? unsubscribed,
    required TResult orElse(),
  }) {
    if (loading != null) {
      return loading(this);
    }
    return orElse();
  }
}

abstract class SubscribeStateLoading implements SubscribeState {
  const factory SubscribeStateLoading() = _$SubscribeStateLoading;
}

/// @nodoc
abstract class $SubscribeStateSubscribedCopyWith<$Res> {
  factory $SubscribeStateSubscribedCopyWith(SubscribeStateSubscribed value,
          $Res Function(SubscribeStateSubscribed) then) =
      _$SubscribeStateSubscribedCopyWithImpl<$Res>;
}

/// @nodoc
class _$SubscribeStateSubscribedCopyWithImpl<$Res>
    extends _$SubscribeStateCopyWithImpl<$Res>
    implements $SubscribeStateSubscribedCopyWith<$Res> {
  _$SubscribeStateSubscribedCopyWithImpl(SubscribeStateSubscribed _value,
      $Res Function(SubscribeStateSubscribed) _then)
      : super(_value, (v) => _then(v as SubscribeStateSubscribed));

  @override
  SubscribeStateSubscribed get _value =>
      super._value as SubscribeStateSubscribed;
}

/// @nodoc

class _$SubscribeStateSubscribed implements SubscribeStateSubscribed {
  const _$SubscribeStateSubscribed();

  @override
  String toString() {
    return 'SubscribeState.subscribed()';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType && other is SubscribeStateSubscribed);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() loading,
    required TResult Function() subscribed,
    required TResult Function() unsubscribed,
  }) {
    return subscribed();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? loading,
    TResult Function()? subscribed,
    TResult Function()? unsubscribed,
  }) {
    return subscribed?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? loading,
    TResult Function()? subscribed,
    TResult Function()? unsubscribed,
    required TResult orElse(),
  }) {
    if (subscribed != null) {
      return subscribed();
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(SubscribeStateLoading value) loading,
    required TResult Function(SubscribeStateSubscribed value) subscribed,
    required TResult Function(SubscribeStateUnsubscribed value) unsubscribed,
  }) {
    return subscribed(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(SubscribeStateLoading value)? loading,
    TResult Function(SubscribeStateSubscribed value)? subscribed,
    TResult Function(SubscribeStateUnsubscribed value)? unsubscribed,
  }) {
    return subscribed?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(SubscribeStateLoading value)? loading,
    TResult Function(SubscribeStateSubscribed value)? subscribed,
    TResult Function(SubscribeStateUnsubscribed value)? unsubscribed,
    required TResult orElse(),
  }) {
    if (subscribed != null) {
      return subscribed(this);
    }
    return orElse();
  }
}

abstract class SubscribeStateSubscribed implements SubscribeState {
  const factory SubscribeStateSubscribed() = _$SubscribeStateSubscribed;
}

/// @nodoc
abstract class $SubscribeStateUnsubscribedCopyWith<$Res> {
  factory $SubscribeStateUnsubscribedCopyWith(SubscribeStateUnsubscribed value,
          $Res Function(SubscribeStateUnsubscribed) then) =
      _$SubscribeStateUnsubscribedCopyWithImpl<$Res>;
}

/// @nodoc
class _$SubscribeStateUnsubscribedCopyWithImpl<$Res>
    extends _$SubscribeStateCopyWithImpl<$Res>
    implements $SubscribeStateUnsubscribedCopyWith<$Res> {
  _$SubscribeStateUnsubscribedCopyWithImpl(SubscribeStateUnsubscribed _value,
      $Res Function(SubscribeStateUnsubscribed) _then)
      : super(_value, (v) => _then(v as SubscribeStateUnsubscribed));

  @override
  SubscribeStateUnsubscribed get _value =>
      super._value as SubscribeStateUnsubscribed;
}

/// @nodoc

class _$SubscribeStateUnsubscribed implements SubscribeStateUnsubscribed {
  const _$SubscribeStateUnsubscribed();

  @override
  String toString() {
    return 'SubscribeState.unsubscribed()';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is SubscribeStateUnsubscribed);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() loading,
    required TResult Function() subscribed,
    required TResult Function() unsubscribed,
  }) {
    return unsubscribed();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? loading,
    TResult Function()? subscribed,
    TResult Function()? unsubscribed,
  }) {
    return unsubscribed?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? loading,
    TResult Function()? subscribed,
    TResult Function()? unsubscribed,
    required TResult orElse(),
  }) {
    if (unsubscribed != null) {
      return unsubscribed();
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(SubscribeStateLoading value) loading,
    required TResult Function(SubscribeStateSubscribed value) subscribed,
    required TResult Function(SubscribeStateUnsubscribed value) unsubscribed,
  }) {
    return unsubscribed(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(SubscribeStateLoading value)? loading,
    TResult Function(SubscribeStateSubscribed value)? subscribed,
    TResult Function(SubscribeStateUnsubscribed value)? unsubscribed,
  }) {
    return unsubscribed?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(SubscribeStateLoading value)? loading,
    TResult Function(SubscribeStateSubscribed value)? subscribed,
    TResult Function(SubscribeStateUnsubscribed value)? unsubscribed,
    required TResult orElse(),
  }) {
    if (unsubscribed != null) {
      return unsubscribed(this);
    }
    return orElse();
  }
}

abstract class SubscribeStateUnsubscribed implements SubscribeState {
  const factory SubscribeStateUnsubscribed() = _$SubscribeStateUnsubscribed;
}
