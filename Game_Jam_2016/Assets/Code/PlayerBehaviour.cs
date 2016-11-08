using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    private Vector3 movement;

    public float lerpTime;
    public float lateralAcceleration;

	// Use this for initialization
    void Awake ()
    {

    }

	void Start () {
        movement = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    #region functions

    void Movement()
    {
        if(InputManager.MoveLeft())
            movement.x -= lateralAcceleration;
        else if(InputManager.MoveRight())
            movement.x += lateralAcceleration;
        else
            movement = Vector3.zero;

        this.transform.position = Vector3.Lerp(this.transform.position, this.transform.position + movement, lerpTime);
    }

    #endregion
}
