using UnityEngine;
using System.Collections;

public static class InputManager {

    //private static Touch touch = Input.GetTouch(0);

    public static bool MoveRight()
    {
        return Input.touchCount > 0 && Input.GetTouch(0).position.x > Screen.width / 2;
    }

    public static bool MoveLeft()
    {
        return Input.touchCount > 0 && Input.GetTouch(0).position.x < Screen.width / 2;
    }
}
