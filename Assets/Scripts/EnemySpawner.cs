using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTimer;
    private float spawnTime;

    public Transform minSpawn;
    public Transform maxSpawn; 

    void Start()
    {
        spawnTime = spawnTimer;
    }

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
        bool isVerticalSpawn = Random.Range(0f, 1f) > .5f;

        if (isVerticalSpawn){
            spawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y);
            if (Random.Range(0f, 1f) > .5f){
                spawnPoint.x = maxSpawn.position.x;
            }
            else {
                spawnPoint.x = minSpawn.position.x;
            }
        }
        else{
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);
            if (Random.Range(0f, 1f) > .5f){
                spawnPoint.y = maxSpawn.position.y;
            }
            else {
                spawnPoint.y = minSpawn.position.y;
            }
        }

        return spawnPoint;
    }
}
