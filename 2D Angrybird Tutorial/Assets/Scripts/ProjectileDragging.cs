using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDragging : MonoBehaviour {

	public float maxStretch = 3.0f;
	public LineRenderer catapultLineFront;
	public LineRenderer catapultLineBack;

	public Transform catapult;
	private SpringJoint2D spring;
	private Rigidbody2D rb;
	private bool clickedOn;
	private Ray rayToMouse;
	private Ray leftCatapultToProjectile;
	private float maxStretchSqr;
	private Vector2 prevVelocity;
	private float circleRadius;

	void Awake()
	{
		spring = GetComponent<SpringJoint2D> ();
		rb = GetComponent <Rigidbody2D> ();
	}

	void Start () 
	{
		LineRendererSetup ();
		rayToMouse = new Ray (catapult.position, Vector3.zero);
		leftCatapultToProjectile = new Ray (catapultLineFront.transform.position, Vector3.zero);
		maxStretchSqr = maxStretch * maxStretch;
		CircleCollider2D circle = GetComponent <CircleCollider2D> ();
		circleRadius = circle.radius;
	}
	
	void Update () 
	{
		if (clickedOn)
			Dragging ();

		if (spring != null) 
		{
			if(!rb.isKinematic && prevVelocity.sqrMagnitude > rb.velocity.sqrMagnitude)
			{
				Destroy (spring);
				rb.velocity = prevVelocity;
			}
			if (!clickedOn)
				prevVelocity = rb.velocity;
			
			LineRendererUpdate ();
		}
		else
		{
			catapultLineFront.enabled = false;
			catapultLineBack.enabled = false;
		}
	}

	void LineRendererSetup ()
	{
		catapultLineFront.SetPosition (0,catapultLineFront.transform.position);
		catapultLineBack.SetPosition (0,catapultLineBack.transform.position);

		catapultLineFront.sortingLayerName = "Foreground";
		catapultLineBack.sortingLayerName = "Foreground";

		catapultLineFront.sortingOrder = 3;
		catapultLineBack.sortingOrder = 1;
	}

	void OnMouseDown()
	{
		spring.enabled=false;
		clickedOn = true;
	}

	void OnMouseUp()
	{
		spring.enabled=true;
		rb.isKinematic = false;
		rb.angularDrag = 5f;
		rb.drag = 0.01f;
		clickedOn = false;
	}

	void Dragging ()
	{
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 catapultToMouse = mouseWorldPoint - catapult.position;

		if(catapultToMouse.sqrMagnitude > maxStretchSqr )
		{
			rayToMouse.direction = catapultToMouse;
			mouseWorldPoint = rayToMouse.GetPoint (maxStretch);
		}

		mouseWorldPoint.z = 0f;
		transform.position = mouseWorldPoint;
	}

	void LineRendererUpdate()
	{
		Vector2 catapultToProjectile = transform.position - catapultLineFront.transform.position;
		leftCatapultToProjectile.direction = catapultToProjectile;
		Vector3 holdPoint = leftCatapultToProjectile.GetPoint (catapultToProjectile.magnitude + circleRadius);
		catapultLineFront.SetPosition (1, holdPoint);
		catapultLineBack.SetPosition (1, holdPoint);
	}
}
