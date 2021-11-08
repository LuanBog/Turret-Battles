﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour {

    public Turret turret;
    public Transform ballRespawnPointOne;
    public Transform ballRespawnPointTwo;

    public PadType type;

    void RespawnBall(Transform ball) {
        float randomX = Random.Range(ballRespawnPointOne.position.x, ballRespawnPointTwo.position.x);
        Vector2 newPosition = new Vector2(randomX, ballRespawnPointOne.position.y);

        ball.position = newPosition;
    }

    void OnTriggerEnter2D(Collider2D hit) {
        if (hit.tag == "Ball") {
            RespawnBall(hit.transform);

            if (type == PadType.Shoot) {
                if (!turret.isShooting)
                    turret.Shoot();
            } else if (type == PadType.Magazine) {
                turret.magazine *= 2;
            }
        }
    }
}
