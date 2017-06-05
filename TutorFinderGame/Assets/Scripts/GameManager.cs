using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour {
	#region PUBLIC_VARIABLES
	public static GameManager instance;
	
	public GameObject[] snakFoods;

	public GameObject food1, food2, gameOverPanel;

	public SnakePart tail;
	
	public List<GameObject> generateSnakFood;

	public List<SnakePart> generatedSnakPart;

	public tk2dTextMesh txtScore;// collectedFruits;


	//public Transform FrameBorder, Border;

	public int Score
	{
		get { return _score; }
		set {
			_score = value;
			txtScore.text = "Score : "+_score;
		
		}
	}
	public int Fruit
	{
		get { return _fruit; }
		set {
			_fruit = value;
		}
	}


	#endregion
	
	#region PRIVATE_VARIABLES
	private Color maskOpacity;
	
	private float startTime;
	
	private int _score, snakeDestroyerCounter, _fruit;

	private string[] snakeFoodNames = new string[]{"obj_1", "obj_2", "obj_3", "obj_4", "obj_5"};

	internal bool isGameRunning, isMoving;

	private int[] stageUnlockFruits = new int[4]{100, 150, 180, 150};

	#endregion
	
	#region UNITY_CALLBACKS
	// Awake is called when the script instance is being loaded
	void Awake()
	{
		instance = this;
		generateSnakFood = new List<GameObject>();

	}
	
	void OnEnable () {
		Score = Fruit = 0;
		isGameRunning  =false;
		ResetGame();
	}





	#endregion
	
	
	#region PUBLIC_METHODS
	public void ManageScore(int value)
	{
		if(Fruit <= 50)
			Score += value;
		else if(Fruit > 50 && Fruit <=120)
			Score += value * 2;
		else if(Fruit > 120)
			Score += value *3;
	}

	public void StartGame()
	{
		isGameRunning = true;
	}
	public void ResetGame() {
		startTime = Time.time;
		Fruit = 0;

		foreach(GameObject obj in generateSnakFood){
			Destroy(obj);
		}

		generateSnakFood = new List<GameObject>();

		Invoke("GenerateRandomSnakFoods", .5f);
		Invoke("GenerateRandomSnakFoods", .5f);
	}


	public void GenerateRandomSnakFoods() {
		while(true){
			int randVal = Random.Range(0, 5);
			Vector3 pos = Vector3.zero;
			pos.x = Random.Range(-9.0f, 9.0f);
			pos.y = Random.Range(-5.0f, 5f);

			if (!Utility.isOverlapCircle(pos, .65f))// isInDistance(pos))
			{
				if(!food1.activeSelf)
				{
					food1.transform.name = snakeFoodNames[randVal];
					food1.transform.position = pos;
					food1.SetActive(true);
				}
				else if(!food2.activeSelf)
				{
					food2.transform.name = snakeFoodNames[randVal];
					food2.transform.position = pos;
					food2.SetActive(true);

				}

				break;
			}
		}
	}


	public void LinkPartToLast(SnakePart part)
	{
		 generatedSnakPart[generatedSnakPart.Count - 1].snakePart  = part;
	}

	public SnakePart GetTailOfSnake()
	{
		Vector3 secondLastPartPosition = generatedSnakPart[generatedSnakPart.Count -2].transform.position;
		
		Vector3 lastPartPosition = generatedSnakPart[generatedSnakPart.Count -1].transform.position;

		tail.transform.position += Utility.GetDirection(lastPartPosition, secondLastPartPosition) * Constants.SNAKE_TAIL_DISTANCE;

		return tail;
	}
	
	public Vector3 GetLastSnakPartPosition()
	{
		Vector3 secondLastPartPosition = generatedSnakPart[generatedSnakPart.Count -2].transform.position;
		Vector3 lastPartPosition = generatedSnakPart[generatedSnakPart.Count -1].transform.position;
		lastPartPosition += Utility.GetDirection(lastPartPosition, secondLastPartPosition)  * Vector2.Distance(secondLastPartPosition, lastPartPosition);// *   Constants.SNAKE_PART_DISTANCE ;
		
		return lastPartPosition;
	}

	public Quaternion GetLastSnakPartRotation()
	{
			return generatedSnakPart[generatedSnakPart.Count -1].transform.localRotation;
	}

//	void destroyObject()
//	{
//		Debug.Log("Destroy snake");
//		foreach(SnakePart part in generatedSnakPart){
//			if(part)
//				Destroy(part.gameObject);
//		}
//		if(tail)
//			Destroy(tail.gameObject);
//		Destroy(PlayerScript.instance.gameObject);
//		destroyFoods();
//	}
//	public void destroyFoods()
//	{
//		foreach(GameObject obj in generateSnakFood)
//			Destroy(obj);
//	}


//	public void DestroySnak()
//	{
//		Invoke("destroyObject", .3f);
//	}

	public int GetLastSnakPartSortingOrder()
	{
		return generatedSnakPart.Count;
	}

//	public void DestroySnakeParts()
//	{
//		if(snakeDestroyerCounter < 1 || generatedSnakPart.Count < 10)
//			return;
//
//		snakeDestroyerCounter--;
//		snakePartDestroyer.SetNumberOfDestroyer(snakeDestroyerCounter);
//
//		if(snakeDestroyerCounter == 0)
//			snakePartDestroyer.GetComponent<FadeIn>().StartDecreaseOpacity();
//
//		for(int i=0; i<Constants.NUM_OF_SNAKE_PART_FOR_DESTROY; i++)
//		{
//			Destroy( generatedSnakPart[generatedSnakPart.Count - 1].gameObject);
//			generatedSnakPart.RemoveAt(generatedSnakPart.Count - 1);
//		}
//	
//		tail.transform.position = generatedSnakPart[generatedSnakPart.Count - 1].transform.position;
//		tail.transform.localRotation = generatedSnakPart[generatedSnakPart.Count - 1].transform.localRotation;
//
//		generatedSnakPart[generatedSnakPart.Count - 1].snakePart = GetTailOfSnake();
//	}

	public void showGameOver()
	{	
		gameOverPanel.SetActive(true);
	}
	#endregion
	

}
