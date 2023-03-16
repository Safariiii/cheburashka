using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

namespace MoreMountains.InfiniteRunnerEngine {
public class Bullet : MonoBehaviour
{

    public GameObject Explosion;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            
            GameObject explosion = (GameObject)Instantiate(Explosion);
	        explosion.transform.position = new Vector3(transform.GetComponent<Renderer>().bounds.min.x, transform.GetComponent<Renderer>().bounds.center.y,0);
	        MMAnimatorExtensions.UpdateAnimatorBoolIfExists(explosion.GetComponent<Animator>(), "Explode", true);
			// we turn the object inactive so it can be instantiated again 
	        other.gameObject.SetActive(false);
            // StartCoroutine(SetActiveAgain(other));
        }
    }

    // private IEnumerator SetActiveAgain(Collider2D other)
    // {
    //     yield return new WaitForSeconds(2);
    //     other.gameObject.SetActive(true);
    // }
}

}

