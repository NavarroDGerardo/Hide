using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class CustomNetworkManager : NetworkManager
{
    public GameObject seekerPrefab;
    // Server callbacks
    public override void OnServerConnect(NetworkConnection conn)
    {
        Debug.Log("A client connected to the server: " + conn);
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        NetworkServer.DestroyPlayersForConnection(conn);
        if (conn.lastError != NetworkError.Ok)
        {
            if (LogFilter.logError) { Debug.LogError("ServerDisconnected due to error: " + conn.lastError); }
        }
        Debug.Log("A client disconnected from the server: " + conn);
    }
    public override void OnServerReady(NetworkConnection conn)
    {
        NetworkServer.SetClientReady(conn);
        Debug.Log("Client is set to the ready state (ready to receive state updates): " + conn);
    }
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        if (NetworkServer.connections.Count == 1)
        {
            var player = (GameObject)GameObject.Instantiate(seekerPrefab, new Vector3(278f, 394f, 496f), Quaternion.Euler(new Vector3(90f,0f,90f)));
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        else if(NetworkServer.connections.Count == 2)
        {
            var player = (GameObject)GameObject.Instantiate(playerPrefab, new Vector3(-70f, 0f, 156f), Quaternion.identity);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        else if (NetworkServer.connections.Count == 3)
        {
            var player = (GameObject)GameObject.Instantiate(playerPrefab, new Vector3(452f, 0f, 156f), Quaternion.identity);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        else if (NetworkServer.connections.Count == 4)
        {
            var player = (GameObject)GameObject.Instantiate(playerPrefab, new Vector3(452f, 0f, 798f), Quaternion.Euler(0f, 180f, 0f));
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        else if (NetworkServer.connections.Count == 5)
        {
            var player = (GameObject)GameObject.Instantiate(playerPrefab, new Vector3(0f, 0f, 798f), Quaternion.Euler(0f,180f,0f));
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        //var player = (GameObject)GameObject.Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        //NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        Debug.Log("Client has requested to get his player added to the game");
        Debug.Log("Connection number is: " + NetworkServer.connections.Count);
    }

    public override void OnServerRemovePlayer(NetworkConnection conn, PlayerController player)
    {
        if (player.gameObject != null)
            NetworkServer.Destroy(player.gameObject);
    }

    public override void OnServerError(NetworkConnection conn, int errorCode)
    {
        Debug.Log("Server network error occurred: " + (NetworkError)errorCode);
    }

    public override void OnStartHost()
    {
        Debug.Log("Host has started");
    }

    public override void OnStartServer()
    {
        Debug.Log("Server has started");
    }

    public override void OnStopServer()
    {
        Debug.Log("Server has stopped");
    }

    public override void OnStopHost()
    {
        Debug.Log("Host has stopped");
    }

    // Client callbacks
    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        Debug.Log("Connected successfully to server, now to set up other stuff for the client...");
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        StopClient();
        if (conn.lastError != NetworkError.Ok)
        {
            if (LogFilter.logError) { Debug.LogError("ClientDisconnected due to error: " + conn.lastError); }
        }
        Debug.Log("Client disconnected from server: " + conn);
    }

    public override void OnClientError(NetworkConnection conn, int errorCode)
    {
        Debug.Log("Client network error occurred: " + (NetworkError)errorCode);
    }

    public override void OnClientNotReady(NetworkConnection conn)
    {
        Debug.Log("Server has set client to be not-ready (stop getting state updates)");
    }

    public override void OnStartClient(NetworkClient client)
    {
        Debug.Log("Client has started");
    }

    public override void OnStopClient()
    {
        Debug.Log("Client has stopped");
    }

    public override void OnClientSceneChanged(NetworkConnection conn)
    {
        base.OnClientSceneChanged(conn);
        Debug.Log("Server triggered scene change and we've done the same, do any extra work here for the client...");
    }
}

//public override void OnServerReady(NetworkConnection conn)
//    {
//        NetworkServer.SetClientReady(conn);
//        Debug.Log("Client is set to the ready state (ready to receive state updates): " + conn);
//    }

//    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
//    {
//        if (NetworkServer.connections.Count == 1)
//        {
//            //Se ejecuta cuando Unity es gameClient
//            base.OnStartClient(client);
//            //base.OnStartServer(server);
//            Debug.Log("Instantiating  hider");
//            var player = (GameObject)GameObject.Instantiate(seeker, Vector3.zero, Quaternion.identity);
//            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
//            Debug.Log("Client has requested to get his player added to the game");
//        }
//        else if (NetworkServer.connections.Count > 1)
//        {
//            //Se ejecuta cuando Unity es gameHost
//            //Instantiate(hiderPrefab);
//            Debug.Log("Instantiate seeker");
//            //seeker.SetActive(true);
//            var player = (GameObject)GameObject.Instantiate(hiderPrefab, Vector3.zero, Quaternion.identity);
//            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
//            Debug.Log("Client has requested to get his player added to the game");
//        }
//    }