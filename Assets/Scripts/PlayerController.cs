using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 50.0F;
    public float turnSpeed = 3.0F;

    public GameObject planet;
	
	// Update is called once per frame
	void Update () {
        if(planet)
        {
            Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            moveDirection = transform.TransformDirection(moveDirection);

            transform.RotateAround(planet.transform.position, moveDirection, Time.deltaTime * moveSpeed * Mathf.Clamp(Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical")), 0f, 1f));

            transform.Rotate(Vector3.up, Input.GetAxis("RightJoyStick")*turnSpeed);
        }

        if (Input.GetButtonDown("Start") || Input.GetKey("return"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            ScoreKeeper.count = 15;
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
