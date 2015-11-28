using UnityEngine;
using System.Collections;

public class DestroyExit : MonoBehaviour {

    // When anything leaves the play area destroy it
	void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
