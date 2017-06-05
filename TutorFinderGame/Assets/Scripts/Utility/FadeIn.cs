using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {
	private SpriteRenderer mask;
	private Color maskOpacity;
	
	void OnEnable ()
	{	
		mask = GetComponent<SpriteRenderer>();
		maskOpacity = mask.color;
		maskOpacity.a = 0f;
		mask.color = maskOpacity;
		mask.gameObject.SetActive (true);
		StartIncreaseOpacity ();
	}
	public void StartIncreaseOpacity ()
	{
		StartCoroutine (IncreaseMaskOpacity ());
	}
	
	private IEnumerator IncreaseMaskOpacity ()
	{
		yield return 0;
		
		maskOpacity = mask.color;
		maskOpacity.a += 0.05f;
		mask.color = maskOpacity;
		
		if (maskOpacity.a < 1f)
			StartCoroutine (IncreaseMaskOpacity ());
	}
	
	public void StartDecreaseOpacity ()
	{
		StartCoroutine (DecreaseMaskOpacity ());
	}
	
	private IEnumerator DecreaseMaskOpacity ()
	{
		yield return 0;
		
		maskOpacity = mask.color;
		maskOpacity.a -= 0.05f;
		mask.color = maskOpacity;
		
		if (maskOpacity.a > 0f){
			StartCoroutine (DecreaseMaskOpacity ());
		}
		else
			gameObject.SetActive(false);
	}
}
