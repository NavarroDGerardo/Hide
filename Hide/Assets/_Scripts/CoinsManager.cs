using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public GameObject coinPrefab;
    public int instances;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < instances; i++)
        {
            Instantiate(coinPrefab, new Vector3(Random.Range(-20, 20), 1, Random.Range(-20, 20)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
