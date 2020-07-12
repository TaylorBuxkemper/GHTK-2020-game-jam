using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassManager : SingletonBehaviour<GrassManager> {
    public List<GameObject> spawnPoints;
    public List<GameObject> grassPrefabs;

    public void SpawnGrass()
    {
        var spawnPoint = spawnPoints[Random.Range(0,7)];
        var grass = Instantiate(grassPrefabs[Random.Range(0,5)]);
        grass.transform.SetParent(transform);
        grass.transform.position = spawnPoint.transform.position;
    }

    void Update()
    {
        SpawnGrass();
        
    }
}
