using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamUp : MonoBehaviour
{
    public GameObject playerModel;
    public Camera camera;

    public GameObject impactEffect;
    public GameObject faildEffect;

    public AudioClip soundEffectCow;
    public AudioClip soundEffectHit;
    public AudioClip soundEffectMiss;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetButtonDown("Fire1"))
        {
            beam();
        }
    }

    void beam()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerModel.transform.position, camera.transform.forward, out hit))
        {
            if(hit.transform.name == "CowBlW")
            {
                Destroy(hit.transform.parent.gameObject, 0f);
                AudioSource.PlayClipAtPoint(soundEffectCow, hit.point);
                AudioSource.PlayClipAtPoint(soundEffectHit, hit.point);

                GameObject impactEffectInst = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactEffectInst, 5f);

                ScoreKeeper.count--;
            } else
            {
                AudioSource.PlayClipAtPoint(soundEffectMiss, hit.point);

                GameObject impactEffectInst = Instantiate(faildEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactEffectInst, 5f);
            }
        }
    }
}
