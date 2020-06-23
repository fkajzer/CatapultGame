﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition;

    private void Awake() {
        _initialPosition = transform.position;
    }

    private void Update() {
        if (transform.position.y > 10) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnMouseDown() {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseUp() {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * 1000);
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    private void OnMouseDrag() {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = newPosition;
    }
}
