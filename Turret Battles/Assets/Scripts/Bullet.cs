using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float moveSpeed;

    [HideInInspector] public string team;
    [HideInInspector] public Color teamColor;

    void Start() {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = teamColor;
    }

    void Update() {
        transform.position += transform.right * moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D hit) {
        if (hit.tag == "Block") {
            Block block = hit.GetComponent<Block>();

            if (block.team != team) {
                Destroy(hit.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
