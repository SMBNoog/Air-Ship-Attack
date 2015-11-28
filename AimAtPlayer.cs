#region namespace & class declaration
using UnityEngine;
using System.Collections;

public class AimAtPlayer : MonoBehaviour {
#endregion

    private float enemy_Speed;              // speed to move the enemy towards the player
    private Rigidbody clone_Rigidbody;      // the enemy's rigidbody
    private Transform target_Transform;     // target(player)

    void Start()
    {
        // assign this enemy rigidbody to this rigidbody
        clone_Rigidbody = GetComponent<Rigidbody>();
        // find the player's transform and assign
        target_Transform = FindObjectOfType<PlayerController>().gameObject.transform;
        // find the enemy's movement speed
        enemy_Speed = FindObjectOfType<Enemy>().speed;
    }

	// Update is called once per frame
	void Update () {   
        // Have the enemy look at the players transform position
        transform.LookAt(target_Transform);
        // Add velocity to the enemy forward towards the player
        clone_Rigidbody.velocity = transform.forward * Time.deltaTime * 50 *  enemy_Speed;
    }
}
