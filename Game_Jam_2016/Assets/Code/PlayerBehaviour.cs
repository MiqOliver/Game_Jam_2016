using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    #region variables

    enum PlayerState { INIT, PLAYING, SPLITTED, DEAD };

    private Vector3 movement;
    private Vector3 initialPosition;
    private bool splitted;
    private PlayerState state;

    public float horizontalLerpTime;
    public float verticalLerpTime;
    public float lateralAcceleration;
    public float recoverPosSpeed;

    public Animator myAnimator;

    #endregion

    // Use this for initialization
    void Awake ()
    {
        state = PlayerState.PLAYING;
    }

	void Start () {
        movement = Vector3.zero;
        myAnimator = GetComponent<Animator>();
        initialPosition = new Vector3(0, 1, 0);
        if (state == PlayerState.SPLITTED)
        {

        }        
	}
	
	// Update is called once per frame
	void Update () {
        switch (state)
        {
            case PlayerState.INIT:
                break;
            case PlayerState.PLAYING:
                Movement();
                break;
            case PlayerState.SPLITTED:
                Movement();
                break;
            case PlayerState.DEAD:
                Destroy(this.gameObject);
                break;
            default:
                break;
        }
    }

    #region events

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Triangle")
        {
            switch (state)
            {
                case PlayerState.PLAYING:
                    Split(other.gameObject);
                    break;
                case PlayerState.SPLITTED:
                    state = PlayerState.DEAD;
                    break;
            }
        }

        else if (other.transform.tag == "Platform")
        {
            myAnimator.SetTrigger("Crash");
        }

        else if (other.transform.tag == "Player" && this.transform.name == "Player_0")
        {
            Join(other.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        StartCoroutine(UpdatePosY());
    }

    #endregion

    #region coroutines

    IEnumerator UpdatePosY()
    {
        if (this.transform.position.y >= initialPosition.y)
        {
            movement.y = -recoverPosSpeed;
        }
        else if (this.transform.position.y >= initialPosition.y)
        {
            movement.y = 0.001f;
        }

        this.transform.position = new Vector3(this.transform.position.x, Mathf.Lerp(this.transform.position.y, this.transform.position.y + movement.y, verticalLerpTime * Time.deltaTime), this.transform.position.z);
        yield return new WaitForEndOfFrame();
        movement.y = 0;
        StartCoroutine(UpdatePosY());

        yield return new WaitForSeconds(0);
    }

    #endregion

    #region functions

    //void UpdatePosY()
    //{
    //    if (this.transform.position.y != initialPosition.y)
    //    {
    //        Debug.Log("HI");
    //        this.transform.Translate(this.transform.position.x, Mathf.Lerp(this.transform.position.y, initialPosition.y, verticalLerpTime * Time.deltaTime), this.transform.position.z);
    //    }
    //}

    void Movement()
    {
        if(InputManager.MoveLeft())
            movement.x -= lateralAcceleration;
        else if(InputManager.MoveRight())
            movement.x += lateralAcceleration;
        else
            movement = Vector3.zero;

        this.transform.position = Vector3.Lerp(this.transform.position, this.transform.position + movement, horizontalLerpTime * Time.deltaTime);
    }

    void Join(GameObject other)
    {
        GameObject player;
        player = Instantiate(Resources.Load("Prefabs/Player"), (this.transform.position + other.transform.position) / 2, this.transform.rotation) as GameObject;
        player.name = "Player";
        player.GetComponent<PlayerBehaviour>().state = PlayerState.PLAYING;
        player.GetComponent<Rigidbody2D>().freezeRotation = true;
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        player.GetComponent<Transform>().localScale = new Vector3(0.4f, 0.4f, 1);

        Destroy(this.gameObject);
        Destroy(other.gameObject);
    }

    void Split(GameObject other)
    {
        other.transform.tag = "Circle";

        for(int i = 0; i < 2; i++)
        {
            GameObject player;
            player = Instantiate(Resources.Load("Prefabs/Player"), this.transform.position, this.transform.rotation) as GameObject;
            player.name = "Player_" + i;
            player.GetComponent<PlayerBehaviour>().state = PlayerState.SPLITTED;
            player.GetComponent<Rigidbody2D>().freezeRotation = true;
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            player.GetComponent<Transform>().localScale = this.transform.localScale / 2;
            player.transform.position = Vector3.Lerp(player.transform.position, player.transform.position + new Vector3(i, 0, 0), horizontalLerpTime * Time.deltaTime);
        }

        Destroy(this.gameObject);
    }

    #endregion
}
