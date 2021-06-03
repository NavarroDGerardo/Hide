using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CMove : NetworkBehaviour
{
    public float _speed = 5f;

    void Start()
    {
        
    }
    void Update()
    {
        if (isLocalPlayer)
        {
            if (transform.position.x <= 464.9368f && transform.position.x >= 5.941192f)
            {
                float moveTopBotton = Input.GetAxisRaw("Vertical") * _speed;
                transform.Translate(Vector3.up * moveTopBotton * _speed * Time.deltaTime);
            }

            if (transform.position.z <= 653.9041f && transform.position.z >= 326.4768f)
            {
                float moveLeftRight = Input.GetAxisRaw("Horizontal") * _speed;
                transform.Translate(Vector3.right * moveLeftRight * _speed * Time.deltaTime);
            }

            if (transform.position.x >= 464.9368f)
            {
                transform.position = new Vector3(464.8f, transform.position.y, transform.position.z);
            }
            if (transform.position.x <= 5.941192f)
            {
                transform.position = new Vector3(6, transform.position.y, transform.position.z);
            }
            if (transform.position.z >= 653.9041f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 653.8f);
            }
            if (transform.position.z <= 326.4768f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 326.5f);
            }
        }
    }
}
