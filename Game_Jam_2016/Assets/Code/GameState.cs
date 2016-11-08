using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {


    private static int caseSwitch = 3;

    // Use this for initialization
    void Start () {
   
	}
	
	// Update is called once per frame
	void Update () {
        State();
	}

    void State()
    {
        switch (caseSwitch)
        {
            case 1: //menu
                break;
            case 2: //pause
                break;
            case 3: //game
               
                break;
        }
    }
}
