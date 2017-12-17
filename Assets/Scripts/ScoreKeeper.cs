using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour {

    private TextMeshProUGUI mesh;

    public static int count = 15;

    // Use this for initialization
    void Start () {
        mesh = GetComponent<TextMeshProUGUI>();
    }
	
	// Update is called once per frame
	void Update () {

        string text = count + " cows left";

        if (count == 1)
            text = "1 cow left";
        else if (count == 0)
            text = "";

        mesh.SetText(text);
    }
}
