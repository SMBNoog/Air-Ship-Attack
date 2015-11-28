using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour {

    public Vector3 boundary_Min;
    public Vector3 boundary_Max;

    public GameObject[] obstacles;

    [HideInInspector]
    public bool spawnerRunning = true;

    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        
        Debug.Log("Starting Wave");

        while(spawnerRunning)
        {
            yield return new WaitForSeconds(1.0f);
            Vector3 spawnPosition = new Vector3(Random.Range(boundary_Min.x, boundary_Max.x), boundary_Min.y, boundary_Min.z);

            int randomNumber = (int)Random.Range(1.0f,4.0f);

            int index = 1;
            foreach(GameObject obs in obstacles)
            {
                if(randomNumber == index)
                {
                    Instantiate(obstacles[index-1], spawnPosition, Quaternion.identity);
                }
            }
        }
    }
}
