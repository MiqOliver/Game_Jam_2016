using UnityEngine;
using System.Collections;

public class DestroyerMap : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "edge")
        {
            Destroy(other.transform.parent.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
       
    }
}
