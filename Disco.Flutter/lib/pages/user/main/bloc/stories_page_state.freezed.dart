// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target

part of 'stories_page_state.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more informations: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

/// @nodoc
class _$StoriesPageStateTearOff {
  const _$StoriesPageStateTearOff();

  StoriesPageStateInitial initial() {
    return const StoriesPageStateInitial();
  }

  StoriesPageStateRunning running({required int duration}) {
    return StoriesPageStateRunning(
      duration: duration,
    );
  }

  StoriesPageStateFinished finished() {
    return const StoriesPageStateFinished();
  }

  StoriesPageStatePaused paused() {
    return const StoriesPageStatePaused();
  }
}

/// @nodoc
const $StoriesPageState = _$StoriesPageStateTearOff();

/// @nodoc
mixin _$StoriesPageState {
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initial,
    required TResult Function(int duration) running,
    required TResult Function() finished,
    required TResult Function() paused,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function(int duration)? running,
    TResult Function()? finished,
    TResult Function()? paused,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function(int duration)? running,
    TResult Function()? finished,
    TResult Function()? paused,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(StoriesPageStateInitial value) initial,
    required TResult Function(StoriesPageStateRunning value) running,
    required TResult Function(StoriesPageStateFinished value) finished,
    required TResult Function(StoriesPageStatePaused value) paused,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(StoriesPageStateInitial value)? initial,
    TResult Function(StoriesPageStateRunning value)? running,
    TResult Function(StoriesPageStateFinished value)? finished,
    TResult Function(StoriesPageStatePaused value)? paused,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(StoriesPageStateInitial value)? initial,
    TResult Function(StoriesPageStateRunning value)? running,
    TResult Function(StoriesPageStateFinished value)? finished,
    TResult Function(StoriesPageStatePaused value)? paused,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $StoriesPageStateCopyWith<$Res> {
  factory $StoriesPageStateCopyWith(
          StoriesPageState value, $Res Function(StoriesPageState) then) =
      _$StoriesPageStateCopyWithImpl<$Res>;
}

/// @nodoc
class _$StoriesPageStateCopyWithImpl<$Res>
    implements $StoriesPageStateCopyWith<$Res> {
  _$StoriesPageStateCopyWithImpl(this._value, this._then);

  final StoriesPageState _value;
  // ignore: unused_field
  final $Res Function(StoriesPageState) _then;
}

/// @nodoc
abstract class $StoriesPageStateInitialCopyWith<$Res> {
  factory $StoriesPageStateInitialCopyWith(StoriesPageStateInitial value,
          $Res Function(StoriesPageStateInitial) then) =
      _$StoriesPageStateInitialCopyWithImpl<$Res>;
}

/// @nodoc
class _$StoriesPageStateInitialCopyWithImpl<$Res>
    extends _$StoriesPageStateCopyWithImpl<$Res>
    implements $StoriesPageStateInitialCopyWith<$Res> {
  _$StoriesPageStateInitialCopyWithImpl(StoriesPageStateInitial _value,
      $Res Function(StoriesPageStateInitial) _then)
      : super(_value, (v) => _then(v as StoriesPageStateInitial));

  @override
  StoriesPageStateInitial get _value => super._value as StoriesPageStateInitial;
}

/// @nodoc

class _$StoriesPageStateInitial implements StoriesPageStateInitial {
  const _$StoriesPageStateInitial();

  @override
  String toString() {
    return 'StoriesPageState.initial()';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType && other is StoriesPageStateInitial);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initial,
    required TResult Function(int duration) running,
    required TResult Function() finished,
    required TResult Function() paused,
  }) {
    return initial();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function(int duration)? running,
    TResult Function()? finished,
    TResult Function()? paused,
  }) {
    return initial?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function(int duration)? running,
    TResult Function()? finished,
    TResult Function()? paused,
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
    required TResult Function(StoriesPageStateInitial value) initial,
    required TResult Function(StoriesPageStateRunning value) running,
    required TResult Function(StoriesPageStateFinished value) finished,
    required TResult Function(StoriesPageStatePaused value) paused,
  }) {
    return initial(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(StoriesPageStateInitial value)? initial,
    TResult Function(StoriesPageStateRunning value)? running,
    TResult Function(StoriesPageStateFinished value)? finished,
    TResult Function(StoriesPageStatePaused value)? paused,
  }) {
    return initial?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(StoriesPageStateInitial value)? initial,
    TResult Function(StoriesPageStateRunning value)? running,
    TResult Function(StoriesPageStateFinished value)? finished,
    TResult Function(StoriesPageStatePaused value)? paused,
    required TResult orElse(),
  }) {
    if (initial != null) {
      return initial(this);
    }
    return orElse();
  }
}

abstract class StoriesPageStateInitial implements StoriesPageState {
  const factory StoriesPageStateInitial() = _$StoriesPageStateInitial;
}

/// @nodoc
abstract class $StoriesPageStateRunningCopyWith<$Res> {
  factory $StoriesPageStateRunningCopyWith(StoriesPageStateRunning value,
          $Res Function(StoriesPageStateRunning) then) =
      _$StoriesPageStateRunningCopyWithImpl<$Res>;
  $Res call({int duration});
}

/// @nodoc
class _$StoriesPageStateRunningCopyWithImpl<$Res>
    extends _$StoriesPageStateCopyWithImpl<$Res>
    implements $StoriesPageStateRunningCopyWith<$Res> {
  _$StoriesPageStateRunningCopyWithImpl(StoriesPageStateRunning _value,
      $Res Function(StoriesPageStateRunning) _then)
      : super(_value, (v) => _then(v as StoriesPageStateRunning));

  @override
  StoriesPageStateRunning get _value => super._value as StoriesPageStateRunning;

  @override
  $Res call({
    Object? duration = freezed,
  }) {
    return _then(StoriesPageStateRunning(
      duration: duration == freezed
          ? _value.duration
          : duration // ignore: cast_nullable_to_non_nullable
              as int,
    ));
  }
}

/// @nodoc

class _$StoriesPageStateRunning implements StoriesPageStateRunning {
  const _$StoriesPageStateRunning({required this.duration});

  @override
  final int duration;

  @override
  String toString() {
    return 'StoriesPageState.running(duration: $duration)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is StoriesPageStateRunning &&
            const DeepCollectionEquality().equals(other.duration, duration));
  }

  @override
  int get hashCode =>
      Object.hash(runtimeType, const DeepCollectionEquality().hash(duration));

  @JsonKey(ignore: true)
  @override
  $StoriesPageStateRunningCopyWith<StoriesPageStateRunning> get copyWith =>
      _$StoriesPageStateRunningCopyWithImpl<StoriesPageStateRunning>(
          this, _$identity);

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initial,
    required TResult Function(int duration) running,
    required TResult Function() finished,
    required TResult Function() paused,
  }) {
    return running(duration);
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function(int duration)? running,
    TResult Function()? finished,
    TResult Function()? paused,
  }) {
    return running?.call(duration);
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function(int duration)? running,
    TResult Function()? finished,
    TResult Function()? paused,
    required TResult orElse(),
  }) {
    if (running != null) {
      return running(duration);
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(StoriesPageStateInitial value) initial,
    required TResult Function(StoriesPageStateRunning value) running,
    required TResult Function(StoriesPageStateFinished value) finished,
    required TResult Function(StoriesPageStatePaused value) paused,
  }) {
    return running(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(StoriesPageStateInitial value)? initial,
    TResult Function(StoriesPageStateRunning value)? running,
    TResult Function(StoriesPageStateFinished value)? finished,
    TResult Function(StoriesPageStatePaused value)? paused,
  }) {
    return running?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(StoriesPageStateInitial value)? initial,
    TResult Function(StoriesPageStateRunning value)? running,
    TResult Function(StoriesPageStateFinished value)? finished,
    TResult Function(StoriesPageStatePaused value)? paused,
    required TResult orElse(),
  }) {
    if (running != null) {
      return running(this);
    }
    return orElse();
  }
}

abstract class StoriesPageStateRunning implements StoriesPageState {
  const factory StoriesPageStateRunning({required int duration}) =
      _$StoriesPageStateRunning;

  int get duration;
  @JsonKey(ignore: true)
  $StoriesPageStateRunningCopyWith<StoriesPageStateRunning> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $StoriesPageStateFinishedCopyWith<$Res> {
  factory $StoriesPageStateFinishedCopyWith(StoriesPageStateFinished value,
          $Res Function(StoriesPageStateFinished) then) =
      _$StoriesPageStateFinishedCopyWithImpl<$Res>;
}

/// @nodoc
class _$StoriesPageStateFinishedCopyWithImpl<$Res>
    extends _$StoriesPageStateCopyWithImpl<$Res>
    implements $StoriesPageStateFinishedCopyWith<$Res> {
  _$StoriesPageStateFinishedCopyWithImpl(StoriesPageStateFinished _value,
      $Res Function(StoriesPageStateFinished) _then)
      : super(_value, (v) => _then(v as StoriesPageStateFinished));

  @override
  StoriesPageStateFinished get _value =>
      super._value as StoriesPageStateFinished;
}

/// @nodoc

class _$StoriesPageStateFinished implements StoriesPageStateFinished {
  const _$StoriesPageStateFinished();

  @override
  String toString() {
    return 'StoriesPageState.finished()';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType && other is StoriesPageStateFinished);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initial,
    required TResult Function(int duration) running,
    required TResult Function() finished,
    required TResult Function() paused,
  }) {
    return finished();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function(int duration)? running,
    TResult Function()? finished,
    TResult Function()? paused,
  }) {
    return finished?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function(int duration)? running,
    TResult Function()? finished,
    TResult Function()? paused,
    required TResult orElse(),
  }) {
    if (finished != null) {
      return finished();
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(StoriesPageStateInitial value) initial,
    required TResult Function(StoriesPageStateRunning value) running,
    required TResult Function(StoriesPageStateFinished value) finished,
    required TResult Function(StoriesPageStatePaused value) paused,
  }) {
    return finished(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(StoriesPageStateInitial value)? initial,
    TResult Function(StoriesPageStateRunning value)? running,
    TResult Function(StoriesPageStateFinished value)? finished,
    TResult Function(StoriesPageStatePaused value)? paused,
  }) {
    return finished?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(StoriesPageStateInitial value)? initial,
    TResult Function(StoriesPageStateRunning value)? running,
    TResult Function(StoriesPageStateFinished value)? finished,
    TResult Function(StoriesPageStatePaused value)? paused,
    required TResult orElse(),
  }) {
    if (finished != null) {
      return finished(this);
    }
    return orElse();
  }
}

abstract class StoriesPageStateFinished implements StoriesPageState {
  const factory StoriesPageStateFinished() = _$StoriesPageStateFinished;
}

/// @nodoc
abstract class $StoriesPageStatePausedCopyWith<$Res> {
  factory $StoriesPageStatePausedCopyWith(StoriesPageStatePaused value,
          $Res Function(StoriesPageStatePaused) then) =
      _$StoriesPageStatePausedCopyWithImpl<$Res>;
}

/// @nodoc
class _$StoriesPageStatePausedCopyWithImpl<$Res>
    extends _$StoriesPageStateCopyWithImpl<$Res>
    implements $StoriesPageStatePausedCopyWith<$Res> {
  _$StoriesPageStatePausedCopyWithImpl(StoriesPageStatePaused _value,
      $Res Function(StoriesPageStatePaused) _then)
      : super(_value, (v) => _then(v as StoriesPageStatePaused));

  @override
  StoriesPageStatePaused get _value => super._value as StoriesPageStatePaused;
}

/// @nodoc

class _$StoriesPageStatePaused implements StoriesPageStatePaused {
  const _$StoriesPageStatePaused();

  @override
  String toString() {
    return 'StoriesPageState.paused()';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType && other is StoriesPageStatePaused);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initial,
    required TResult Function(int duration) running,
    required TResult Function() finished,
    required TResult Function() paused,
  }) {
    return paused();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function(int duration)? running,
    TResult Function()? finished,
    TResult Function()? paused,
  }) {
    return paused?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function(int duration)? running,
    TResult Function()? finished,
    TResult Function()? paused,
    required TResult orElse(),
  }) {
    if (paused != null) {
      return paused();
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(StoriesPageStateInitial value) initial,
    required TResult Function(StoriesPageStateRunning value) running,
    required TResult Function(StoriesPageStateFinished value) finished,
    required TResult Function(StoriesPageStatePaused value) paused,
  }) {
    return paused(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(StoriesPageStateInitial value)? initial,
    TResult Function(StoriesPageStateRunning value)? running,
    TResult Function(StoriesPageStateFinished value)? finished,
    TResult Function(StoriesPageStatePaused value)? paused,
  }) {
    return paused?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(StoriesPageStateInitial value)? initial,
    TResult Function(StoriesPageStateRunning value)? running,
    TResult Function(StoriesPageStateFinished value)? finished,
    TResult Function(StoriesPageStatePaused value)? paused,
    required TResult orElse(),
  }) {
    if (paused != null) {
      return paused(this);
    }
    return orElse();
  }
}

abstract class StoriesPageStatePaused implements StoriesPageState {
  const factory StoriesPageStatePaused() = _$StoriesPageStatePaused;
}
