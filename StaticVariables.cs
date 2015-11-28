using UnityEngine;
using System.Collections;

public class StaticVariables : MonoBehaviour {

    public static string playerName;

	// Use this for initialization
	void Start () {
        // Don't destroy this script when transitioning scenes
        DontDestroyOnLoad(gameObject);
	}
	
    public void SetPlayerName(string n)
    {
        playerName = n;
    }

    public string GetPlayerName()
    {
        return playerName;
    }
}
