// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target

part of 'like_state.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more informations: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

/// @nodoc
class _$LikeStateTearOff {
  const _$LikeStateTearOff();

  LikeStateInitialSelected initialSelected() {
    return const LikeStateInitialSelected();
  }

  LikeStateInitialNotSelected initialNotSelected() {
    return const LikeStateInitialNotSelected();
  }

  LikeNotSelectedState notSelected({required int likes}) {
    return LikeNotSelectedState(
      likes: likes,
    );
  }

  LikeSelectedState selected({required int likes}) {
    return LikeSelectedState(
      likes: likes,
    );
  }

  LikeStateLoading loading() {
    return const LikeStateLoading();
  }

  LikeStateError error() {
    return const LikeStateError();
  }
}

/// @nodoc
const $LikeState = _$LikeStateTearOff();

/// @nodoc
mixin _$LikeState {
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initialSelected,
    required TResult Function() initialNotSelected,
    required TResult Function(int likes) notSelected,
    required TResult Function(int likes) selected,
    required TResult Function() loading,
    required TResult Function() error,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initialSelected,
    TResult Function()? initialNotSelected,
    TResult Function(int likes)? notSelected,
    TResult Function(int likes)? selected,
    TResult Function()? loading,
    TResult Function()? error,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initialSelected,
    TResult Function()? initialNotSelected,
    TResult Function(int likes)? notSelected,
    TResult Function(int likes)? selected,
    TResult Function()? loading,
    TResult Function()? error,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(LikeStateInitialSelected value) initialSelected,
    required TResult Function(LikeStateInitialNotSelected value)
        initialNotSelected,
    required TResult Function(LikeNotSelectedState value) notSelected,
    required TResult Function(LikeSelectedState value) selected,
    required TResult Function(LikeStateLoading value) loading,
    required TResult Function(LikeStateError value) error,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(LikeStateInitialSelected value)? initialSelected,
    TResult Function(LikeStateInitialNotSelected value)? initialNotSelected,
    TResult Function(LikeNotSelectedState value)? notSelected,
    TResult Function(LikeSelectedState value)? selected,
    TResult Function(LikeStateLoading value)? loading,
    TResult Function(LikeStateError value)? error,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(LikeStateInitialSelected value)? initialSelected,
    TResult Function(LikeStateInitialNotSelected value)? initialNotSelected,
    TResult Function(LikeNotSelectedState value)? notSelected,
    TResult Function(LikeSelectedState value)? selected,
    TResult Function(LikeStateLoading value)? loading,
    TResult Function(LikeStateError value)? error,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $LikeStateCopyWith<$Res> {
  factory $LikeStateCopyWith(LikeState value, $Res Function(LikeState) then) =
      _$LikeStateCopyWithImpl<$Res>;
}

/// @nodoc
class _$LikeStateCopyWithImpl<$Res> implements $LikeStateCopyWith<$Res> {
  _$LikeStateCopyWithImpl(this._value, this._then);

  final LikeState _value;
  // ignore: unused_field
  final $Res Function(LikeState) _then;
}

/// @nodoc
abstract class $LikeStateInitialSelectedCopyWith<$Res> {
  factory $LikeStateInitialSelectedCopyWith(LikeStateInitialSelected value,
          $Res Function(LikeStateInitialSelected) then) =
      _$LikeStateInitialSelectedCopyWithImpl<$Res>;
}

/// @nodoc
class _$LikeStateInitialSelectedCopyWithImpl<$Res>
    extends _$LikeStateCopyWithImpl<$Res>
    implements $LikeStateInitialSelectedCopyWith<$Res> {
  _$LikeStateInitialSelectedCopyWithImpl(LikeStateInitialSelected _value,
      $Res Function(LikeStateInitialSelected) _then)
      : super(_value, (v) => _then(v as LikeStateInitialSelected));

  @override
  LikeStateInitialSelected get _value =>
      super._value as LikeStateInitialSelected;
}

/// @nodoc

class _$LikeStateInitialSelected implements LikeStateInitialSelected {
  const _$LikeStateInitialSelected();

  @override
  String toString() {
    return 'LikeState.initialSelected()';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType && other is LikeStateInitialSelected);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initialSelected,
    required TResult Function() initialNotSelected,
    required TResult Function(int likes) notSelected,
    required TResult Function(int likes) selected,
    required TResult Function() loading,
    required TResult Function() error,
  }) {
    return initialSelected();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initialSelected,
    TResult Function()? initialNotSelected,
    TResult Function(int likes)? notSelected,
    TResult Function(int likes)? selected,
    TResult Function()? loading,
    TResult Function()? error,
  }) {
    return initialSelected?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initialSelected,
    TResult Function()? initialNotSelected,
    TResult Function(int likes)? notSelected,
    TResult Function(int likes)? selected,
    TResult Function()? loading,
    TResult Function()? error,
    required TResult orElse(),
  }) {
    if (initialSelected != null) {
      return initialSelected();
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(LikeStateInitialSelected value) initialSelected,
    required TResult Function(LikeStateInitialNotSelected value)
        initialNotSelected,
    required TResult Function(LikeNotSelectedState value) notSelected,
    required TResult Function(LikeSelectedState value) selected,
    required TResult Function(LikeStateLoading value) loading,
    required TResult Function(LikeStateError value) error,
  }) {
    return initialSelected(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(LikeStateInitialSelected value)? initialSelected,
    TResult Function(LikeStateInitialNotSelected value)? initialNotSelected,
    TResult Function(LikeNotSelectedState value)? notSelected,
    TResult Function(LikeSelectedState value)? selected,
    TResult Function(LikeStateLoading value)? loading,
    TResult Function(LikeStateError value)? error,
  }) {
    return initialSelected?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(LikeStateInitialSelected value)? initialSelected,
    TResult Function(LikeStateInitialNotSelected value)? initialNotSelected,
    TResult Function(LikeNotSelectedState value)? notSelected,
    TResult Function(LikeSelectedState value)? selected,
    TResult Function(LikeStateLoading value)? loading,
    TResult Function(LikeStateError value)? error,
    required TResult orElse(),
  }) {
    if (initialSelected != null) {
      return initialSelected(this);
    }
    return orElse();
  }
}

abstract class LikeStateInitialSelected implements LikeState {
  const factory LikeStateInitialSelected() = _$LikeStateInitialSelected;
}

/// @nodoc
abstract class $LikeStateInitialNotSelectedCopyWith<$Res> {
  factory $LikeStateInitialNotSelectedCopyWith(
          LikeStateInitialNotSelected value,
          $Res Function(LikeStateInitialNotSelected) then) =
      _$LikeStateInitialNotSelectedCopyWithImpl<$Res>;
}

/// @nodoc
class _$LikeStateInitialNotSelectedCopyWithImpl<$Res>
    extends _$LikeStateCopyWithImpl<$Res>
    implements $LikeStateInitialNotSelectedCopyWith<$Res> {
  _$LikeStateInitialNotSelectedCopyWithImpl(LikeStateInitialNotSelected _value,
      $Res Function(LikeStateInitialNotSelected) _then)
      : super(_value, (v) => _then(v as LikeStateInitialNotSelected));

  @override
  LikeStateInitialNotSelected get _value =>
      super._value as LikeStateInitialNotSelected;
}

/// @nodoc

class _$LikeStateInitialNotSelected implements LikeStateInitialNotSelected {
  const _$LikeStateInitialNotSelected();

  @override
  String toString() {
    return 'LikeState.initialNotSelected()';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is LikeStateInitialNotSelected);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initialSelected,
    required TResult Function() initialNotSelected,
    required TResult Function(int likes) notSelected,
    required TResult Function(int likes) selected,
    required TResult Function() loading,
    required TResult Function() error,
  }) {
    return initialNotSelected();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initialSelected,
    TResult Function()? initialNotSelected,
    TResult Function(int likes)? notSelected,
    TResult Function(int likes)? selected,
    TResult Function()? loading,
    TResult Function()? error,
  }) {
    return initialNotSelected?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initialSelected,
    TResult Function()? initialNotSelected,
    TResult Function(int likes)? notSelected,
    TResult Function(int likes)? selected,
    TResult Function()? loading,
    TResult Function()? error,
    required TResult orElse(),
  }) {
    if (initialNotSelected != null) {
      return initialNotSelected();
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(LikeStateInitialSelected value) initialSelected,
    required TResult Function(LikeStateInitialNotSelected value)
        initialNotSelected,
    required TResult Function(LikeNotSelectedState value) notSelected,
    required TResult Function(LikeSelectedState value) selected,
    required TResult Function(LikeStateLoading value) loading,
    required TResult Function(LikeStateError value) error,
  }) {
    return initialNotSelected(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(LikeStateInitialSelected value)? initialSelected,
    TResult Function(LikeStateInitialNotSelected value)? initialNotSelected,
    TResult Function(LikeNotSelectedState value)? notSelected,
    TResult Function(LikeSelectedState value)? selected,
    TResult Function(LikeStateLoading value)? loading,
    TResult Function(LikeStateError value)? error,
  }) {
    return initialNotSelected?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(LikeStateInitialSelected value)? initialSelected,
    TResult Function(LikeStateInitialNotSelected value)? initialNotSelected,
    TResult Function(LikeNotSelectedState value)? notSelected,
    TResult Function(LikeSelectedState value)? selected,
    TResult Function(LikeStateLoading value)? loading,
    TResult Function(LikeStateError value)? error,
    required TResult orElse(),
  }) {
    if (initialNotSelected != null) {
      return initialNotSelected(this);
    }
    return orElse();
  }
}

abstract class LikeStateInitialNotSelected implements LikeState {
  const factory LikeStateInitialNotSelected() = _$LikeStateInitialNotSelected;
}

/// @nodoc
abstract class $LikeNotSelectedStateCopyWith<$Res> {
  factory $LikeNotSelectedStateCopyWith(LikeNotSelectedState value,
          $Res Function(LikeNotSelectedState) then) =
      _$LikeNotSelectedStateCopyWithImpl<$Res>;
  $Res call({int likes});
}

/// @nodoc
class _$LikeNotSelectedStateCopyWithImpl<$Res>
    extends _$LikeStateCopyWithImpl<$Res>
    implements $LikeNotSelectedStateCopyWith<$Res> {
  _$LikeNotSelectedStateCopyWithImpl(
      LikeNotSelectedState _value, $Res Function(LikeNotSelectedState) _then)
      : super(_value, (v) => _then(v as LikeNotSelectedState));

  @override
  LikeNotSelectedState get _value => super._value as LikeNotSelectedState;

  @override
  $Res call({
    Object? likes = freezed,
  }) {
    return _then(LikeNotSelectedState(
      likes: likes == freezed
          ? _value.likes
          : likes // ignore: cast_nullable_to_non_nullable
              as int,
    ));
  }
}

/// @nodoc

class _$LikeNotSelectedState implements LikeNotSelectedState {
  const _$LikeNotSelectedState({required this.likes});

  @override
  final int likes;

  @override
  String toString() {
    return 'LikeState.notSelected(likes: $likes)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is LikeNotSelectedState &&
            const DeepCollectionEquality().equals(other.likes, likes));
  }

  @override
  int get hashCode =>
      Object.hash(runtimeType, const DeepCollectionEquality().hash(likes));

  @JsonKey(ignore: true)
  @override
  $LikeNotSelectedStateCopyWith<LikeNotSelectedState> get copyWith =>
      _$LikeNotSelectedStateCopyWithImpl<LikeNotSelectedState>(
          this, _$identity);

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initialSelected,
    required TResult Function() initialNotSelected,
    required TResult Function(int likes) notSelected,
    required TResult Function(int likes) selected,
    required TResult Function() loading,
    required TResult Function() error,
  }) {
    return notSelected(likes);
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initialSelected,
    TResult Function()? initialNotSelected,
    TResult Function(int likes)? notSelected,
    TResult Function(int likes)? selected,
    TResult Function()? loading,
    TResult Function()? error,
  }) {
    return notSelected?.call(likes);
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initialSelected,
    TResult Function()? initialNotSelected,
    TResult Function(int likes)? notSelected,
    TResult Function(int likes)? selected,
    TResult Function()? loading,
    TResult Function()? error,
    required TResult orElse(),
  }) {
    if (notSelected != null) {
      return notSelected(likes);
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(LikeStateInitialSelected value) initialSelected,
    required TResult Function(LikeStateInitialNotSelected value)
        initialNotSelected,
    required TResult Function(LikeNotSelectedState value) notSelected,
    required TResult Function(LikeSelectedState value) selected,
    required TResult Function(LikeStateLoading value) loading,
    required TResult Function(LikeStateError value) error,
  }) {
    return notSelected(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(LikeStateInitialSelected value)? initialSelected,
    TResult Function(LikeStateInitialNotSelected value)? initialNotSelected,
    TResult Function(LikeNotSelectedState value)? notSelected,
    TResult Function(LikeSelectedState value)? selected,
    TResult Function(LikeStateLoading value)? loading,
    TResult Function(LikeStateError value)? error,
  }) {
    return notSelected?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(LikeStateInitialSelected value)? initialSelected,
    TResult Function(LikeStateInitialNotSelected value)? initialNotSelected,
    TResult Function(LikeNotSelectedState value)? notSelected,
    TResult Function(LikeSelectedState value)? selected,
    TResult Function(LikeStateLoading value)? loading,
    TResult Function(LikeStateError value)? error,
    required TResult orElse(),
  }) {
    if (notSelected != null) {
      return notSelected(this);
    }
    return orElse();
  }
}

abstract class LikeNotSelectedState implements LikeState {
  const factory LikeNotSelectedState({required int likes}) =
      _$LikeNotSelectedState;

  int get likes;
  @JsonKey(ignore: true)
  $LikeNotSelectedStateCopyWith<LikeNotSelectedState> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $LikeSelectedStateCopyWith<$Res> {
  factory $LikeSelectedStateCopyWith(
          LikeSelectedState value, $Res Function(LikeSelectedState) then) =
      _$LikeSelectedStateCopyWithImpl<$Res>;
  $Res call({int likes});
}

/// @nodoc
class _$LikeSelectedStateCopyWithImpl<$Res>
    extends _$LikeStateCopyWithImpl<$Res>
    implements $LikeSelectedStateCopyWith<$Res> {
  _$LikeSelectedStateCopyWithImpl(
      LikeSelectedState _value, $Res Function(LikeSelectedState) _then)
      : super(_value, (v) => _then(v as LikeSelectedState));

  @override
  LikeSelectedState get _value => super._value as LikeSelectedState;

  @override
  $Res call({
    Object? likes = freezed,
  }) {
    return _then(LikeSelectedState(
      likes: likes == freezed
          ? _value.likes
          : likes // ignore: cast_nullable_to_non_nullable
              as int,
    ));
  }
}

/// @nodoc

class _$LikeSelectedState implements LikeSelectedState {
  const _$LikeSelectedState({required this.likes});

  @override
  final int likes;

  @override
  String toString() {
    return 'LikeState.selected(likes: $likes)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is LikeSelectedState &&
            const DeepCollectionEquality().equals(other.likes, likes));
  }

  @override
  int get hashCode =>
      Object.hash(runtimeType, const DeepCollectionEquality().hash(likes));

  @JsonKey(ignore: true)
  @override
  $LikeSelectedStateCopyWith<LikeSelectedState> get copyWith =>
      _$LikeSelectedStateCopyWithImpl<LikeSelectedState>(this, _$identity);

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initialSelected,
    required TResult Function() initialNotSelected,
    required TResult Function(int likes) notSelected,
    required TResult Function(int likes) selected,
    required TResult Function() loading,
    required TResult Function() error,
  }) {
    return selected(likes);
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initialSelected,
    TResult Function()? initialNotSelected,
    TResult Function(int likes)? notSelected,
    TResult Function(int likes)? selected,
    TResult Function()? loading,
    TResult Function()? error,
  }) {
    return selected?.call(likes);
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initialSelected,
    TResult Function()? initialNotSelected,
    TResult Function(int likes)? notSelected,
    TResult Function(int likes)? selected,
    TResult Function()? loading,
    TResult Function()? error,
    required TResult orElse(),
  }) {
    if (selected != null) {
      return selected(likes);
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(LikeStateInitialSelected value) initialSelected,
    required TResult Function(LikeStateInitialNotSelected value)
        initialNotSelected,
    required TResult Function(LikeNotSelectedState value) notSelected,
    required TResult Function(LikeSelectedState value) selected,
    required TResult Function(LikeStateLoading value) loading,
    required TResult Function(LikeStateError value) error,
  }) {
    return selected(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(LikeStateInitialSelected value)? initialSelected,
    TResult Function(LikeStateInitialNotSelected value)? initialNotSelected,
    TResult Function(LikeNotSelectedState value)? notSelected,
    TResult Function(LikeSelectedState value)? selected,
    TResult Function(LikeStateLoading value)? loading,
    TResult Function(LikeStateError value)? error,
  }) {
    return selected?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(LikeStateInitialSelected value)? initialSelected,
    TResult Function(LikeStateInitialNotSelected value)? initialNotSelected,
    TResult Function(LikeNotSelectedState value)? notSelected,
    TResult Function(LikeSelectedState value)? selected,
    TResult Function(LikeStateLoading value)? loading,
    TResult Function(LikeStateError value)? error,
    required TResult orElse(),
  }) {
    if (selected != null) {
      return selected(this);
    }
    return orElse();
  }
}

abstract class LikeSelectedState implements LikeState {
  const factory LikeSelectedState({required int likes}) = _$LikeSelectedState;

  int get likes;
  @JsonKey(ignore: true)
  $LikeSelectedStateCopyWith<LikeSelectedState> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $LikeStateLoadingCopyWith<$Res> {
  factory $LikeStateLoadingCopyWith(
          LikeStateLoading value, $Res Function(LikeStateLoading) then) =
      _$LikeStateLoadingCopyWithImpl<$Res>;
}

/// @nodoc
class _$LikeStateLoadingCopyWithImpl<$Res> extends _$LikeStateCopyWithImpl<$Res>
    implements $LikeStateLoadingCopyWith<$Res> {
  _$LikeStateLoadingCopyWithImpl(
      LikeStateLoading _value, $Res Function(LikeStateLoading) _then)
      : super(_value, (v) => _then(v as LikeStateLoading));

  @override
  LikeStateLoading get _value => super._value as LikeStateLoading;
}

/// @nodoc

class _$LikeStateLoading implements LikeStateLoading {
  const _$LikeStateLoading();

  @override
  String toString() {
    return 'LikeState.loading()';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType && other is LikeStateLoading);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initialSelected,
    required TResult Function() initialNotSelected,
    required TResult Function(int likes) notSelected,
    required TResult Function(int likes) selected,
    required TResult Function() loading,
    required TResult Function() error,
  }) {
    return loading();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initialSelected,
    TResult Function()? initialNotSelected,
    TResult Function(int likes)? notSelected,
    TResult Function(int likes)? selected,
    TResult Function()? loading,
    TResult Function()? error,
  }) {
    return loading?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initialSelected,
    TResult Function()? initialNotSelected,
    TResult Function(int likes)? notSelected,
    TResult Function(int likes)? selected,
    TResult Function()? loading,
    TResult Function()? error,
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
    required TResult Function(LikeStateInitialSelected value) initialSelected,
    required TResult Function(LikeStateInitialNotSelected value)
        initialNotSelected,
    required TResult Function(LikeNotSelectedState value) notSelected,
    required TResult Function(LikeSelectedState value) selected,
    required TResult Function(LikeStateLoading value) loading,
    required TResult Function(LikeStateError value) error,
  }) {
    return loading(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(LikeStateInitialSelected value)? initialSelected,
    TResult Function(LikeStateInitialNotSelected value)? initialNotSelected,
    TResult Function(LikeNotSelectedState value)? notSelected,
    TResult Function(LikeSelectedState value)? selected,
    TResult Function(LikeStateLoading value)? loading,
    TResult Function(LikeStateError value)? error,
  }) {
    return loading?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(LikeStateInitialSelected value)? initialSelected,
    TResult Function(LikeStateInitialNotSelected value)? initialNotSelected,
    TResult Function(LikeNotSelectedState value)? notSelected,
    TResult Function(LikeSelectedState value)? selected,
    TResult Function(LikeStateLoading value)? loading,
    TResult Function(LikeStateError value)? error,
    required TResult orElse(),
  }) {
    if (loading != null) {
      return loading(this);
    }
    return orElse();
  }
}

abstract class LikeStateLoading implements LikeState {
  const factory LikeStateLoading() = _$LikeStateLoading;
}

/// @nodoc
abstract class $LikeStateErrorCopyWith<$Res> {
  factory $LikeStateErrorCopyWith(
          LikeStateError value, $Res Function(LikeStateError) then) =
      _$LikeStateErrorCopyWithImpl<$Res>;
}

/// @nodoc
class _$LikeStateErrorCopyWithImpl<$Res> extends _$LikeStateCopyWithImpl<$Res>
    implements $LikeStateErrorCopyWith<$Res> {
  _$LikeStateErrorCopyWithImpl(
      LikeStateError _value, $Res Function(LikeStateError) _then)
      : super(_value, (v) => _then(v as LikeStateError));

  @override
  LikeStateError get _value => super._value as LikeStateError;
}

/// @nodoc

class _$LikeStateError implements LikeStateError {
  const _$LikeStateError();

  @override
  String toString() {
    return 'LikeState.error()';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType && other is LikeStateError);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initialSelected,
    required TResult Function() initialNotSelected,
    required TResult Function(int likes) notSelected,
    required TResult Function(int likes) selected,
    required TResult Function() loading,
    required TResult Function() error,
  }) {
    return error();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initialSelected,
    TResult Function()? initialNotSelected,
    TResult Function(int likes)? notSelected,
    TResult Function(int likes)? selected,
    TResult Function()? loading,
    TResult Function()? error,
  }) {
    return error?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initialSelected,
    TResult Function()? initialNotSelected,
    TResult Function(int likes)? notSelected,
    TResult Function(int likes)? selected,
    TResult Function()? loading,
    TResult Function()? error,
    required TResult orElse(),
  }) {
    if (error != null) {
      return error();
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(LikeStateInitialSelected value) initialSelected,
    required TResult Function(LikeStateInitialNotSelected value)
        initialNotSelected,
    required TResult Function(LikeNotSelectedState value) notSelected,
    required TResult Function(LikeSelectedState value) selected,
    required TResult Function(LikeStateLoading value) loading,
    required TResult Function(LikeStateError value) error,
  }) {
    return error(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(LikeStateInitialSelected value)? initialSelected,
    TResult Function(LikeStateInitialNotSelected value)? initialNotSelected,
    TResult Function(LikeNotSelectedState value)? notSelected,
    TResult Function(LikeSelectedState value)? selected,
    TResult Function(LikeStateLoading value)? loading,
    TResult Function(LikeStateError value)? error,
  }) {
    return error?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(LikeStateInitialSelected value)? initialSelected,
    TResult Function(LikeStateInitialNotSelected value)? initialNotSelected,
    TResult Function(LikeNotSelectedState value)? notSelected,
    TResult Function(LikeSelectedState value)? selected,
    TResult Function(LikeStateLoading value)? loading,
    TResult Function(LikeStateError value)? error,
    required TResult orElse(),
  }) {
    if (error != null) {
      return error(this);
    }
    return orElse();
  }
}

abstract class LikeStateError implements LikeState {
  const factory LikeStateError() = _$LikeStateError;
}
