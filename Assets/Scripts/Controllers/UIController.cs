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
		Plane playerPlane = new Plane(Vector3.up, pointer.transform.position);
		float hitdist = 0.0f;
		
		if (playerPlane.Raycast(ray, out hitdist))
		{
			Vector3 targetPoint = ray.GetPoint(hitdist);
			pointCircle.enabled = true;
			pointer.transform.position = targetPoint;
			Invoke("HidePointer", 0.5f);
		}
	}

	void HidePointer()
	{
		pointCircle.enabled = false;
	}
}
