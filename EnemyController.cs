using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public Enemy[] enemys;
    public int numberOfRowEnemies;
    public Boundary row_Boundary;
    public int numberOfLookAtEnemies;
    public Boundary look_Boundary;

    private GameObject enemy_Clone;
    private StateMachineBehaviour currentState;

    void Start()
    {
        StartCoroutine("SpawnEnemyRow");
        StartCoroutine("SpawnEnemyLookAt");
    }

    public void StartSpawnBoss()
    {
        StartCoroutine(SpawnBoss());
    }

    public void StopSpawningMinions()
    {
        Debug.Log("Stop Spawning Minions");
        
        StopCoroutine("SpawnEnemyRow");
        StopCoroutine("SpawnEnemyLookAt");


    }

    IEnumerator SpawnEnemyRow()
    {
        int n = numberOfRowEnemies;

        Vector3 spawnPosition = new Vector3(Random.Range(row_Boundary.xMin, row_Boundary.xMax), transform.position.y, transform.position.z);
        Quaternion spawnRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);

        yield return new WaitForFixedUpdate();
        
        while (true)
        {
            Vector3 resetSpawnPos = spawnPosition;
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                    yield return new WaitForSeconds(5f);
                
                enemy_Clone = Instantiate(enemys[0].enemy_Prefab, resetSpawnPos, spawnRotation) as GameObject;
                Rigidbody clone_Rigidbody = enemy_Clone.GetComponent<Rigidbody>();
                clone_Rigidbody.velocity = -transform.forward * enemys[0].speed;
                resetSpawnPos.x += 5.0f;

                yield return new WaitForSeconds(0.5f);
            }
            n += Random.Range(-1, 3);
            if (n < 2)
                n = 2;
            Debug.Log("Row enemies to spawn per wave: " + n);
            yield return new WaitForSeconds(Random.Range(3, 8));
        }
    }

    IEnumerator SpawnEnemyLookAt()
    {
        int n = numberOfLookAtEnemies;

        yield return new WaitForSeconds(1.0f);

        while (true)
        {
            for (int i = 0; i < n; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(look_Boundary.xMin, look_Boundary.xMax), transform.position.y, transform.position.z);
                Quaternion spawnRotation = Quaternion.identity;
                enemy_Clone = Instantiate(enemys[1].enemy_Prefab, spawnPosition, spawnRotation) as GameObject;

                AimAtPlayer aim = enemy_Clone.AddComponent<AimAtPlayer>();

                //Rigidbody clone_Rigidbody = enemy_Clone.GetComponent<Rigidbody>();
                //clone_Rigidbody.velocity = -transform.forward * enemy.speed;

                yield return new WaitForSeconds(Random.Range(.5f, 2f));
            }

            n += Random.Range(-1, 4);
            if (n < 2)
                n = 2;
            Debug.Log("Look enemies to spawn per wave: " + n);

            yield return new WaitForSeconds(Random.Range(3,5));

        }
    }

    IEnumerator SpawnBoss()
    {
        Vector3 spawnPosition = new Vector3(0, 0, -90f);
        Quaternion spawnRotation = Quaternion.Euler(new Vector3(0, 180f, 0));

        yield return new WaitForFixedUpdate();

        Instantiate(enemys[2].enemy_Prefab, spawnPosition, spawnRotation);
    }

}
