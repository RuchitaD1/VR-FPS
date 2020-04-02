using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public float zombieSpawnFreq;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true) {
            GameObject zombie = Instantiate(zombiePrefab);
            GameObject[] zombieSpawners = GameObject.FindGameObjectsWithTag("SpawnPoint");
            zombie.transform.position = zombieSpawners
            [Random.Range(0,
                zombieSpawners.Length)].transform.position; 
                yield return new WaitForSeconds
               (zombieSpawnFreq);

}

    }

   
}
