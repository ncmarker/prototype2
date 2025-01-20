using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTimer;
    private float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = spawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0){
            spawnTime = spawnTimer;
            Instantiate(enemy, SelectSpawnPoint(), transform.rotation);
        }
    }

    public Vector3 SelectSpawnPoint(){
        Vector3 spawnPoint = Vector3.zero;
        return spawnPoint;
    }
}
