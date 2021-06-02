using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMove : MonoBehaviour
{
    public float _speed = 5f;

    void Start()
    {
        
    }
    void Update()
    {
        if(transform.position.z <= 653.9041f && transform.position.z >= 326.4768)
        {
            float moveTopBotton = Input.GetAxisRaw("Vertical") * _speed;
            transform.Translate(Vector3.up * moveTopBotton * _speed * Time.deltaTime);
        }

        if (transform.position.x <= 464.9368f && transform.position.x >= 5.941192f)
        {
            float moveLeftRight = Input.GetAxisRaw("Horizontal") * _speed;
            transform.Translate(Vector3.right * moveLeftRight * _speed * Time.deltaTime);
        }
    }
}
