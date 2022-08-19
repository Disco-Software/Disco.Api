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

  LikeStateInitial initial() {
    return const LikeStateInitial();
  }

  LikeStateSuccess success({required int likes}) {
    return LikeStateSuccess(
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
    required TResult Function() initial,
    required TResult Function(int likes) success,
    required TResult Function() loading,
    required TResult Function() error,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function(int likes)? success,
    TResult Function()? loading,
    TResult Function()? error,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function(int likes)? success,
    TResult Function()? loading,
    TResult Function()? error,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(LikeStateInitial value) initial,
    required TResult Function(LikeStateSuccess value) success,
    required TResult Function(LikeStateLoading value) loading,
    required TResult Function(LikeStateError value) error,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(LikeStateInitial value)? initial,
    TResult Function(LikeStateSuccess value)? success,
    TResult Function(LikeStateLoading value)? loading,
    TResult Function(LikeStateError value)? error,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(LikeStateInitial value)? initial,
    TResult Function(LikeStateSuccess value)? success,
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
abstract class $LikeStateInitialCopyWith<$Res> {
  factory $LikeStateInitialCopyWith(
          LikeStateInitial value, $Res Function(LikeStateInitial) then) =
      _$LikeStateInitialCopyWithImpl<$Res>;
}

/// @nodoc
class _$LikeStateInitialCopyWithImpl<$Res> extends _$LikeStateCopyWithImpl<$Res>
    implements $LikeStateInitialCopyWith<$Res> {
  _$LikeStateInitialCopyWithImpl(
      LikeStateInitial _value, $Res Function(LikeStateInitial) _then)
      : super(_value, (v) => _then(v as LikeStateInitial));

  @override
  LikeStateInitial get _value => super._value as LikeStateInitial;
}

/// @nodoc

class _$LikeStateInitial implements LikeStateInitial {
  const _$LikeStateInitial();

  @override
  String toString() {
    return 'LikeState.initial()';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType && other is LikeStateInitial);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initial,
    required TResult Function(int likes) success,
    required TResult Function() loading,
    required TResult Function() error,
  }) {
    return initial();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function(int likes)? success,
    TResult Function()? loading,
    TResult Function()? error,
  }) {
    return initial?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function(int likes)? success,
    TResult Function()? loading,
    TResult Function()? error,
    required TResult orElse(),
  }) {
    if (initial != null) {
      return initial();
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(LikeStateInitial value) initial,
    required TResult Function(LikeStateSuccess value) success,
    required TResult Function(LikeStateLoading value) loading,
    required TResult Function(LikeStateError value) error,
  }) {
    return initial(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(LikeStateInitial value)? initial,
    TResult Function(LikeStateSuccess value)? success,
    TResult Function(LikeStateLoading value)? loading,
    TResult Function(LikeStateError value)? error,
  }) {
    return initial?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(LikeStateInitial value)? initial,
    TResult Function(LikeStateSuccess value)? success,
    TResult Function(LikeStateLoading value)? loading,
    TResult Function(LikeStateError value)? error,
    required TResult orElse(),
  }) {
    if (initial != null) {
      return initial(this);
    }
    return orElse();
  }
}

abstract class LikeStateInitial implements LikeState {
  const factory LikeStateInitial() = _$LikeStateInitial;
}

/// @nodoc
abstract class $LikeStateSuccessCopyWith<$Res> {
  factory $LikeStateSuccessCopyWith(
          LikeStateSuccess value, $Res Function(LikeStateSuccess) then) =
      _$LikeStateSuccessCopyWithImpl<$Res>;
  $Res call({int likes});
}

/// @nodoc
class _$LikeStateSuccessCopyWithImpl<$Res> extends _$LikeStateCopyWithImpl<$Res>
    implements $LikeStateSuccessCopyWith<$Res> {
  _$LikeStateSuccessCopyWithImpl(
      LikeStateSuccess _value, $Res Function(LikeStateSuccess) _then)
      : super(_value, (v) => _then(v as LikeStateSuccess));

  @override
  LikeStateSuccess get _value => super._value as LikeStateSuccess;

  @override
  $Res call({
    Object? likes = freezed,
  }) {
    return _then(LikeStateSuccess(
      likes: likes == freezed
          ? _value.likes
          : likes // ignore: cast_nullable_to_non_nullable
              as int,
    ));
  }
}

/// @nodoc

class _$LikeStateSuccess implements LikeStateSuccess {
  const _$LikeStateSuccess({required this.likes});

  @override
  final int likes;

  @override
  String toString() {
    return 'LikeState.success(likes: $likes)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is LikeStateSuccess &&
            const DeepCollectionEquality().equals(other.likes, likes));
  }

  @override
  int get hashCode =>
      Object.hash(runtimeType, const DeepCollectionEquality().hash(likes));

  @JsonKey(ignore: true)
  @override
  $LikeStateSuccessCopyWith<LikeStateSuccess> get copyWith =>
      _$LikeStateSuccessCopyWithImpl<LikeStateSuccess>(this, _$identity);

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initial,
    required TResult Function(int likes) success,
    required TResult Function() loading,
    required TResult Function() error,
  }) {
    return success(likes);
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function(int likes)? success,
    TResult Function()? loading,
    TResult Function()? error,
  }) {
    return success?.call(likes);
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function(int likes)? success,
    TResult Function()? loading,
    TResult Function()? error,
    required TResult orElse(),
  }) {
    if (success != null) {
      return success(likes);
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(LikeStateInitial value) initial,
    required TResult Function(LikeStateSuccess value) success,
    required TResult Function(LikeStateLoading value) loading,
    required TResult Function(LikeStateError value) error,
  }) {
    return success(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(LikeStateInitial value)? initial,
    TResult Function(LikeStateSuccess value)? success,
    TResult Function(LikeStateLoading value)? loading,
    TResult Function(LikeStateError value)? error,
  }) {
    return success?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(LikeStateInitial value)? initial,
    TResult Function(LikeStateSuccess value)? success,
    TResult Function(LikeStateLoading value)? loading,
    TResult Function(LikeStateError value)? error,
    required TResult orElse(),
  }) {
    if (success != null) {
      return success(this);
    }
    return orElse();
  }
}

abstract class LikeStateSuccess implements LikeState {
  const factory LikeStateSuccess({required int likes}) = _$LikeStateSuccess;

  int get likes;
  @JsonKey(ignore: true)
  $LikeStateSuccessCopyWith<LikeStateSuccess> get copyWith =>
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
    required TResult Function() initial,
    required TResult Function(int likes) success,
    required TResult Function() loading,
    required TResult Function() error,
  }) {
    return loading();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function(int likes)? success,
    TResult Function()? loading,
    TResult Function()? error,
  }) {
    return loading?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function(int likes)? success,
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
    required TResult Function(LikeStateInitial value) initial,
    required TResult Function(LikeStateSuccess value) success,
    required TResult Function(LikeStateLoading value) loading,
    required TResult Function(LikeStateError value) error,
  }) {
    return loading(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(LikeStateInitial value)? initial,
    TResult Function(LikeStateSuccess value)? success,
    TResult Function(LikeStateLoading value)? loading,
    TResult Function(LikeStateError value)? error,
  }) {
    return loading?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(LikeStateInitial value)? initial,
    TResult Function(LikeStateSuccess value)? success,
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
    required TResult Function() initial,
    required TResult Function(int likes) success,
    required TResult Function() loading,
    required TResult Function() error,
  }) {
    return error();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function(int likes)? success,
    TResult Function()? loading,
    TResult Function()? error,
  }) {
    return error?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function(int likes)? success,
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
    required TResult Function(LikeStateInitial value) initial,
    required TResult Function(LikeStateSuccess value) success,
    required TResult Function(LikeStateLoading value) loading,
    required TResult Function(LikeStateError value) error,
  }) {
    return error(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(LikeStateInitial value)? initial,
    TResult Function(LikeStateSuccess value)? success,
    TResult Function(LikeStateLoading value)? loading,
    TResult Function(LikeStateError value)? error,
  }) {
    return error?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(LikeStateInitial value)? initial,
    TResult Function(LikeStateSuccess value)? success,
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
