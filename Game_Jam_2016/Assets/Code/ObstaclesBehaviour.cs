using UnityEngine;
using System.Collections;

public class ObstaclesBehaviour : MonoBehaviour {

    private Rigidbody2D rb2d;
    private PlayerBehaviour ply;

    private GameState scriptGameState;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();

        GameObject gameState = GameObject.Find("GameState");
        scriptGameState = gameState.GetComponent<GameState>();

        GameObject player = GameObject.FindWithTag("Player");
        ply = player.GetComponent<PlayerBehaviour>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!ply.onTitle && ply.state == PlayerBehaviour.PlayerState.INIT)
        {
            rb2d.velocity = Vector3.up;
        }

        else if (!ply.onTitle)
        {
            rb2d.velocity = Vector3.up * scriptGameState.speed;
        }
        else
            rb2d.velocity = Vector3.zero;
    }
}
