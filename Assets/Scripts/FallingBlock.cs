using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public Vector2 speedMinMax;
    float offScreenPosition;

    // Start is called before the first frame update
    void Start()
    {
        offScreenPosition = -Camera.main.orthographicSize - transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Mathf.Lerp(speedMinMax.x, speedMinMax.x, Difficulty.GetDifficultyPercent());
        transform.Translate(speed * Time.deltaTime * Vector3.down, Space.Self);

        if (transform.position.y < offScreenPosition)
        {
            Destroy(gameObject);
        }

    }
}
