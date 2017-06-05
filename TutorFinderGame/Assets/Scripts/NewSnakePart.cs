using UnityEngine;
using System.Collections;

public class NewSnakePart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SetTransform();
		SetSortingOrder();
		LinkTailSnakeObject();
		LinkSnakObject();

		GameManager.instance.generatedSnakPart.Add(GetComponent<SnakePart>());
		Destroy(this);
	}
	
	public void SetSortingOrder()
	{
		// Set sorting order in decending order
		GetComponent<SpriteRenderer>().sortingOrder = 997 - GameManager.instance.GetLastSnakPartSortingOrder();
	}


	public void LinkTailSnakeObject()
	{
		GetComponent<SnakePart>().snakePart = GameManager.instance.GetTailOfSnake();
	}	

	void LinkSnakObject()
	{
		GameManager.instance.LinkPartToLast(GetComponent<SnakePart>());// .GetLastSnakObjectJoint().connectedBody = rigidbody2D;
	}

	void SetTransform()
	{
		transform.rotation = GameManager.instance.GetLastSnakPartRotation();
		transform.position = GameManager.instance.GetLastSnakPartPosition();
	}


}
