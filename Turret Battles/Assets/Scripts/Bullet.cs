using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float moveSpeed;

    void Update() {
        transform.position += transform.right * moveSpeed * Time.deltaTime;
    }
}
