using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineManagerRight : SingletonBehaviour<VineManagerRight>{

    public List<GameObject> vineSpawnPoints;
    public List<GameObject> vinePrefabs;

    public void SpawnVines()
    {
        var vineSpawnPoint = vineSpawnPoints[Random.Range(0, 4)];
        var vines = Instantiate(vinePrefabs[Random.Range(0, 2)]);
        vines.transform.SetParent(transform);
        vines.transform.position = vineSpawnPoint.transform.position;
    }
}

