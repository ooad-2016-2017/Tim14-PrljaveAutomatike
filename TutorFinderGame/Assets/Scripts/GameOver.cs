using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	public tk2dTextMesh txtScore, txtBest, collectedFruits;

	private static string kGameHighScore = "Game_Best_Score";

	void OnEnable()
	{
		setScoreAndBestScore();
	}
	public void setScoreAndBestScore()
	{	
		txtScore.text = "Score : "+GameManager.instance.Score;
		int best = GetHighScore();
		Debug.Log("Best "+best);
		if(GameManager.instance.Score > best)
		{
			best = GameManager.instance.Score;
			SetHighScore( best);
		}
		txtBest.text = "Best : "+best;
			collectedFruits.text ="Tutors : "+GameManager.instance.Fruit;
	}

	public static int GetHighScore()
	{
		return PlayerPrefs.GetInt(kGameHighScore,0);
	}
	public static void SetHighScore(int point)
	{
		PlayerPrefs.SetInt(kGameHighScore,point);
	}

	void OnReplayButtonClick()
	{
		Application.LoadLevel(0);
	}

}
