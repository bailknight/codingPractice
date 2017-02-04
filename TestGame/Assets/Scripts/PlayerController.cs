using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;

    public float jumpForce = 6f;
    public float runningSpeed = 1.5f;
    public Animator animator;
	public LayerMask groundLayer;
	public float m_MaxJumpForce; 
	public float m_MaxChargeTime;
	public AudioSource sfxSource;
	public AudioClip jumpClip;
	public AudioClip hitClip;
	public AudioClip chargeClip;

    private Vector3 startingPostion;
    private Rigidbody2D rb;
	private float lastTaptime = 0.0f;
	private float m_CurrentLaunchForce;  
	private float m_ChargeSpeed; 

	private Canvas m_CanvasGameObject;
	private Slider m_AimSlider;

	private CapsuleCollider2D capsuleCol;
	private BoxCollider2D floorCol;
	[HideInInspector]public bool isAlive;
	private float score;
	private float travelDistance;
	bool onSpring;
	int collectiblePoint;
	Collider2D[] allColliders;


//	bool jumpable; 	// 롱점프용 변수

    void Awake()
    {
        instance = this;
		rb = GetComponent<Rigidbody2D>();
        startingPostion = this.transform.position;
		gameObject.SetActive(false);
		m_CanvasGameObject = GetComponentInChildren<Canvas>();
		m_AimSlider = GetComponentInChildren<Slider> ();
		capsuleCol = GetComponent<CapsuleCollider2D>();
		floorCol = GetComponentInChildren<BoxCollider2D>();
		allColliders = GetComponents<Collider2D> ();
    }

   public void StartGame()
    {
		gameObject.SetActive(false);
		gameObject.SetActive(true);
        animator.SetBool("isAlive", true);
		rb.velocity = new Vector2 (0f, 0f);
        this.transform.position = startingPostion;
//		jumpable= false;
		m_ChargeSpeed = m_MaxJumpForce / m_MaxChargeTime;
		m_CanvasGameObject.enabled = false;
		capsuleCol.isTrigger = false;
		isAlive = false;
		onSpring = false;
		collectiblePoint = 0;
		travelDistance = 0f;
		score = 0f;
    }

    void FixedUpdate()
    {
		if (GameManager.instance.currentGameState == Gamestate.inGame && !isAlive) 
		{
			return;
		}

		if (GameManager.instance.currentGameState == Gamestate.inGame && isAlive)
        {
			//if (rb.velocity.x < runningSpeed)
           // {
			rb.velocity = new Vector2(runningSpeed, rb.velocity.y);
          //  }
			//  else if (rb.velocity.x >= runningSpeed)
          //  {
			//       rb.velocity = new Vector2(0f, rb.velocity.y);
          //  }
			IsGrounded ();
        }
    }

	//차지형 롱점프
	void Update ()
	{
		m_AimSlider.value = 0f;
		if (GameManager.instance.currentGameState == Gamestate.inGame && !isAlive) 
		{
			return;
		}

		if (GameManager.instance.currentGameState == Gamestate.inGame && isAlive) 
		{
			if (Input.GetButtonDown ("Fire1")) 
			{
				m_CurrentLaunchForce = 0f;
				lastTaptime = Time.time;
				sfxSource.clip = chargeClip;
				sfxSource.Play ();
			}
			if (Input.GetButton ("Fire1")) 
			{
				m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;
				m_AimSlider.value = m_CurrentLaunchForce;
				if (m_CurrentLaunchForce >= 0.5f) 
				{
					m_CanvasGameObject.enabled = true;
				}
				if (m_CurrentLaunchForce >= m_MaxJumpForce) 
				{
					m_CurrentLaunchForce = m_MaxJumpForce;
				}
			}
			if (Input.GetButtonUp ("Fire1")) 
			{
				m_CanvasGameObject.enabled = false;
				if (Time.time - lastTaptime > m_MaxChargeTime) 
				{
					Jump (m_MaxJumpForce);
				} 
				else 
				{
					Jump (0.7f);
				}
			}
			animator.SetBool ("isGrounded", IsGrounded());
		}
	}


	void Jump (float multiplier)
	{
		if (IsGrounded()||onSpring) 
		{
			rb.velocity = new Vector2 (runningSpeed, 0f);
			rb.AddForce(Vector2.up * jumpForce*multiplier, ForceMode2D.Impulse);
			m_CurrentLaunchForce = 0f;
			sfxSource.clip = jumpClip;
			sfxSource.Play ();
		}      
	}

    bool IsGrounded()  //플레이어가 떨어지기 시작하거나// 플로어콜라이더가 바닥에 닿으면 다시 콜라이더 켜기
	{
		if (/*rb.velocity.y <= Mathf.Epsilon ||*/ floorCol.IsTouchingLayers (groundLayer.value)) 
		{
			capsuleCol.isTrigger = false;
			return true;
		} 
		else 
		{
			capsuleCol.isTrigger = true;
			return false;
		}
	}
 
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "EnemyKillTrigger")
		{
			onSpring = true;
			MonsterController monster = other.GetComponentInParent<MonsterController> ();
			Jump (m_MaxJumpForce*1.2f);
			monster.Hurt ();
			onSpring = false;
			Debug.Log("Stomp!");
		}
	}

	public void Attacked()
	{
		Debug.Log("Attacked!");
		isAlive = false;
		animator.SetBool("isAlive", false);
		rb.velocity = new Vector2(-2f, 0f);
		rb.AddForce(Vector2.up*15f, ForceMode2D.Impulse);
		//Collider2D[] allColliders = GetComponents<Collider2D> ();
		foreach (Collider2D item in allColliders)
		{
			item.enabled = false;
		}
		SoundManager.instance.MuteBGM ();
		sfxSource.clip = hitClip;
		sfxSource.Play ();
		Invoke ("Kill", 1);
	}
    
	public void Kill()
    {
		//Collider2D[] allColliders = GetComponents<Collider2D> ();
		foreach (Collider2D item in allColliders)
		{
			item.enabled = true;
		}
		rb.velocity = new Vector2(0f, 0f);
        GameManager.instance.GameOver();
        animator.SetBool("isAlive", false);
		gameObject.SetActive (false);
		SoundManager.instance.PlayDeathClip ();

		if (PlayerPrefs.GetFloat ("highscore", 0) < this.GetDistance ()) 
		{
			PlayerPrefs.SetFloat ("highscore", this.GetDistance ());
		}
    }


	public float GetDistance()
	{
		if (isAlive && GameManager.instance.currentGameState == Gamestate.inGame) 
		{
			travelDistance += 0.1f;
			score = travelDistance + collectiblePoint;
			return score;
		} 
		else 
		{
			return score;
		}
			//float traveledDistance = Vector2.Distance (new Vector2 (startingPostion.x, 0), new Vector2 (transform.position.x, 0)) + collectiblePoint;
			//return traveledDistance;
	}

	public void CollectiblePoint(int point)
	{
		collectiblePoint += point;
	}

//    bool IsGrounded()
//    {
//		if (/*Physics2D.Raycast(capsuleCol.transform.position, Vector2.down, 0.2f, groundLayer.value)||*/ floorCol.IsTouchingLayers (groundLayer.value))
//		{
//			return true;
//		}
//        else
//        {
//			return false;
//        }
//    }

	//차지형 롱점프
//	void Update ()
//	{
//		m_AimSlider.value = 0f;
//		if (GameManager.instance.currentGameState == Gamestate.inGame && !isAlive) 
//		{
//			return;
//		}
//
//		if (GameManager.instance.currentGameState == Gamestate.inGame && isAlive) 
//		{
//			if (Input.GetButtonDown ("Fire1")) 
//			{
//				m_CurrentLaunchForce = 0f;
//				lastTaptime = Time.time;
//			}
//			if (Input.GetButton ("Fire1")) 
//			{
//				m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;
//				m_AimSlider.value = m_CurrentLaunchForce;
//				if (m_CurrentLaunchForce >= 0.5f)
//					m_CanvasGameObject.enabled = true;
//				if (m_CurrentLaunchForce >= m_MaxJumpForce) 
//				{
//					m_CurrentLaunchForce = m_MaxJumpForce;
//				}
//			}
//			if (Input.GetButtonUp ("Fire1")) 
//			{
//				m_CanvasGameObject.enabled = false;
//				if (Time.time - lastTaptime > m_MaxChargeTime) 
//				{
//					Jump (m_MaxJumpForce);
//				} 
//				else 
//				{
//					Jump (0.7f);
//				}
//			}
//			animator.SetBool ("isGrounded", IsGrounded());
//		}
//	}

	// 롱터치 롱점프
	//	void Update () 
	//	{
	//		if (GameManager.instance.currentGameState == Gamestate.inGame)
	//		{
	//			if (Input.GetButtonDown ("Fire1") && IsGrounded()) 
	//			{
	//				lastTaptime = Time.time;
	//				jumpable = true;
	//			}
	//			if (Input.GetButton("Fire1")&&jumpable) 
	//			{
	//				if (Time.time - lastTaptime > 0.3f) 
	//				{
	//				}
	//				else 
	//				{
	//					Jump (0.5f);
	//				}
	//			}
	//			if (Input.GetButtonUp ("Fire1")) 
	//			{
	//				jumpable = false;
	//			}
	//			animator.SetBool ("isGrounded", IsGrounded ());
	//		}
	//	}

	//	
	//	void Jump (float multiplier) 
	//	{
	//			rb.velocity = new Vector2 (runningSpeed, 0f);
	//			rb.AddForce(Vector2.up * jumpForce*multiplier, ForceMode2D.Impulse);   
	//	}
}

