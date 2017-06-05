using UnityEngine;
using System.Collections;

public class SnakePart : MonoBehaviour {
	public SnakePart snakePart;
	public bool isLast;

	Vector3  moveToward,moveDirection , currentPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	public void MoveSnakePart(Vector3  nextPosition, Quaternion nextRotation)
	{
		Vector3 nextPartPosition = transform.position;

		Quaternion nextPartRotation = transform.localRotation;

		currentPosition = transform.position;
	
		transform.position =  Vector2.Lerp(transform.position, nextPosition, Time.deltaTime * Constants.SPEED);

		// HANDLES ROTATION
		moveDirection = Utility.GetDirection(nextPosition, currentPosition);
		
		if(!isLast){
			transform.rotation = Quaternion.Slerp (transform.rotation, nextRotation, 20f * Time.deltaTime);
			snakePart.MoveSnakePart(nextPartPosition, nextPartRotation);
		}
		else
		{
			moveDirection = Utility.GetDirection(nextPosition, currentPosition);
			
			currentPosition += moveDirection * .5f;
			
			if (moveDirection != Vector3.zero)
			{
				float targetAngle = Utility.GetAngle(moveDirection);// Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, targetAngle), 20f * Time.deltaTime);
			}
		}
	}
}
