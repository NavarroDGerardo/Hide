using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject coinPrefab;
    [SerializeField] private float Range;
    public int instances;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < instances; i++)
        {
            Instantiate(coinPrefab, new Vector3(Random.Range(-Range, Range), 1, Random.Range(-Range, Range)), Quaternion.identity);
        }
    }
}
