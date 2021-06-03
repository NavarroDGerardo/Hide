using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager{

    public GameObject seeker;
    public GameObject hiderPrefab;

    NetworkClient myClient;
    public void OnConnected(NetworkConnection conn, NetworkReader reader)
    {
        Debug.Log("Connected to server");
    }

    //public override void OnStartClient(NetworkClient client){

    //    //base.OnStartClient(client);
    //    //Debug.Log(client.GetType());

    //    //Debug.Log("Connection count: " + NetworkServer.connections.Count);


    //    /*
    //    if(NetworkServer.connections.Count == 1){
    //        Instantiate(hiderPrefab);
    //    }
    //    */


    //    /*
    //    if(isServer){
    //        Debug.Log("Instantiating  server");

    //    }else if (isClient){
    //        Instantiate(hiderPrefab);
    //        Debug.Log("Instantite client");
    //    }
    //    */


    //    //Instantiate(hiderPrefab);
    //    //Debug.Log("Instantiate client");



    //}

    public override void OnServerReady(NetworkConnection conn)
    {
        NetworkServer.SetClientReady(conn);
        Debug.Log("Client is set to the ready state (ready to receive state updates): " + conn);
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        if (NetworkServer.connections.Count == 1)
        {
            //Se ejecuta cuando Unity es gameClient
            base.OnStartClient(client);
            //base.OnStartServer(server);
            Debug.Log("Instantiating  hider");
            var player = (GameObject)GameObject.Instantiate(seeker, Vector3.zero, Quaternion.identity);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
            Debug.Log("Client has requested to get his player added to the game");
        }
        else if (NetworkServer.connections.Count > 1)
        {
            //Se ejecuta cuando Unity es gameHost
            //Instantiate(hiderPrefab);
            Debug.Log("Instantiate seeker");
            //seeker.SetActive(true);
            var player = (GameObject)GameObject.Instantiate(hiderPrefab, Vector3.zero, Quaternion.identity);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
            Debug.Log("Client has requested to get his player added to the game");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    

        //myClient.RegisterHandler(MsgType.SYSTEM_CONNECT, OnConnected);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
