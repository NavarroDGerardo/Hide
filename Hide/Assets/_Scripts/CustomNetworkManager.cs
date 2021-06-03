using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager{

    //public GameObject hiderPrefab;

    NetworkClient myClient;
    //public void OnConnected(NetworkConnection conn, NetworkReader reader){
    //    Debug.Log("Connected to server");
    //}

    public override void OnStartClient(NetworkClient client){

        //base.OnStartClient(client);
        //Debug.Log(client.GetType());

        /*
        if(NetworkServer.connections.Count == 1){
            base.OnStartClient(client);
            //base.OnStartServer(server);
            Debug.Log("Instantiating  seeker");
        }else if(NetworkServer.connections.Count == 2){
            Instantiate(hiderPrefab);
            Debug.Log("Instantite hider");
        }
        */

        /*
        if(NetworkServer.connections.Count == 1){
            Instantiate(hiderPrefab);
        }
        */

        
        /*
        if(isServer){
            Debug.Log("Instantiating  server");

        }else if (isClient){
            Instantiate(hiderPrefab);
            Debug.Log("Instantite client");
        }
        */
        

        //Instantiate(hiderPrefab);
        //Debug.Log("Instantiate client");

        

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
