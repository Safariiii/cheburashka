using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

namespace MoreMountains.InfiniteRunnerEngine {
public class BulletShooter : MonoBehaviour
{

    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float timeBetweenShots = 1f;
    private float bulletDelay = 0.1f;
    private float timeLeft = 0f;
    private bool canShoot = true;
    private AudioSource fireSound;

    void Start() {
        timeLeft = timeBetweenShots;
        fireSound = GetComponent<AudioSource>();
    }
     
     void Fire()
     {
        // 
        Vector3 position = transform.position;
        float offset = UnityEngine.Random.Range(0f, 0.2f);
        Vector3 newPosition = new Vector3(position.x, position.y - offset, position.z);
        GameObject bulletClone = (GameObject) Instantiate(bullet, newPosition, transform.rotation);
        bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
        bulletClone.GetComponent<Renderer>().sortingOrder = 9;
        StartCoroutine(PlaySound());
     }

     private IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(0);
        fireSound.Play();
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

