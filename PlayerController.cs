using UnityEngine;
using System.Collections;

//#region Define Player: name, health, tilt, speed, prefab, weapon
//[System.Serializable]
//public class Player
//{
//    private string name;
//    public string Name
//    {
//        get
//        {
//            return name;
//        }
//        set
//        {
//            name = value;
//        }
//    }
//    private float health;
//    public float Health
//    {
//        get
//        {
//            return health;
//        }
//        set
//        {
//            health = value;
//        }
//    }
//    private float tilt;
//    public float Tilt
//    {
//        get
//        {
//            return tilt;
//        }
//        set
//        {
//            tilt = value;
//        }
//    }

//    private float speed;
//    public float Speed
//    {
//        get
//        {
//            return speed;
//        }

//        set
//        {
//            speed = value;
//        }
//    }

//    private GameObject prefab;
//    public GameObject Prefab
//    {
//        get
//        {
//            return prefab;
//        }

//        set
//        {
//            prefab = value;
//        }
//    }

//    private GameObject weapon;
//    public GameObject Weapon
//    {
//        get
//        {
//            return weapon;
//        }

//        set
//        {
//            weapon = value;
//        }
//    }
//}
//#endregion

[System.Serializable]
public class PlayerInput
{
    public string name;
    public float health;
    public float tilt;
    public float speed;
    public GameObject prefab;
    public GameObject weapon;
}

#region Define the Player's Boundary: X and Z axis
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
#endregion

[System.Serializable]
public class WeaponProjectile
{
    public GameObject projectile_Obj;
    public float fireRate = 0.5f;
    public float fireSpeed = 5.0f;    
}


public class PlayerController : MonoBehaviour {
        
    public PlayerInput playerInputs;
    public Boundary boundary;
    public WeaponProjectile projectile;
    public Transform shotSpawn_Transform;
    public bool multiShot = false;
    
    private AudioSource shot_AudioClip;
    private float nextFire = 0.0f;
    private Animator animator;
    private int spreadAmount;    
    private Rigidbody player_Ridigbody; 

    void Start ()
    {
        player_Ridigbody = GetComponent<Rigidbody>();
        shot_AudioClip = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        // Initialize the player class variables
        Player.instance.PlayerName = playerInputs.name;
        Player.instance.Health = playerInputs.health;
        Player.instance.Speed = playerInputs.speed;
        Player.instance.Tilt = playerInputs.tilt;
        Player.instance.Prefab = playerInputs.prefab;
        Player.instance.Weapon = playerInputs.weapon;
    }
	
	// Update is called once per frame
	void Update () {

        // Shoot projectile
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + projectile.fireRate;
            FireWeapon(spreadAmount);
            shot_AudioClip.Play();
        }        
    }

    // FixedUpdate is called just before each physics step
    void FixedUpdate ()
    {
        if (animator == null)
        {
            // Using the input manager under "Horizontal" and "Vertical" grab all types of input the user could use for these types.
            float inputAxis_Horizontal = Input.GetAxis("Horizontal");
            float inputAxis_Vertical = Input.GetAxis("Vertical");

            // Find the direction the player wants to move
            Vector3 playerMovementDirection = new Vector3(inputAxis_Horizontal, 0.0f, inputAxis_Vertical);
            player_Ridigbody.velocity = playerMovementDirection * Player.instance.Speed;
            //player_Ridigbody.AddForce(playerMovementDirection * player.speed);

            player_Ridigbody.position = new Vector3(
                Mathf.Clamp(player_Ridigbody.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(player_Ridigbody.position.z, boundary.zMin, boundary.zMax));

            player_Ridigbody.rotation = Quaternion.Euler(0.0f, 0.0f, player_Ridigbody.velocity.x * -Player.instance.Tilt);
        }
    }

    private void FireWeapon(int spread)
    {
        GameObject[] clone_Array = new GameObject[spread];

        for (int i = 0; i < clone_Array.Length; i++)
        {
            clone_Array[i] = Instantiate(projectile.projectile_Obj, shotSpawn_Transform.position, Quaternion.identity) as GameObject;
        }
        float offSet = 0;

        if (spread == 3)
        {
            offSet = -1000.0f;
            projectile.fireRate = 0.18f;
        }
            
        else if (spread == 5)
        {
            offSet = -2000.0f;
            projectile.fireRate = 0.13f;
        }
            
        foreach (GameObject obj in clone_Array)
        {
            Rigidbody clone_Rigidbody = obj.GetComponent<Rigidbody>();
            clone_Rigidbody.AddForce(transform.forward * projectile.fireSpeed * 100.0f + transform.right * offSet);
            offSet += 1000.0f;
        }
    }

    public void SetSpreadAmount(int n)
    {
        spreadAmount = n;
    }

    // return the spread amount for the multi shot
    public int GetSpreadAmount()
    {
        return spreadAmount;
    }

    // Destroy the animation after its completed
    public void DestroyAnimations()
    {
        Destroy(GetComponent<Animator>());
    }

    // Set the amount of spread for the multi shot ability
    public void SetMultiShot(bool m)
    {
        multiShot = m;
    }
}
