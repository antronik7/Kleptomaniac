using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private float moveSpeed = 0;
    private Animator myAnimator;
    private Rigidbody2D myRigidbody;

    public bool startRunning;

    // Use this for initialization
    void Start () {
        myAnimator = GetComponent<Animator>();

        myRigidbody = gameObject.transform.parent.GetComponent<Rigidbody2D>();

        if(startRunning)
        {
            StartRunning();
        }
    }
	
	// Update is called once per frame
	void Update () {
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
    }

    public void StartRunning()
    {
        moveSpeed = 5;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Stop")
        {
            moveSpeed = 0;

            Destroy(other.gameObject);

            BarDeTempsController.StartLooseTime();
        }
    }
}
