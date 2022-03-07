using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement
    public float speed;
    public float horizontalInput;
    public float verticalInput;

    //Sooting
    public GameObject shootingPrefab;
    public Transform shootingPoint;
    public ParticleSystem shootEffect;

    public int health;
    public GameObject destructionVFX;
    public GameObject hitEffect;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shoot();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.up *  verticalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontalInput  * speed * Time.deltaTime);
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(shootingPrefab,shootingPoint.position,Quaternion.identity);
            shootEffect.Play();
        }
    }

    public void GetDamage(int damage)
    {
        health -= damage;           //reducing health for damage value, if health is less than 0, starting destruction procedure
        if (health <= 0)
            Destruction();
        else
            Instantiate(hitEffect, transform.position, Quaternion.identity, transform);
    }

    void Destruction()
    {
        Instantiate(destructionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        GameManager.instance.GameOver();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            GameManager.instance.GameOver();
            Destroy(gameObject);
        }
    }
}
