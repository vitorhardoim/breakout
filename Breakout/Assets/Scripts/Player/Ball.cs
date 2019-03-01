using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float originalSpeed;
    public float constantSpeed;
    public float damage;
    private Rigidbody2D rigidbody;
    private bool sideBallBug;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.freezeRotation = true;
		Respawn ();
        originalSpeed = constantSpeed;
        damage = 1f;
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void FixedUpdate() {
        if (rigidbody.velocity.y < 1.5 && rigidbody.velocity.y > -1.5) rigidbody.gravityScale = 3;
        else rigidbody.gravityScale = 0;
    }

    //Determines the new direction for the ball object after a collision with the player's paddle.
    public float CollisionWithPlayer(Vector2 ballPosition, Vector2 playerPosition, float playerWidth) {
        return ((ballPosition.x - playerPosition.x) / playerWidth);
    }

    public void Respawn(){
		//transform.position = new Vector2(0,-1.5f);
		transform.position = new Vector2(GameObject.Find("Paddle").GetComponent<Paddle>().transform.position.x, -1.5f);
		Vector2 direction = new Vector2(0, -1).normalized;
        rigidbody.velocity = direction * constantSpeed;
	}

    private void LateUpdate()
    {
        rigidbody.velocity = constantSpeed * (rigidbody.velocity.normalized);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (rigidbody.velocity.x < 1f && rigidbody.velocity.y > -1f)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x + other.rigidbody.velocity.x/5, rigidbody.velocity.y);
        }
        if (other.gameObject.tag == "Brick")
        {
            GameObject.Find("PlayerManager").GetComponent<PlayerManager>().streak++;
        }
        if (other.gameObject.tag == "Paddle")
        {
            GameObject.Find("PlayerManager").GetComponent<PlayerManager>().streak = 0;
            if (sideBallBug)
            {
                if (rigidbody.position.x < 0)
                {
                    rigidbody.velocity = new Vector2(0.5f,-1).normalized * constantSpeed;
                    sideBallBug = false;
                }
                else
                {
                    rigidbody.velocity = new Vector2(-0.5f, -1).normalized * constantSpeed;
                    sideBallBug = false;
                }
            }

            //Ball direction/velocity after collision with player fix.
            float result = CollisionWithPlayer(transform.position, other.transform.position, ((BoxCollider2D)other.collider).size.x);
            Vector2 newDirection = new Vector2(result, 1).normalized;
            rigidbody.velocity = newDirection * constantSpeed;
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SideWall")
        {
            if (GameObject.Find("Paddle").GetComponent<Paddle>().IsOnCorner())
            {
                sideBallBug = true;
            }
            else
            {
                sideBallBug = false;
            }
        }
        else { sideBallBug = false; }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SideWall")
        {
            sideBallBug = false;
        }
    }
}
