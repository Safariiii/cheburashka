using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

namespace MoreMountains.InfiniteRunnerEngine {
public class Bullet : MonoBehaviour
{
		private Vector3 _startPosition;
        [SerializeField] private float maxRange = 10f;

        void Start()
    {
        _startPosition = this.transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            BoxCollider2D enemy = other.gameObject.GetComponent<BoxCollider2D>();
            if (enemy.isTrigger == false) {
                Animator animator = other.gameObject.GetComponent<Animator>();
                animator.SetTrigger("death");
                enemy.isTrigger = true;
                other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(15, 0);
                //StartCoroutine(FireBullets(other.gameObject));
             }
        }
    }

    protected virtual void FixedUpdate()
    {
            var currentPosition = this.transform.position;
            var diffX = Mathf.Abs(currentPosition.x - _startPosition.x);
            if (diffX > maxRange)
                this.gameObject.SetActive(false);
     }
    private IEnumerator FireBullets(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<MMPoolableObject>().Destroy();
    }
}

}

