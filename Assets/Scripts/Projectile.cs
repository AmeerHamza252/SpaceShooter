using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour {

  
    public int damage;

   
    public bool enemyBullet;

 

    private void OnTriggerEnter2D(Collider2D collision) //when a projectile collides with another object
    {
        if (enemyBullet && collision.tag == "Player") 
        {
            collision.GetComponent<PlayerController>().GetDamage(damage);
            
        }
        else if (!enemyBullet && collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyController>().GetDamage(damage);
          
        }
    }

    
}


