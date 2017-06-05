using UnityEngine;
using System.Collections;
using System.IO;

public class PlayerScript : MonoBehaviour 
{
	public static PlayerScript instance;

	public NewSnakePart snakObj;
	
	public SnakePart snakePart;

	private bool isMoving, isTouchTimeComplete;

	internal bool isTouchOff;


	private int touchOffCounter, stagnantCounter ;

	private float distanceBetweenTwoPart = .75f;

	Vector3 previousTouch, currentTouch,moveToward,moveDirection , currentPosition;

	bool isGameOver;
	void Awake()
	{
		instance = this;
		isTouchTimeComplete = true;
	}

	void Start () {
		previousTouch = Vector3.zero;
		currentTouch = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		DetectTouch();
		MoveSnake();
	}

	void DetectTouch()
	{

		if(Input.GetMouseButtonDown(0))
		{
			Vector3 mousePosition = Input.mousePosition;
			Vector3 cameraPosition = Camera.main.ScreenToWorldPoint(mousePosition);
			Collider2D[] others = Physics2D.OverlapCircleAll(cameraPosition, 1);
			foreach(Collider2D collider in others)
			{
				if(collider.transform.CompareTag("Head"))
				{
					if(!GameManager.instance.isGameRunning)
						GameManager.instance.StartGame() ;
					previousTouch = cameraPosition;
					previousTouch.z = transform.position.z;
					isMoving  = true;
					isTouchOff = false;
					break;
				}
			}
		}
		else if(Input.GetMouseButtonUp(0) && isMoving)
		{
			isMoving = false;

			if(!isTouchOff)
			{
				isTouchOff = true;
			}
		}
	}

	void MoveSnake()
	{
		if(isMoving)
		{
		    currentTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			currentTouch.z = transform.position.z;

			if(Vector2.Distance (previousTouch, currentTouch) > distanceBetweenTwoPart)
			{
				Move();
				stagnantCounter = 0;
				previousTouch = currentTouch;
			}
			else
			{
				stagnantCounter++;
				if(stagnantCounter > 160)
				{
					SetGameOver(false);
				}
			}
		}
	}

	void Move()
	{
		Vector3 nextPartPosition = transform.position;
		Quaternion nextPartRotation = transform.localRotation;
	
	
		currentPosition = transform.position;
		currentTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    	
		// HANDLES ROTATION
	
		moveDirection = Utility.GetDirection(currentTouch, currentPosition);

		currentPosition += moveDirection * distanceBetweenTwoPart;

		transform.position =  Vector2.Lerp(transform.position, currentPosition, Time.deltaTime * Constants.SPEED);

		// if we have moved and need to rotate
		if (moveDirection != Vector3.zero)
		{
			// calculates the angle we should turn towards, - 90 makes the sprite rotate
			float targetAngle = Utility.GetAngle(moveDirection);// Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
			// actually rotates the sprite using Slerp (from its previous rotation, to the new one at the designated speed.
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, targetAngle), 30f * Time.deltaTime);
			
		}

		snakePart.MoveSnakePart(nextPartPosition, nextPartRotation);

		if(Vector2.Distance (transform.position, currentTouch) > distanceBetweenTwoPart
		   )
		{
			Move();
		}
	}



	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.CompareTag("SnakFood"))
		{
			other.gameObject.SetActive(false);
			
			GameManager.instance.GenerateRandomSnakFoods();

				LinkSnakeObject();

			GameManager.instance.Fruit +=  1;
			GameManager.instance.ManageScore(1);

		}
		else if (other.transform.CompareTag("OverPoint"))
			SetGameOver(true);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.CompareTag("OverPoint"))
		{
			if(other.transform.name[0] == 'H')
			{

					SetGameOver(true);
					
			}
		}
	}

	public void SetGameOver(bool IsCollideWithHurdle)
	{
		if(!isGameOver)
		{
			GetComponent<CircleCollider2D>().enabled = false;
			isGameOver = true;
			if(IsCollideWithHurdle){
				GameManager.instance.showGameOver();
			}

		}
			isMoving = false;
	}

	void LinkSnakeObject()
	{
		NewSnakePart clone = (NewSnakePart)Instantiate(snakObj);
		clone.transform.parent = transform.parent;
		clone.transform.name = snakObj.transform.name;
		
	}

}
