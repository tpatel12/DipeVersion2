using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    Rigidbody2D r;
    Gun gun;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        r = gameObject.GetComponent<Rigidbody2D>();


        gun = GunList.getFirstGun();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gun = gun.child1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gun = gun.child2;
        }
    }

    void Shoot()
    {
        for (int i = 0; i < gun.bullets; i++)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            

            bullet.GetComponent<Bullet>().speed = gun.bulletSpeed;
            bullet.GetComponent<Bullet>().damage = gun.damage;
            bullet.GetComponent<Bullet>().angle = gun.angle;




        }
        gun.fireTimer = 0;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float rotSpeed = Time.fixedDeltaTime * 200;
        float moveSpeed = Time.fixedDeltaTime * 100;
        if (Input.GetKey(KeyCode.Q)){
            r.AddTorque(rotSpeed, ForceMode2D.Force);
            
        }
        if (Input.GetKey(KeyCode.E))
        {
            r.AddTorque(-rotSpeed, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.W))
        {
            r.AddRelativeForce(new Vector2(0, moveSpeed ), ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.S))
        {
           
            r.AddRelativeForce(new Vector2(0, -moveSpeed), ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            r.AddRelativeForce(new Vector2( -moveSpeed, 0), ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {

            r.AddRelativeForce(new Vector2( moveSpeed, 0), ForceMode2D.Force);
        }



        gun.fireTimer += Time.fixedDeltaTime;
        if (Input.GetKey(KeyCode.Space) && gun.fireTimer > gun.fireRate)
        {
            Shoot();
        }




        
    }
}
