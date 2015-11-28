using UnityEngine;
using System.Collections;

public class BossMovement : MonoBehaviour {

    public Vector3 start;
    public float smooth;
    public float length;

    private Transform t;

	// Use this for initialization
	void Start () {
        t = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        //t.position = new Vector3(Mathf.PingPong(Time.time, 100), end, Time.deltaTime * smooth);
        t.position = new Vector3(start.z + Mathf.PingPong(Time.time * smooth, length), t.position.y, t.position.z);
    }
}
