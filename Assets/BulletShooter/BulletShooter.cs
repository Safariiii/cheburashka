using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

namespace MoreMountains.InfiniteRunnerEngine {
public class BulletShooter : MonoBehaviour
{

    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private Rigidbody2D bullet;
    [SerializeField] private float timeBetweenShots = 1f;
    public GameObject Explosion;
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
            StartCoroutine(FireBullets());
            canShoot = false;
        }
        
     }

     void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject explosion = (GameObject)Instantiate(Explosion);
	        explosion.transform.position = new Vector3(transform.GetComponent<Renderer>().bounds.min.x, transform.GetComponent<Renderer>().bounds.center.y,0);
	        MMAnimatorExtensions.UpdateAnimatorBoolIfExists(explosion.GetComponent<Animator>(), "Explode", true);
			// we turn the object inactive so it can be instantiated again 
	        other.gameObject.SetActive(false);
        }
    }

    private IEnumerator FireBullets()
    {
        Fire();
        yield return new WaitForSeconds(bulletDelay);
        Fire();
        yield return new WaitForSeconds(bulletDelay);
        Fire();
    }
}

}

