using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject coinPrefab;
    [SerializeField] private float positveX;
    [SerializeField] private float negativeX;
    [SerializeField] private float positveZ;
    [SerializeField] private float negativeZ;
    public int instances;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < instances; i++)
        {
            Instantiate(coinPrefab, new Vector3(Random.Range(negativeX, positveX), coinPrefab.transform.localScale.y / 2, Random.Range(negativeZ, positveZ)), Quaternion.identity);
        }
    }
}
