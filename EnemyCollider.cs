using UnityEngine;
using UnityEngine.UI;
using System.Collections;

#region Enemy Collider Class: Handle the events to occur when a collision or trigger happens
public class EnemyCollider : MonoBehaviour {

    #region Variables: Slider, Explosion(Particle System), Boss Mode toggle, Enemy information
    public Slider bossHP_Slider;
    public GameObject explosion;
    public bool isBoss;

    private Enemy enemy;
    private ScoreLevelController scoreController;
    #endregion

    #region Start: Assign the variables
    void Start()
    {
        scoreController = FindObjectOfType<ScoreLevelController>();
        if(isBoss)
            bossHP_Slider = FindObjectOfType<Slider>();
        enemy = gameObject.GetComponent<Enemy>();
    }
    #endregion

    #region Update: Check if this enemy is the boss and set its slider value
    void Update()
    {
        if(isBoss)
            bossHP_Slider.value = enemy.hp;
    }
    #endregion

    #region OnTriggerEnter: Check if the player's projectile has triggered and do logic for the HP.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerProjectile")
        {
            // Destroy the projectile
            Destroy(other.gameObject);

            // Reduce this enemy's HP
            enemy.hp -= other.gameObject.GetComponent<Projectile>().damage;

            // Check if the enemy died after getting hit
            if (enemy.hp <= 0)
            {
                scoreController.AddExp(enemy.scoreValue);                

                // Instantiate the Explosion of the Enemy then delete after
                GameObject clone_Explosion = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
                Destroy(clone_Explosion, 1.0f);        

                // Destroy this enemy
                Destroy(gameObject);
            }
        }
    }
    #endregion
}
#endregion
