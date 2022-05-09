import 'package:signalr_netcore/hub_connection_builder.dart';

const String serverUrl = 'http://localhost/Disco.Api/hub/like';

class LikeHub {
  final hubConnection = HubConnectionBuilder().withUrl(serverUrl).build();
}
