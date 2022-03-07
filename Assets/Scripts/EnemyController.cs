using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public int health;

   
    public GameObject Projectile;

    public GameObject destructionVFX;
    public GameObject hitEffect;




    private void Start()
    {
        InvokeRepeating("ActivateShooting",1,2);
    }

    //Enemy Shooting
    void ActivateShooting()
    {
       
            Instantiate(Projectile, gameObject.transform.position, Quaternion.identity);
            
      
    }

    //method of getting damage for the 'Enemy'
    public void GetDamage(int damage)
    {
        health -= damage;           //reducing health for damage value, if health is less than 0, starting destruction procedure
        if (health <= 0)
            Destruction();
        else
            Instantiate(hitEffect, transform.position, Quaternion.identity, transform);
    }

    //if 'Enemy' collides 'Player', 'Player' gets the damage equal to projectile's damage value
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        if (Projectile.GetComponent<Projectile>() != null)
    //            Player.instance.GetDamage(Projectile.GetComponent<Projectile>().damage);
    //        else
    //            Player.instance.GetDamage(1);
    //    }

      
    //}

    //method of destroying the 'Enemy'
    void Destruction()
    {
        Instantiate(destructionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        GameManager.instance.CalculateScore(10);
        
    }
}
