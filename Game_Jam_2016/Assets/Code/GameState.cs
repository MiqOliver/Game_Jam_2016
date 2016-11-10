using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour
{

    public float addSpeed;
    public float maxSpeed;
    public float speed;

    void Update()
    {
        if (speed <= maxSpeed)
        {
            speed += addSpeed * Time.deltaTime;
        }
        else if(speed > maxSpeed)
            speed = maxSpeed;
    }
}
