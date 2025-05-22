using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float normalSpeed = 4f;
    public float fastSpeed = 6f;

    private float currentSpeed;

    void Start()
    {
        currentSpeed = normalSpeed;
    }

    void Update()
    {
        // Segue o personagem
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
    }

    public void IncreaseSpeed()
    {
        currentSpeed = fastSpeed;
    }

    public void ResetSpeed()
    {
        currentSpeed = normalSpeed;
    }
}