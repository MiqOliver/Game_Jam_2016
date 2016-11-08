using UnityEngine;
using System.Collections;

public class GenerateMapObstacles : MonoBehaviour {

    public GameObject player;

    //objects
    public GameObject[] objs;
    private float lastPositionSpawnObstacles;
    private int distanceYBetween;
    public int distanceYBetweenMin = 5;
    public int distanceYBetweenMax = 10;
 
	void Awake()
    {
        lastPositionSpawnObstacles = transform.position.y;
        distanceYBetween = Random.Range(distanceYBetweenMin, distanceYBetweenMax);
    }
    
	// Update is called once per frame
	void Update () {
        GenerateObstacles();
    }

    void GenerateObstacles()
    {
        if ((lastPositionSpawnObstacles - transform.position.y) > distanceYBetween)
        {
            Instantiate(objs[Random.Range(0, objs.Length)], transform.position, Quaternion.identity);
            lastPositionSpawnObstacles = transform.position.y;
            distanceYBetween = Random.Range(distanceYBetweenMin, distanceYBetweenMax);
        }
    }
}
