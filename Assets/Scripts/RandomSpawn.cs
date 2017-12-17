using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnItem
{
    public GameObject gameObject;
    public int count = 1;
    public float scale = 1f;
    public float zOffset = 0f;
}

public class RandomSpawn : MonoBehaviour {

    public GameObject planet;
    public SpawnItem[] spawnObjects;

	void Start () {
        foreach (SpawnItem item in spawnObjects)
        {
            for (int i = 0; i < item.count; i++)
            {
                spawn(item);
            }
        }
	}
	
	void spawn(SpawnItem item)
    {
        GameObject obj = item.gameObject;
        obj.transform.localScale = new Vector3(item.scale, item.scale, item.scale);

        Vector3 pos = Random.onUnitSphere * ((planet.transform.localScale.x / 2) + item.zOffset);
        Quaternion rot = Quaternion.FromToRotation(Vector3.down, planet.transform.position - pos);

        Instantiate(obj, pos, rot);
    }
}
