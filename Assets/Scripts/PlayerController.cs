using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event System.Action OnPlayerDeath;
    public float speed = 5;
    float screenHalfWidthWorldUnits;
    float halfPlayerWidth;
    float positiveWrapPosition;

    // Start is called before the first frame update
    void Start()
    {
        halfPlayerWidth = transform.localScale.x / 2;
        screenHalfWidthWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
        positiveWrapPosition = screenHalfWidthWorldUnits + halfPlayerWidth;
    }

    // Update is called once per frame
    void Update()
    {

        

        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;

        transform.Translate(velocity * Time.deltaTime * Vector2.right);

        if (transform.position.x > positiveWrapPosition)
        {
            transform.position = new Vector2(-positiveWrapPosition, transform.position.y);
        }
        else if (transform.position.x < -positiveWrapPosition)
        {
            transform.position = new Vector2(positiveWrapPosition, transform.position.y);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Falling Block"))
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }
}
