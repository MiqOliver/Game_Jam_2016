using UnityEngine;
using System.Collections;

public class CamaraControl : MonoBehaviour {

    public GameObject player;       //Public variable to store a reference to the player game object

    private float offsetZ;         //Private variable to store the offset distance between the player and camera
    private float offsetY;

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offsetZ = transform.position.z - player.transform.position.z;
        offsetY = transform.position.y - player.transform.position.y;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = new Vector3(0, player.transform.position.y + offsetY , offsetZ);
    }
}

