using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{
    private float up, down;
    private bool upDown = true;

    // Start is called before the first frame update
    void Start()
    {
        up = transform.position.y + 0.35f;
        down = transform.position.y - 0.35f;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement();
        transform.Rotate(new Vector3(0f, 0f, 30f) * Time.deltaTime);
    }

    void Movement()
    {
        if (transform.position.y <= down)
        {
            upDown = false;
        }

        if (transform.position.y >= up)
        {
            upDown = true;
        }

        if (upDown)
            transform.Translate(Vector3.down * 0.25f * Time.deltaTime);
        if (!upDown)
            transform.Translate(Vector3.up * 0.25f * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player._Slow = true;
            }
            Destroy(this.gameObject);
        }
    }
}
