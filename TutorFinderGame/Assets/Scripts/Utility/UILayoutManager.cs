using UnityEngine;
using System.Collections;

public class UILayoutManager : MonoBehaviour
{
		public static UILayoutManager instance;
		public Camera _UICamera;
		public tk2dUILayout gameobject;
		
		void Awake ()
		{
				instance = this;
		}
		
		// Use this for initialization
		void Start ()
		{
				FixPosition ();
			coResizeLayout (gameobject);
		}
		
		private void FixPosition ()
		{
				Vector3 calcPos = _UICamera.ViewportToWorldPoint (new Vector3 (1 - 0.06f, 0.9f, 0.25f));
				//soundFxButton.position = calcPos;
				//homeButton.position = calcPos;
		}
		
		public void coResizeLayout (tk2dUILayout screenLay)
		{
				Vector3 minFrom = _UICamera.ScreenToWorldPoint (new Vector3 (0, 0, -3));
				Vector3 maxFrom = _UICamera.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, -3));
				
				screenLay.SetBounds (minFrom, maxFrom);
				///layout.SetBounds( min, max );
		}
}