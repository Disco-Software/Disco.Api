// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target

part of 'profile_state.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more informations: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

/// @nodoc
class _$ProfileStateTearOff {
  const _$ProfileStateTearOff();

  ProfileStateInitial initial() {
    return const ProfileStateInitial();
  }

  ProfileStateLoading loading() {
    return const ProfileStateLoading();
  }

  ProfileStateLoaded loaded({required User user}) {
    return ProfileStateLoaded(
      user: user,
    );
  }

  ProfileStateSaved saved(
      {required User user, required List<Post> savedPosts}) {
    return ProfileStateSaved(
      user: user,
      savedPosts: savedPosts,
    );
  }

  ProfileStateError error() {
    return const ProfileStateError();
  }
}

/// @nodoc
const $ProfileState = _$ProfileStateTearOff();

/// @nodoc
mixin _$ProfileState {
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initial,
    required TResult Function() loading,
    required TResult Function(User user) loaded,
    required TResult Function(User user, List<Post> savedPosts) saved,
    required TResult Function() error,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function()? loading,
    TResult Function(User user)? loaded,
    TResult Function(User user, List<Post> savedPosts)? saved,
    TResult Function()? error,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function()? loading,
    TResult Function(User user)? loaded,
    TResult Function(User user, List<Post> savedPosts)? saved,
    TResult Function()? error,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(ProfileStateInitial value) initial,
    required TResult Function(ProfileStateLoading value) loading,
    required TResult Function(ProfileStateLoaded value) loaded,
    required TResult Function(ProfileStateSaved value) saved,
    required TResult Function(ProfileStateError value) error,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(ProfileStateInitial value)? initial,
    TResult Function(ProfileStateLoading value)? loading,
    TResult Function(ProfileStateLoaded value)? loaded,
    TResult Function(ProfileStateSaved value)? saved,
    TResult Function(ProfileStateError value)? error,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(ProfileStateInitial value)? initial,
    TResult Function(ProfileStateLoading value)? loading,
    TResult Function(ProfileStateLoaded value)? loaded,
    TResult Function(ProfileStateSaved value)? saved,
    TResult Function(ProfileStateError value)? error,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $ProfileStateCopyWith<$Res> {
  factory $ProfileStateCopyWith(
          ProfileState value, $Res Function(ProfileState) then) =
      _$ProfileStateCopyWithImpl<$Res>;
}

/// @nodoc
class _$ProfileStateCopyWithImpl<$Res> implements $ProfileStateCopyWith<$Res> {
  _$ProfileStateCopyWithImpl(this._value, this._then);

  final ProfileState _value;
  // ignore: unused_field
  final $Res Function(ProfileState) _then;
}

/// @nodoc
abstract class $ProfileStateInitialCopyWith<$Res> {
  factory $ProfileStateInitialCopyWith(
          ProfileStateInitial value, $Res Function(ProfileStateInitial) then) =
      _$ProfileStateInitialCopyWithImpl<$Res>;
}

/// @nodoc
class _$ProfileStateInitialCopyWithImpl<$Res>
    extends _$ProfileStateCopyWithImpl<$Res>
    implements $ProfileStateInitialCopyWith<$Res> {
  _$ProfileStateInitialCopyWithImpl(
      ProfileStateInitial _value, $Res Function(ProfileStateInitial) _then)
      : super(_value, (v) => _then(v as ProfileStateInitial));

  @override
  ProfileStateInitial get _value => super._value as ProfileStateInitial;
}

/// @nodoc

class _$ProfileStateInitial implements ProfileStateInitial {
  const _$ProfileStateInitial();

  @override
  String toString() {
    return 'ProfileState.initial()';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType && other is ProfileStateInitial);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initial,
    required TResult Function() loading,
    required TResult Function(User user) loaded,
    required TResult Function(User user, List<Post> savedPosts) saved,
    required TResult Function() error,
  }) {
    return initial();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function()? loading,
    TResult Function(User user)? loaded,
    TResult Function(User user, List<Post> savedPosts)? saved,
    TResult Function()? error,
  }) {
    return initial?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function()? loading,
    TResult Function(User user)? loaded,
    TResult Function(User user, List<Post> savedPosts)? saved,
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
    required TResult Function(ProfileStateInitial value) initial,
    required TResult Function(ProfileStateLoading value) loading,
    required TResult Function(ProfileStateLoaded value) loaded,
    required TResult Function(ProfileStateSaved value) saved,
    required TResult Function(ProfileStateError value) error,
  }) {
    return initial(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(ProfileStateInitial value)? initial,
    TResult Function(ProfileStateLoading value)? loading,
    TResult Function(ProfileStateLoaded value)? loaded,
    TResult Function(ProfileStateSaved value)? saved,
    TResult Function(ProfileStateError value)? error,
  }) {
    return initial?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(ProfileStateInitial value)? initial,
    TResult Function(ProfileStateLoading value)? loading,
    TResult Function(ProfileStateLoaded value)? loaded,
    TResult Function(ProfileStateSaved value)? saved,
    TResult Function(ProfileStateError value)? error,
    required TResult orElse(),
  }) {
    if (initial != null) {
      return initial(this);
    }
    return orElse();
  }
}

abstract class ProfileStateInitial implements ProfileState {
  const factory ProfileStateInitial() = _$ProfileStateInitial;
}

/// @nodoc
abstract class $ProfileStateLoadingCopyWith<$Res> {
  factory $ProfileStateLoadingCopyWith(
          ProfileStateLoading value, $Res Function(ProfileStateLoading) then) =
      _$ProfileStateLoadingCopyWithImpl<$Res>;
}

/// @nodoc
class _$ProfileStateLoadingCopyWithImpl<$Res>
    extends _$ProfileStateCopyWithImpl<$Res>
    implements $ProfileStateLoadingCopyWith<$Res> {
  _$ProfileStateLoadingCopyWithImpl(
      ProfileStateLoading _value, $Res Function(ProfileStateLoading) _then)
      : super(_value, (v) => _then(v as ProfileStateLoading));

  @override
  ProfileStateLoading get _value => super._value as ProfileStateLoading;
}

/// @nodoc

class _$ProfileStateLoading implements ProfileStateLoading {
  const _$ProfileStateLoading();

  @override
  String toString() {
    return 'ProfileState.loading()';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType && other is ProfileStateLoading);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initial,
    required TResult Function() loading,
    required TResult Function(User user) loaded,
    required TResult Function(User user, List<Post> savedPosts) saved,
    required TResult Function() error,
  }) {
    return loading();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function()? loading,
    TResult Function(User user)? loaded,
    TResult Function(User user, List<Post> savedPosts)? saved,
    TResult Function()? error,
  }) {
    return loading?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function()? loading,
    TResult Function(User user)? loaded,
    TResult Function(User user, List<Post> savedPosts)? saved,
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
    required TResult Function(ProfileStateInitial value) initial,
    required TResult Function(ProfileStateLoading value) loading,
    required TResult Function(ProfileStateLoaded value) loaded,
    required TResult Function(ProfileStateSaved value) saved,
    required TResult Function(ProfileStateError value) error,
  }) {
    return loading(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(ProfileStateInitial value)? initial,
    TResult Function(ProfileStateLoading value)? loading,
    TResult Function(ProfileStateLoaded value)? loaded,
    TResult Function(ProfileStateSaved value)? saved,
    TResult Function(ProfileStateError value)? error,
  }) {
    return loading?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(ProfileStateInitial value)? initial,
    TResult Function(ProfileStateLoading value)? loading,
    TResult Function(ProfileStateLoaded value)? loaded,
    TResult Function(ProfileStateSaved value)? saved,
    TResult Function(ProfileStateError value)? error,
    required TResult orElse(),
  }) {
    if (loading != null) {
      return loading(this);
    }
    return orElse();
  }
}

abstract class ProfileStateLoading implements ProfileState {
  const factory ProfileStateLoading() = _$ProfileStateLoading;
}

/// @nodoc
abstract class $ProfileStateLoadedCopyWith<$Res> {
  factory $ProfileStateLoadedCopyWith(
          ProfileStateLoaded value, $Res Function(ProfileStateLoaded) then) =
      _$ProfileStateLoadedCopyWithImpl<$Res>;
  $Res call({User user});
}

/// @nodoc
class _$ProfileStateLoadedCopyWithImpl<$Res>
    extends _$ProfileStateCopyWithImpl<$Res>
    implements $ProfileStateLoadedCopyWith<$Res> {
  _$ProfileStateLoadedCopyWithImpl(
      ProfileStateLoaded _value, $Res Function(ProfileStateLoaded) _then)
      : super(_value, (v) => _then(v as ProfileStateLoaded));

  @override
  ProfileStateLoaded get _value => super._value as ProfileStateLoaded;

  @override
  $Res call({
    Object? user = freezed,
  }) {
    return _then(ProfileStateLoaded(
      user: user == freezed
          ? _value.user
          : user // ignore: cast_nullable_to_non_nullable
              as User,
    ));
  }
}

/// @nodoc

class _$ProfileStateLoaded implements ProfileStateLoaded {
  const _$ProfileStateLoaded({required this.user});

  @override
  final User user;

  @override
  String toString() {
    return 'ProfileState.loaded(user: $user)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is ProfileStateLoaded &&
            const DeepCollectionEquality().equals(other.user, user));
  }

  @override
  int get hashCode =>
      Object.hash(runtimeType, const DeepCollectionEquality().hash(user));

  @JsonKey(ignore: true)
  @override
  $ProfileStateLoadedCopyWith<ProfileStateLoaded> get copyWith =>
      _$ProfileStateLoadedCopyWithImpl<ProfileStateLoaded>(this, _$identity);

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initial,
    required TResult Function() loading,
    required TResult Function(User user) loaded,
    required TResult Function(User user, List<Post> savedPosts) saved,
    required TResult Function() error,
  }) {
    return loaded(user);
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function()? loading,
    TResult Function(User user)? loaded,
    TResult Function(User user, List<Post> savedPosts)? saved,
    TResult Function()? error,
  }) {
    return loaded?.call(user);
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function()? loading,
    TResult Function(User user)? loaded,
    TResult Function(User user, List<Post> savedPosts)? saved,
    TResult Function()? error,
    required TResult orElse(),
  }) {
    if (loaded != null) {
      return loaded(user);
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(ProfileStateInitial value) initial,
    required TResult Function(ProfileStateLoading value) loading,
    required TResult Function(ProfileStateLoaded value) loaded,
    required TResult Function(ProfileStateSaved value) saved,
    required TResult Function(ProfileStateError value) error,
  }) {
    return loaded(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(ProfileStateInitial value)? initial,
    TResult Function(ProfileStateLoading value)? loading,
    TResult Function(ProfileStateLoaded value)? loaded,
    TResult Function(ProfileStateSaved value)? saved,
    TResult Function(ProfileStateError value)? error,
  }) {
    return loaded?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(ProfileStateInitial value)? initial,
    TResult Function(ProfileStateLoading value)? loading,
    TResult Function(ProfileStateLoaded value)? loaded,
    TResult Function(ProfileStateSaved value)? saved,
    TResult Function(ProfileStateError value)? error,
    required TResult orElse(),
  }) {
    if (loaded != null) {
      return loaded(this);
    }
    return orElse();
  }
}

abstract class ProfileStateLoaded implements ProfileState {
  const factory ProfileStateLoaded({required User user}) = _$ProfileStateLoaded;

  User get user;
  @JsonKey(ignore: true)
  $ProfileStateLoadedCopyWith<ProfileStateLoaded> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $ProfileStateSavedCopyWith<$Res> {
  factory $ProfileStateSavedCopyWith(
          ProfileStateSaved value, $Res Function(ProfileStateSaved) then) =
      _$ProfileStateSavedCopyWithImpl<$Res>;
  $Res call({User user, List<Post> savedPosts});
}

/// @nodoc
class _$ProfileStateSavedCopyWithImpl<$Res>
    extends _$ProfileStateCopyWithImpl<$Res>
    implements $ProfileStateSavedCopyWith<$Res> {
  _$ProfileStateSavedCopyWithImpl(
      ProfileStateSaved _value, $Res Function(ProfileStateSaved) _then)
      : super(_value, (v) => _then(v as ProfileStateSaved));

  @override
  ProfileStateSaved get _value => super._value as ProfileStateSaved;

  @override
  $Res call({
    Object? user = freezed,
    Object? savedPosts = freezed,
  }) {
    return _then(ProfileStateSaved(
      user: user == freezed
          ? _value.user
          : user // ignore: cast_nullable_to_non_nullable
              as User,
      savedPosts: savedPosts == freezed
          ? _value.savedPosts
          : savedPosts // ignore: cast_nullable_to_non_nullable
              as List<Post>,
    ));
  }
}

/// @nodoc

class _$ProfileStateSaved implements ProfileStateSaved {
  const _$ProfileStateSaved({required this.user, required this.savedPosts});

  @override
  final User user;
  @override
  final List<Post> savedPosts;

  @override
  String toString() {
    return 'ProfileState.saved(user: $user, savedPosts: $savedPosts)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is ProfileStateSaved &&
            const DeepCollectionEquality().equals(other.user, user) &&
            const DeepCollectionEquality()
                .equals(other.savedPosts, savedPosts));
  }

  @override
  int get hashCode => Object.hash(
      runtimeType,
      const DeepCollectionEquality().hash(user),
      const DeepCollectionEquality().hash(savedPosts));

  @JsonKey(ignore: true)
  @override
  $ProfileStateSavedCopyWith<ProfileStateSaved> get copyWith =>
      _$ProfileStateSavedCopyWithImpl<ProfileStateSaved>(this, _$identity);

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initial,
    required TResult Function() loading,
    required TResult Function(User user) loaded,
    required TResult Function(User user, List<Post> savedPosts) saved,
    required TResult Function() error,
  }) {
    return saved(user, savedPosts);
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function()? loading,
    TResult Function(User user)? loaded,
    TResult Function(User user, List<Post> savedPosts)? saved,
    TResult Function()? error,
  }) {
    return saved?.call(user, savedPosts);
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function()? loading,
    TResult Function(User user)? loaded,
    TResult Function(User user, List<Post> savedPosts)? saved,
    TResult Function()? error,
    required TResult orElse(),
  }) {
    if (saved != null) {
      return saved(user, savedPosts);
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(ProfileStateInitial value) initial,
    required TResult Function(ProfileStateLoading value) loading,
    required TResult Function(ProfileStateLoaded value) loaded,
    required TResult Function(ProfileStateSaved value) saved,
    required TResult Function(ProfileStateError value) error,
  }) {
    return saved(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(ProfileStateInitial value)? initial,
    TResult Function(ProfileStateLoading value)? loading,
    TResult Function(ProfileStateLoaded value)? loaded,
    TResult Function(ProfileStateSaved value)? saved,
    TResult Function(ProfileStateError value)? error,
  }) {
    return saved?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(ProfileStateInitial value)? initial,
    TResult Function(ProfileStateLoading value)? loading,
    TResult Function(ProfileStateLoaded value)? loaded,
    TResult Function(ProfileStateSaved value)? saved,
    TResult Function(ProfileStateError value)? error,
    required TResult orElse(),
  }) {
    if (saved != null) {
      return saved(this);
    }
    return orElse();
  }
}

abstract class ProfileStateSaved implements ProfileState {
  const factory ProfileStateSaved(
      {required User user,
      required List<Post> savedPosts}) = _$ProfileStateSaved;

  User get user;
  List<Post> get savedPosts;
  @JsonKey(ignore: true)
  $ProfileStateSavedCopyWith<ProfileStateSaved> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $ProfileStateErrorCopyWith<$Res> {
  factory $ProfileStateErrorCopyWith(
          ProfileStateError value, $Res Function(ProfileStateError) then) =
      _$ProfileStateErrorCopyWithImpl<$Res>;
}

/// @nodoc
class _$ProfileStateErrorCopyWithImpl<$Res>
    extends _$ProfileStateCopyWithImpl<$Res>
    implements $ProfileStateErrorCopyWith<$Res> {
  _$ProfileStateErrorCopyWithImpl(
      ProfileStateError _value, $Res Function(ProfileStateError) _then)
      : super(_value, (v) => _then(v as ProfileStateError));

  @override
  ProfileStateError get _value => super._value as ProfileStateError;
}

/// @nodoc

class _$ProfileStateError implements ProfileStateError {
  const _$ProfileStateError();

  @override
  String toString() {
    return 'ProfileState.error()';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType && other is ProfileStateError);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() initial,
    required TResult Function() loading,
    required TResult Function(User user) loaded,
    required TResult Function(User user, List<Post> savedPosts) saved,
    required TResult Function() error,
  }) {
    return error();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function()? loading,
    TResult Function(User user)? loaded,
    TResult Function(User user, List<Post> savedPosts)? saved,
    TResult Function()? error,
  }) {
    return error?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? initial,
    TResult Function()? loading,
    TResult Function(User user)? loaded,
    TResult Function(User user, List<Post> savedPosts)? saved,
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
    required TResult Function(ProfileStateInitial value) initial,
    required TResult Function(ProfileStateLoading value) loading,
    required TResult Function(ProfileStateLoaded value) loaded,
    required TResult Function(ProfileStateSaved value) saved,
    required TResult Function(ProfileStateError value) error,
  }) {
    return error(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult Function(ProfileStateInitial value)? initial,
    TResult Function(ProfileStateLoading value)? loading,
    TResult Function(ProfileStateLoaded value)? loaded,
    TResult Function(ProfileStateSaved value)? saved,
    TResult Function(ProfileStateError value)? error,
  }) {
    return error?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(ProfileStateInitial value)? initial,
    TResult Function(ProfileStateLoading value)? loading,
    TResult Function(ProfileStateLoaded value)? loaded,
    TResult Function(ProfileStateSaved value)? saved,
    TResult Function(ProfileStateError value)? error,
    required TResult orElse(),
  }) {
    if (error != null) {
      return error(this);
    }
    return orElse();
  }
}

abstract class ProfileStateError implements ProfileState {
  const factory ProfileStateError() = _$ProfileStateError;
}
