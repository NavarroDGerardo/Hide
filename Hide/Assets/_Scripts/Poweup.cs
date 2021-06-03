using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poweup : MonoBehaviour
{
    Vector3 maxSize;
    Vector3 minSize;
    Vector3 newSize;
    bool grow = true;

    // Start is called before the first frame update
    void Start()
    {
        newSize = transform.localScale;
        maxSize = transform.localScale * 1.25f;
        minSize = transform.localScale * 0.75f;
        StartCoroutine(changeSizeCourutine());
    }

    // Update is called once per 

    IEnumerator changeSizeCourutine()
    {
        if (grow)
        {
            newSize += new Vector3(1, 1, 1) * 0.15f;
        }
        else
        {
            newSize -= new Vector3(1, 1, 1) * 0.15f;
        }

        if (transform.localScale.x > maxSize.x && transform.localScale.y > maxSize.y && transform.localScale.z > maxSize.z)
            grow = false;

        if (transform.localScale.x < minSize.x && transform.localScale.y < minSize.y && transform.localScale.z < minSize.z)
            grow = true;
        yield return new WaitForSecondsRealtime(0.07f);
        transform.localScale = Vector3.Lerp(transform.localScale, newSize, 0.5f);
        startAgain();
    }

    void startAgain()
    {
        StartCoroutine(changeSizeCourutine());
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player._Sprint = true;

            }
            Destroy(this.gameObject);
        }
    }
}
