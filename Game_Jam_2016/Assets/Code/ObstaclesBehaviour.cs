using UnityEngine;
using System.Collections;

public class ObstaclesBehaviour : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float speed;

    private GameState scriptGameState;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        GameObject gameState = GameObject.Find("GameState");
        scriptGameState = gameState.GetComponent<GameState>();
        speed += scriptGameState.moreSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        
        rb2d.velocity = Vector3.up *speed;
    }
}
