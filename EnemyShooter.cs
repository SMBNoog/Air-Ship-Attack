using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour {

    #region Variables: Enemy class and when the enemy can fire next
    public Enemy enemy;
    public bool isRocket;
    public GameObject projectile_Prefab;
    private float nextFire = 0.0f;
    #endregion

    #region Update: If time has passed enough to fire, fire the weapon!
    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + enemy.fireRate;
            GameObject clone = Instantiate(projectile_Prefab, transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f)) as GameObject;
            Rigidbody clone_Rigidbody = clone.GetComponent<Rigidbody>();

            if(isRocket)
            {
                Transform pos = FindObjectOfType<PlayerController>().gameObject.transform;
                // Have the enemy look at the players position
                transform.LookAt(pos);
            }
            clone_Rigidbody.velocity = transform.forward * enemy.fireSpeed;
        }
    }
    #endregion
}
