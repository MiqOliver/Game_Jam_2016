using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

    public float addSpeed;

    // Use this for initialization
    void Start () {
        AddSpeed();
	}

    void AddSpeed()
    {
        addSpeed += 1f;
        Invoke("AddSpeed", 3);
    }
}
