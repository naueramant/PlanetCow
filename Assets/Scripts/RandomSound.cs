using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour {

    public int maxTime = 45;
    public int minTime = 10;
    public List<AudioClip> sounds;
    public GameObject cow;

	// Use this for initialization
	void Start () {
        Invoke("playSound", Random.Range(minTime, maxTime));
    }

    void playSound()
    {
        AudioSource.PlayClipAtPoint(sounds[Random.Range(0, sounds.Count)], cow.transform.position);

        Invoke("playSound", Random.Range(minTime, maxTime));
    }
}
