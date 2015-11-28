#region namespace and class declaration
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    #endregion

    #region Variables: Player prefab to instatiate, toggle to spawn the player or not, clone gameobect to hold the player and current time
    public GameObject player_Prefab;
    public bool spawnClone;

    private GameObject player_Clone;
    private float time;
    #endregion

    #region Awake: Force the Resolution to be 900x1400.
    void Awake ()
    {
        //Screen.SetResolution(900, 1440, true);        
    }
    #endregion

    #region Start: Call SpawnPlayer and set time to the current time.
    void Start () {
        if (spawnClone)
            StartCoroutine(SpawnPlayer());
        time = Time.time;
        Debug.Log(time);
	}
    #endregion

    #region Update: Once the player presses a button after one second time Stop the Animation.
    void Update()
    {
        if (Input.anyKey && time + 1f <= Time.time)
        {
            FindObjectOfType<PlayerController>().DestroyAnimations();
        }
    }
    #endregion

    #region SpawnPlayer: Set the position of the player, wait for a FixedUpdate then spawn the player
    // Spawn the Player in the starting position
    IEnumerator SpawnPlayer()
    {
        Vector3 spawnPosition = new Vector3(0.0f, 0.0f, -140.0f);

        yield return new WaitForFixedUpdate();

        if (player_Clone == null)
            player_Clone = Instantiate(player_Prefab, spawnPosition, Quaternion.identity) as GameObject; 
    }
    #endregion

    #region GameOver: Restart the game
    public void GameOver()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    #endregion
}
