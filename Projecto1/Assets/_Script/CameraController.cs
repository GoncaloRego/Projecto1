using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform lookAt;
    public Transform camTransform;

    private Camera camera;
    private float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensX = 4.0f;
    private float sensY = 1.0f;

	private void Start ()
    {
        camTransform = transform;
        camera = Camera.main;

	}

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
