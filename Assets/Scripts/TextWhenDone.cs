using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWhenDone : MonoBehaviour {
    // Update is called once per frame

    public GameObject target;

    void Start()
    {
        target.SetActive(false);
    }

    void Update()
    {
        if (ScoreKeeper.count <= 0)
        {
            target.SetActive(true);
        }
    }
}
