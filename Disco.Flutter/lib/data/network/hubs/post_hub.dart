import 'package:signal'
    'r_client/hub_connection.dart';
import 'package:signalr_client/hub_connection_builder.dart';

const String serverUrl =
    "https://discoapi20211205192712.azurewebsites.net/hub/post";

class PostHub {
  HubConnection hubConnection =
      HubConnectionBuilder().withUrl(serverUrl).build();

  void connect() {
    hubConnection.onclose((error) {
      print("server connection was closed");
    });
    //hubConnection.on("AddLike", postLikes);
  }

  void postLikes(String postId) {
    hubConnection.invoke('add', args: [postId]);
  }
}
