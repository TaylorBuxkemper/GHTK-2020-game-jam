using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassManager : SingletonBehaviour<GrassManager> {
    public List<GameObject> spawnPoints;
    public List<GameObject> grassPrefabs;

    public void SpawnGrass() {
        var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count-1)];
        var grass = Instantiate(grassPrefabs[Random.Range(0, grassPrefabs.Count-1)]);
        grass.transform.SetParent(transform);
        grass.transform.position = spawnPoint.transform.position;
        //grass.transform.localScale = Vector3.one * GetComponentInParent<Canvas>().transform.localScale.y;
        grass.transform.localScale = Vector3.one;
    }

}
