using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeKeeper : MonoBehaviour {

    private TextMeshProUGUI mesh;

    // Use this for initialization
    void Start()
    {
        mesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreKeeper.count > 0)
        {
            mesh.SetText(FormatSeconds(Time.timeSinceLevelLoad));
        }
    }

    string FormatSeconds(float elapsed)
    {
        int d = (int)(elapsed * 100.0f);
        int minutes = d / (60 * 100);
        int seconds = (d % (60 * 100)) / 100;
        int hundredths = d % 100;
        return String.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, hundredths);
    }
}
