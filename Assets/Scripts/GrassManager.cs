using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassManager : MonoBehaviour {
    public List<GameObject> spawnPoints;
    public List<GameObject> grassPrefabs;

    public void SpawnGrass()
    {
        var spawnPoint = spawnPoints[0];
        var grass = Instantiate(grassPrefabs[0]);
        grass.transform.position = spawnPoint.transform.position;
    }

    void Update()
    {
        SpawnGrass();
        
    }
}
