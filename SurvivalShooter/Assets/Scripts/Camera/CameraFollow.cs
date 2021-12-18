using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	public float smoothing = 5f;

	private Vector3 offset;

	void Start()
	{
		
	}

	void FixedUpdate()
	{
		if(target==null)
        {
			if (FindObjectOfType<PlayerMovement>() != null)
            {
				target = FindObjectOfType<PlayerMovement>().transform;
				offset = transform.position - target.position;
			}
		}
		if (target!=null)
        {
			Vector3 targetCamPos = target.position + offset;
			transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
		}
	}
}
