using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PowerUp
{
    public string name;
    public float value;
    public float speed;
    public GameObject prefab;
}

[System.Serializable]
public class Wave
{
    public string name;
    public List<PowerUp> powerUps;
}

public class PowerUpSpawner : MonoBehaviour {

    public List<Wave> waves;

    void Start()
    {
        StartCoroutine(StartSpawningPowerUps());
    }

    IEnumerator StartSpawningPowerUps()
    {
        yield return new WaitForFixedUpdate();

        while (true)
        {
            foreach (Wave w in waves)
            {
                foreach (PowerUp p in w.powerUps)
                {

                    yield return new WaitForSeconds(Random.Range(1, 3));
                    // Randomize spawn x value
                    int x = Random.Range(-80, 80);

                    Vector3 position = new Vector3(x, transform.position.y, transform.position.z);
                    GameObject powerUp_Clone = Instantiate(p.prefab, position, Quaternion.identity) as GameObject;
                    Rigidbody clone_Rigidbody = powerUp_Clone.GetComponent<Rigidbody>();
                    clone_Rigidbody.velocity = -transform.forward * p.speed;
                }
                yield return new WaitForSeconds(Random.Range(2, 4));
            }
            yield return null;
        }
    }
}
