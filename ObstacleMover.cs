using UnityEngine;
using System.Collections;

public class ObstacleMover : MonoBehaviour {

    public float speed = 10.0f;

    private Rigidbody obstacle_Rigidbody;

    // Use this for initialization
    void Start () {
        obstacle_Rigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        obstacle_Rigidbody.velocity = -transform.forward * speed;
    }
}
