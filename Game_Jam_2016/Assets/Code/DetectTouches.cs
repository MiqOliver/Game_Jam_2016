using UnityEngine;
using System.Collections;

public class DetectTouches : MonoBehaviour {

    public bool right;
    public bool left;

    public void GetTouchesGameState()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); //one finger at a time
          
            if (touch.position.x < Screen.width / 2)
            {
                left = true;
                right = false;
            }
            else if (touch.position.x > Screen.width / 2)
            {
                left = false;
                right = true;
            }
        }
    }
}

//touch.phase == TouchPhase.Began  
