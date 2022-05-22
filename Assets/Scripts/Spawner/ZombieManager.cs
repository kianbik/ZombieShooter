using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    public int numZombiesToSpawn;
    public GameObject[] zombiePrefabs;
    public SpawnerVolume[] spawnerVolumes;
    public AudioSource spawnSound;
    GameObject followGameObject;
    public float secondsBetweenSpawn;
    public float elapsedTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        followGameObject = GameObject.FindGameObjectWithTag("Player");
        
      
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > secondsBetweenSpawn)
        {
            SpawnZombie();
            elapsedTime = 0.0f;
            spawnSound.Play();
        }
    }
    void SpawnZombie()
    {
        GameObject zombieToSpawn = zombiePrefabs[Random.Range(0, zombiePrefabs.Length)];
        SpawnerVolume spawnVolume = spawnerVolumes[Random.Range(0, spawnerVolumes.Length)];

        if (!followGameObject) return;

        GameObject zombie = Instantiate(zombieToSpawn, spawnVolume.GetPositionInBounds(), spawnVolume.transform.rotation);

        zombie.GetComponent<ZombieComponent>().Initialize(followGameObject);
    }
}
