using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

    public AudioSource[] audioSources;
    
    private PlayerHealthController playerHP_Controller;
    private ScoreLevelController scoreExp_Controller;

    void Start()
    {
        playerHP_Controller = FindObjectOfType<PlayerHealthController>();
        scoreExp_Controller = FindObjectOfType<ScoreLevelController>();
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemy")
        {            
            float impactForce = col.relativeVelocity.magnitude;
            
            float damage = 0;
            if (impactForce < 80)
                damage = 20.0f;
            else if (impactForce >= 80 && impactForce <= 150)
                damage = 25.0f;
            else if (impactForce < 150)
                damage = 30.0f;

            Debug.Log("Player hit by enemy\n" + "Player HP: " + Player.instance.Health);
            Player.instance.Health -= damage;
            Debug.Log("Player health after adjustment: " + Player.instance.Health);
            audioSources[0].Play();

            Destroy(col.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnemyProjectile")
        {
            Destroy(other.gameObject);
            Player.instance.Health -= other.GetComponent<Projectile>().damage;
            audioSources[1].Play();
            //Play Particle system for impact
        }

        if(other.gameObject.tag == "PowerUp_Health")
        {
            Destroy(other.gameObject);
            Player.instance.Health += 25f;
            audioSources[2].Play();
        }

        if(other.gameObject.tag == "PowerUp_Magic")
        {
            Destroy(other.gameObject);
            scoreExp_Controller.AddMagic(25);
            audioSources[2].Play();
        }
    }
}
