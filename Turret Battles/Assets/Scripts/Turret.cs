using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public float rotationSpeed;
    public GameObject bullet;
    public Transform shootPoint;

    void Start() {

    }

    void Update() {
        // Movement

        Vector3 rotation = new Vector3(0f, 0f, rotationSpeed * Time.deltaTime);

        transform.Rotate(rotation);

        // Shooting

        if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }
    }

    void Shoot() {
        GameObject bulletClone = (GameObject) Instantiate(bullet, shootPoint.position, shootPoint.rotation);
    }
}
