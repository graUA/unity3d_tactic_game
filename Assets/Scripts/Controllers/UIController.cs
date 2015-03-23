using UnityEngine;
using System.Collections;

using Global;

public class UIController : MonoBehaviour {

	public GameObject pointer;
	private SpriteRenderer pointCircle;
	
	void Start () 
	{
		pointCircle = pointer.GetComponent<SpriteRenderer>();
	}

	void Update () 
	{

	}

	public void HighlightDestinationPoint(Ray ray)
	{
        RaycastHit hitInfo = new RaycastHit();
        if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
		{
            Vector3 targetPoint = hitInfo.point;
			pointCircle.enabled = true;
			pointer.transform.position = targetPoint + new Vector3(0, 0.2f, 0);
            CancelInvoke("HidePointer");
			Invoke("HidePointer", 0.5f);
		}
	}

	void HidePointer()
	{
		pointCircle.enabled = false;
	}
}
