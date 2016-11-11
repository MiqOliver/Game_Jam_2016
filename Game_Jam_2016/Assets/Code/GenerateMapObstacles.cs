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

    private int count;
    private float extraTime;

    void Awake()
    {
        distanceXBetween = Random.Range(distanceXBetweenMin, distanceXBetweenMax);
    }

    void Start()
    {
        extraTime = 0;
        GenerateObstacles();
    } 

    IEnumerator ShootAnother(float s)
    {
        yield return new WaitForSeconds(s);
        GenerateObstacle();
    }

    void GenerateObstacles()
    {
        int obj = Random.Range(0, objs.Length);
        if (count >= 3)
        {
            Debug.Log("1");
            if (Random.Range(0, 2) == 1)
            {
                Instantiate(objs[1], transform.position + new Vector3(1.5f, 0, 0), Quaternion.identity);
                count = 0;
            }
            else
            {
                Instantiate(objs[1], transform.position + new Vector3(-1.5f, 0, 0), Quaternion.identity);
                count = 0;
            }
        }
        else
        {
            Instantiate(objs[obj], transform.position + new Vector3(distanceXBetween, 0, 0), Quaternion.identity);
            distanceXBetween = Random.Range(distanceXBetweenMin, distanceXBetweenMax);
            count++;


        }
        if (obj != 1)
        {
            StartCoroutine(ShootAnother(1f));
            extraTime = 1;
            count++;
        }
        Invoke("GenerateObstacles", Random.Range(minTime, maxTime) + extraTime);
        extraTime = 0;
    }

    void GenerateObstacle()
    {
        Instantiate(objs[Random.Range(0, objs.Length)], transform.position + new Vector3(distanceXBetween, 0, 0), Quaternion.identity);
        count++;
    }
}
