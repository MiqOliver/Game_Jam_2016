using UnityEngine;
using System.Collections;

public class DestroyerMap : MonoBehaviour {

    private GameState score;

    void Start()
    {
        GameObject gameStateObject = GameObject.FindWithTag("GameState");
        if(gameStateObject != null)
        {
            score = gameStateObject.GetComponent<GameState>();
        }
        
    }
	void OnTriggerEnter2D(Collider2D other)
    {
        score.AddScore();

        if (other.tag == "edge")
        {
            Destroy(other.transform.parent.gameObject);
        }

        else
        {
            Destroy(other.gameObject);
        }
    }
}
