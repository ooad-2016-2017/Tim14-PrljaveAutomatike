using UnityEngine;
using System.Collections;

public class Utility : MonoBehaviour
{
    #region PUBLIC_VARS
    #endregion

    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    #endregion

    #region PUBLIC_FUNCTIONS
    public static GameObject Get2DTouchObject() {
        GameObject touchObject=null;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Utility.GetPosition()), Vector2.zero);
        if (hit.transform!= null)
            touchObject = hit.transform.gameObject;
        return touchObject;
    }

    public static Vector3 GetTouchPosition(float depth)
    {
        Vector3 touchPosition=Vector3.zero;
        #if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_METRO
                touchPosition = Input.mousePosition;
        
        #else
            if(Input.touchCount>0){
                touchPosition = Input.GetTouch(0).position;
            }
        #endif
        touchPosition.z = depth;
        return Camera.main.ScreenToWorldPoint(touchPosition);
    }

    public static Vector3 GetPosition()
    {
        Vector3 touchPosition=Vector3.zero;
        #if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_METRO
                touchPosition = Input.mousePosition;
        #else
            if(Input.touchCount>0){
                touchPosition = Input.GetTouch(0).position;
            }
        #endif
                return touchPosition;
    }


    public static RaycastHit IsHit(Vector3 position, Vector3 direction, float distance)
    {
        RaycastHit hit;
        Debug.DrawRay(position, direction * distance, Color.red);
        if (Physics.Raycast(position, direction, out hit, distance))
        {
            return hit;
        }
        return hit;
    }

    public static RaycastHit IsHit(Vector3 position, Vector3 direction, float distance, LayerMask layerMask)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, distance, layerMask))
        {
            return hit;
        }
        return hit;
    }

    public static RaycastHit GetHit(Vector3 screenPosition,float distance, LayerMask layerMask)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, distance, layerMask))
        {
            return hit;
        }
        return hit;
    }

    public static RaycastHit2D GetHit2D(Vector3 screenPosition, float distance, LayerMask layerMask)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Ray2D ray2D = new Ray2D((Vector2)ray.origin, (Vector2)ray.direction);
        Debug.DrawRay(ray2D.origin, Vector3.forward * distance, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(ray2D.origin, ray2D.direction,distance, layerMask,0.2f,500f);
        if (hit.collider != null)
        {
            return hit;
        }
        return hit;
    }

    public static Collider[] GetOverlapSphere(Vector3 position, float radius)
    {
        return Physics.OverlapSphere(position, radius);
    }

    public static Collider[] GetOverlapSphere(Vector3 position, float radius, LayerMask layerMask)
    {
        return Physics.OverlapSphere(position, radius, layerMask);
    }

    public static RaycastHit GetLineCast(Vector3 start, Vector3 end)
    {
        RaycastHit hit;
        Debug.DrawLine(start, end, Color.red);
        if (Physics.Linecast(start, end, out hit))
            return hit;
        return hit;
    }

    public static RaycastHit GetLineCast(Vector3 start , Vector3 end,LayerMask layerMask)
    {
        RaycastHit hit;
        Debug.DrawLine(start, end, Color.red);
        if (Physics.Linecast(start, end, out hit,layerMask))
            return hit;
        return hit;
    }

    public static bool GetTouchState()
    {
        #if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_METRO
                if (Input.GetMouseButtonDown(0))
                    return true;
                if (Input.GetMouseButton(0))
                    return true;
                else if (Input.GetMouseButtonUp(0))
                    return false;
        
        #else
                if(Input.touchCount>0){
		        Touch touch = Input.GetTouch(0);
		        if(touch.phase == TouchPhase.Began)
			        return true;
		        else if(touch.phase == TouchPhase.Moved)
			        return true;
		        else if(touch.phase == TouchPhase.Stationary)
			        return true;
		        else if(touch.phase == TouchPhase.Canceled)
			        return false;
		        else if(touch.phase == TouchPhase.Ended)
			        return false;
                }
        #endif
                return false;
    }

	public static Vector3 GetDirection(Vector3 firstPoint, Vector3 secondPoint)
	{
		Vector3 theRetDirection = Vector3.zero;
		theRetDirection = firstPoint - secondPoint;
		
		theRetDirection.z = 0;
		
		theRetDirection.Normalize();
		return theRetDirection;
	}

	public static float GetAngle(Vector3 moveDirection)
	{
		float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
		return targetAngle;
	}
	public static float GetAngleBetweenTwoPoint(Vector3 firstPoint, Vector3 secondPoint)
	{
		Vector3 theRetDirection = Vector3.zero;

		theRetDirection = firstPoint - secondPoint;
		
		theRetDirection.z = 0;
		
		theRetDirection.Normalize();

		float targetAngle = GetAngle(theRetDirection);

		return targetAngle;
	}

	public static bool isOverlapCircle(Vector3 pos, float radius) { 
		bool isIn = true;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, radius);
		if(colliders.Length <= 0) 
			isIn = false;
		return isIn;
	}
	public static bool isOverlapAreaAll(Vector3 pointA, Vector3 pointB) { 
		bool isIn = true;
		Collider2D[] colliders = Physics2D.OverlapAreaAll(pointA, pointB);
		if(colliders.Length <= 0) 
			isIn = false;
		return isIn;
	}

	public static void PlayReverseAnimation(GameObject obj)
	{
		obj.GetComponent<Animator>().SetTrigger("Reverse");
//		Reverse
	}


	
	#endregion
	
	#region PRIVATE_FUNCTIONS
	#endregion
	
	#region CO-ROUTINES
	#endregion
	
	#region EVENT_HANDLERS
	#endregion
}
