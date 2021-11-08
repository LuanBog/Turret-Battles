using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public float rotationSpeed;
    public float topRotationBorder;
    public float bottomRotationBorder;
    private bool reverse;

    public GameObject bullet;
    public Transform shootPoint;
    public int magazine = 1;
    public bool isShooting = false;

    void Update() {
        // Rotation
        float inspectorZ = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).z;

        if (inspectorZ >= topRotationBorder)
        {
            reverse = true;
        }
        else if (inspectorZ <= bottomRotationBorder)
        {
            reverse = false;
        }

        Vector3 rotation;

        if (reverse)
            rotation = new Vector3(0f, 0f, -rotationSpeed * Time.deltaTime);
        else
            rotation = new Vector3(0f, 0f, rotationSpeed * Time.deltaTime);

        transform.Rotate(rotation);
    }

    public void Shoot() {
        StartCoroutine(ShootEnumerator());
    }

    IEnumerator ShootEnumerator() {
        while (magazine > 0) {
            isShooting = true;

            Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            magazine--;
            yield return new WaitForSeconds(0.125f);
        }

        isShooting = false;

        if (magazine <= 0)
            magazine = 1;
    }
}
