using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Hider : NetworkBehaviour
{
    [SerializeField] public GameObject player;
    private Player pScript;

    public Camera cameraReference;

    void Start()
    {
        pScript = player.GetComponent<Player>();
        pScript.anim = player.GetComponent<Animator>();
        pScript.lp = isLocalPlayer;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            cameraReference.enabled = false;
        }
        else
        {
            cameraReference.enabled = true;
        }

        if (!isLocalPlayer)
        {
            return;
        }
        pScript.movement();
    }
}
