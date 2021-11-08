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

    [HideInInspector] public string team;
    [HideInInspector] public Color teamColor;

    void Start() {
        GameObject turretBase = transform.Find("Base").gameObject;
        SpriteRenderer turretBaseSprite = turretBase.GetComponent<SpriteRenderer>();

        turretBaseSprite.color = teamColor;
    }

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

            GameObject bulletClone = (GameObject) Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            Bullet bulletScript = bulletClone.GetComponent<Bullet>();

            bulletScript.team = team;
            bulletScript.teamColor = teamColor;

            magazine--;
            yield return new WaitForSeconds(0.0625f);
        }

        isShooting = false;

        if (magazine <= 0)
            magazine = 1;
    }
}
