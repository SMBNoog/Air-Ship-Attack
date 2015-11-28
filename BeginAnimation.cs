using UnityEngine;
using System.Collections;

public class BeginAnimation : MonoBehaviour {

    public GameObject player;

    void Start()
    {
    }

	public void BeginIntro()
    {
        player.GetComponent<Animator>();
    }
}
