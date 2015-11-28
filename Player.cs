using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public static Player instance;

    void Awake()
    {
        instance = this;
    }

    private string playerName;
    public string PlayerName
    {
        get
        {
            return playerName;
        }
        set
        {
            playerName = value;
        }
    }
    private float health;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            Debug.Log("Value changed for HP now = " + health);
        }
    }
    private float tilt;
    public float Tilt
    {
        get
        {
            return tilt;
        }
        set
        {
            tilt = value;
        }
    }

    private float speed;
    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    private GameObject prefab;
    public GameObject Prefab
    {
        get
        {
            return prefab;
        }

        set
        {
            prefab = value;
        }
    }

    private GameObject weapon;
    public GameObject Weapon
    {
        get
        {
            return weapon;
        }

        set
        {
            weapon = value;
        }
    }
}
