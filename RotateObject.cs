using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {

    private Transform player_Transform;
	
    void Start()
    {
        player_Transform = transform;
    }

	// Update is called once per frame
	void Update () {
        player_Transform.Rotate(player_Transform.rotation.x, player_Transform.rotation.y + 1f, player_Transform.rotation.z);
	}
}
