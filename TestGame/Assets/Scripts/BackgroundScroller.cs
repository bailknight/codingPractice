using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

//	public Rigidbody2D target;
	public float scrollSpeed;
	public Transform target;

//	private Vector2 savedOffset;
	private Renderer rdr;
	private float pos;
	private float offset;
	private float startposition;

	void Start()
	{
		rdr = GetComponent<Renderer> ();
		pos = 0;
		startposition = target.transform.position.x;
	}


	void Update()
	{
		offset = target.transform.position.x - startposition;

		pos += scrollSpeed * offset;
		if (pos > 1.0f)
			pos -= 1.0f;
		Vector2 newPos = new Vector2 (pos, 0);

		rdr.sharedMaterial.mainTextureOffset = newPos;
		//Debug.Log (offset);

		startposition = transform.position.x;
	}

//	void Update()
//	{
//		if (GameManager.instance.currentGameState == Gamestate.wait)
//			pos = pos;
//		else 
//		{
//			pos += scrollSpeed * target.velocity.x;
//			if (pos > 1.0f)
//				pos -= 1.0f;
//		}
//		Vector2 newPos = new Vector2 (pos, 0);
//
//		rdr.sharedMaterial.mainTextureOffset = newPos;
//	}


//	void Start()
//	{
//		rdr = GetComponent<Renderer> ();
//		savedOffset = rdr.sharedMaterial.GetTextureOffset ("_MainTex");
//		 
//	}

//	void Update () 
//	{
//		float newScrollSpeed = target.velocity.x * scrollSpeed;
//		float x = Mathf.Repeat (Time.time * newScrollSpeed , 1);
//		Vector2 offset = new Vector2 (x, savedOffset.y);
//		rdr.sharedMaterial.SetTextureOffset ("_MainTex", offset);
//		Debug.Log (target.velocity.x);
//	}
}
