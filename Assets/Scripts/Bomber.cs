using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour {

    public GameObject playerModel;
    public Camera camera;
    public GameObject impactEffect;
    public GameObject impactModel;
    public AudioClip soundEffect;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space") || Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
	}

    void shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(playerModel.transform.position, camera.transform.forward, out hit) && hit.transform.name == "Planet")
        {
            GameObject impactEffectInst = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactEffectInst, 5f);

            GameObject impactModelInst = Instantiate(impactModel, hit.point, Quaternion.FromToRotation(Vector3.up, hit.point));
            Destroy(impactModelInst, 10f);

            AudioSource.PlayClipAtPoint(soundEffect, hit.point);
        }
    }
}
