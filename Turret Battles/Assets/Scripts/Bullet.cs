using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        transform.position += transform.right * moveSpeed * Time.deltaTime;
    }

    void FixedUpdate() {
        // rb.AddForce(transform.up * moveSpeed * Time.fixedDeltaTime);
    }

}
