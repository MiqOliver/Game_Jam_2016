using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {


    private static int caseSwitch = 3;
    public float moreSpeed;

    // Use this for initialization
    void Start () {
        MoreSpeed();
	}

    void MoreSpeed()
    {
        moreSpeed += 1f;
        Invoke("MoreSpeed", 3);
    }
}
