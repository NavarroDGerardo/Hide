using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickablePlayer : MonoBehaviour
{
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        GameMasterScript.instance.succesfulClick();
        if (player != null)
        {
            player.DieAnimation(true);

        }
        //Destroy(gameObject);
    }
}
