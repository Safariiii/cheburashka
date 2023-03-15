using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{

    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private Rigidbody2D bullet;
    [SerializeField] private float timeBetweenShots = 1f;
    private float bulletDelay = 0.1f;
    private float timeLeft = 0f;
    private bool canShoot = true;

    void Start() {
        timeLeft = timeBetweenShots;
    }
     
     void Fire()
     {
         Rigidbody2D bulletClone = (Rigidbody2D) Instantiate(bullet, transform.position, transform.rotation);
         bulletClone.velocity = new Vector2(bulletSpeed, 0);
     }
 
     void Update () 
     {
        if (!canShoot) {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0) {
                canShoot = true;
                timeLeft = timeBetweenShots;
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && canShoot) {
            StartCoroutine(ExampleCoroutine());
            canShoot = false;
        }
        
     }

     IEnumerator ExampleCoroutine()
    {
        Fire();
        yield return new WaitForSeconds(bulletDelay);
        Fire();
        yield return new WaitForSeconds(bulletDelay);
        Fire();
    }
}
