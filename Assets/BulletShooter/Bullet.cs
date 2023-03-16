using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

namespace MoreMountains.InfiniteRunnerEngine {
public class Bullet : MonoBehaviour
{

    private AudioSource fireSound;

    void Start() {
        fireSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            BoxCollider2D enemy = other.gameObject.GetComponent<BoxCollider2D>();
            if (enemy.isTrigger == false) {
                fireSound.Play();
                Animator animator = other.gameObject.GetComponent<Animator>();
                animator.SetTrigger("death");
                enemy.isTrigger = true;
                other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(15, 0);
                //StartCoroutine(FireBullets(other.gameObject));
             }
        }
    }
    private IEnumerator FireBullets(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<MMPoolableObject>().Destroy();
    }
}

}

