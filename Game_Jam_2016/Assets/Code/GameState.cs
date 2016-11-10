using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour
{

    public float addSpeed;
    public float addSpeedMax;
    public float speed;

    void Update()
    {
        if (speed < addSpeedMax)
        {
            speed += addSpeed * Time.deltaTime;
        }
    }
}
