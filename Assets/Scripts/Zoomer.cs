using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoomer : MonoBehaviour {

    public GameObject planet;
    public GameObject player;

    public float zoomStep = 20;
    public float zoomMax = 100;
    public float zoomMin = 40;
    public int animationTime = 1000;

    private bool pressed = false;

    private PlayerController playerController;

    void Start()
    {
        playerController = (PlayerController)player.GetComponent("PlayerController");
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetAxis("Triggers") >= 0.3f && !pressed)
        {
            pressed = true;
            zoom(1);
        }
        else if (Input.GetAxis("Triggers") <= -0.3f && !pressed)
        {
            pressed = true;
            zoom(-1);
        }
        else if (Input.GetAxis("Triggers") < 0.3f && Input.GetAxis("Triggers") > -0.3f)
        {
            pressed = false;
        }
    }

    void zoom(float zoomDirection)
    {
        if(checkAllowed(zoomDirection))
        {
            Vector3 direction = (planet.transform.position - player.transform.position);
            direction.Normalize();

            player.transform.position = player.transform.position - ((direction * zoomStep) * zoomDirection);

            playerController.moveSpeed += zoomStep * zoomDirection;
        }
    }

    bool checkAllowed(float zoomDirection)
    {
        float distance = Vector3.Magnitude(planet.transform.position - player.transform.position);
        distance += (zoomDirection * zoomStep);

        return (distance >= zoomMin && distance <= zoomMax);
    }
}
