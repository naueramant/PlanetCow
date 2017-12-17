using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {

    public float speed = 1;
    public Vector3 direction = Vector3.forward;
    public GameObject rotateAround;
	
	// Update is called once per frame
	void Update () {
        if (rotateAround)
            transform.RotateAround(rotateAround.transform.position, Vector3.forward, Time.deltaTime*speed);
    }
}
