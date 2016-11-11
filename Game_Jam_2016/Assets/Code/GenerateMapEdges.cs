using UnityEngine;
using System.Collections;

public class GenerateMapEdges : MonoBehaviour {

    public GameObject player;

    //edges
    public GameObject obj;
    private float distSpawn;
    private float lastPositionSpawnEdges;

    void Awake()
    {
        distSpawn = (player.transform.position.y - transform.position.y); //fixed distance, not random
        lastPositionSpawnEdges = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        GenerateEdges();

    }

    void GenerateEdges()
    {
        if ((lastPositionSpawnEdges - transform.position.y) > distSpawn)
        {
            Instantiate(obj, transform.position, Quaternion.identity);
            lastPositionSpawnEdges = transform.position.y;

        }

    }
}
