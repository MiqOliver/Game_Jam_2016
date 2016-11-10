using UnityEngine;
using System.Collections;

public class GenerateMapObstacles : MonoBehaviour {

    public GameObject player;

    //objects
    public GameObject[] objs;

    private float distanceXBetween;
    public float distanceXBetweenMin;
    public float distanceXBetweenMax;

    public float minTime;
    public float maxTime;

    void Awake()
    {
        distanceXBetween = Random.Range(distanceXBetweenMin, distanceXBetweenMax);
    }

    void Start()
    {
        GenerateObstacles();
    }

    void GenerateObstacles()
    {

        Instantiate(objs[Random.Range(0, objs.Length)], transform.position + new Vector3(distanceXBetween,0,0), Quaternion.identity);

        distanceXBetween = Random.Range(distanceXBetweenMin, distanceXBetweenMax);
        Invoke("GenerateObstacles", Random.Range(minTime, maxTime));
    }
}
