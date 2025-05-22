using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float slowSpeed = 2f;
    public float slowDuration = 2f;

    public SnakeController snake; // Referência ao script da serpente

    public int maxHearts = 3;
    private int currentHearts;

    public Image[] hearts; // UI dos corações
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private float currentSpeed;
    private bool isSlowed = false;

    void Start()
    {
        currentSpeed = normalSpeed;
        currentHearts = maxHearts;
    }

    void Update()
    {
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
        UpdateHeartsUI();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (!isSlowed)
            {
                currentHearts--;
                StartCoroutine(SlowDown());
            }
        }
    }

    System.Collections.IEnumerator SlowDown()
    {
        isSlowed = true;
        currentSpeed = slowSpeed;

        if (snake != null)
        {
            snake.IncreaseSpeed();
        }

        yield return new WaitForSeconds(slowDuration);

        currentSpeed = normalSpeed;

        if (snake != null)
        {
            snake.ResetSpeed();
        }

        isSlowed = false;
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHearts)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            hearts[i].enabled = i < maxHearts;
        }
    }
}