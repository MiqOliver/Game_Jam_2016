using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    private DetectTouches scriptDetectTouches;
    private Rigidbody2D rb2d;
    public int speedX = 1;

	// Use this for initialization
	void Awake () {

        scriptDetectTouches = GetComponent<DetectTouches>();
	}

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        scriptDetectTouches.GetTouchesGameState();
        movementPlayer(scriptDetectTouches.right, scriptDetectTouches.left);
    }

    public void movementPlayer(bool right, bool left)
    {

        if (right) //touch right screen true
        {
            rb2d.velocity = new Vector2(speedX,rb2d.velocity.y);
        }
        else if (left) //touch left screen true
        {
            rb2d.velocity = new Vector2(-speedX, rb2d.velocity.y);
        }
        else //no touch screen
        {

        }
    }
}
