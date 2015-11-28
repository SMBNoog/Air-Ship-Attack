using UnityEngine;
using System.Collections;

// Enemy class to hold values regarding the Enemy
public class Enemy : MonoBehaviour {

    public float hp;
    public float speed;
    public int scoreValue;  
    public float fireRate = 0.5f;
    public float fireSpeed = 5.0f;
    public GameObject enemy_Prefab;
}
