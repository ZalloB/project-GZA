using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour {

    private float SpawnRate = 8.05f;
    private GameObject[] spawnPoints;
    private GameObject chosenSpawnPoint;
    private int index;
    public GameObject zombie;

    private void Awake()
    {
        StartCoroutine(SpawnEnemies());
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator SpawnEnemies()
    {

        while (true)
        {

            if (SpawnRate > 0.5f)
            {
                SpawnRate -= 0.05f;
            }

            spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
            index = UnityEngine.Random.Range(0, spawnPoints.Length);
            chosenSpawnPoint = spawnPoints[index];

            Instantiate(zombie, chosenSpawnPoint.transform.position, chosenSpawnPoint.transform.rotation);


            yield return new WaitForSeconds(SpawnRate);
        }


    
    }
}





