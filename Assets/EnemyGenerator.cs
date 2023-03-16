using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    [SerializeField] private Rigidbody2D enemy;

    void OnEnable() {
        GameObject respawn = GameObject.FindWithTag("Enemy");
        if (respawn == null) {
            Rigidbody2D clone = (Rigidbody2D) Instantiate(enemy, new Vector3(), transform.rotation);
        } else {
            respawn.transform.position = new Vector3();
            respawn.transform.rotation = new Quaternion();
            respawn.SetActive(true);
        }
    }
}
