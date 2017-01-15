using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;

    public float jumpForce = 6f;
    public float runningSpeed = 1.5f;
    public Animator animator;

    private Vector3 startingPostion;
    private Rigidbody2D rigidbody;

    void Awake()
    {
        instance = this;
        rigidbody = GetComponent<Rigidbody2D>();
        startingPostion = this.transform.position;
    }

   public void StartGame()
    {
        animator.SetBool("isAlive", true);
        this.transform.position = startingPostion;
    }

    void FixedUpdate()
    {
        if (GameManager.instance.currentGameState == Gamestate.inGame)
        {
            if (rigidbody.velocity.x < runningSpeed)
            {
                rigidbody.velocity = new Vector2(runningSpeed, rigidbody.velocity.y);
            }
            else if (rigidbody.velocity.x >= runningSpeed)
            {
                rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
            }
        }
    }

    void Update () {
        if (GameManager.instance.currentGameState == Gamestate.inGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Jump();
            }
            animator.SetBool("isGrounded", IsGrounded());
        }
	}
	
	void Jump () {
        if (IsGrounded()) {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }      
	}
    public LayerMask groundLayer;
    
    bool IsGrounded()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.2f, groundLayer.value))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Kill()
    {
        GameManager.instance.GameOver();
        animator.SetBool("isAlive", false);

        if (PlayerPrefs.GetFloat("highscore", 0) < this.GetDistance())
        {
            PlayerPrefs.SetFloat("highscore", this.GetDistance());
        }
    }
    public float GetDistance()
    {
        float traveledDistance = Vector2.Distance(new Vector2(startingPostion.x, 0), new Vector2(this.transform.position.x, 0));
        return traveledDistance;
    }
}
