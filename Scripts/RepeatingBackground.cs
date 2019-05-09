using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private float length;
    void OnEnable()
    {
        length = gameObject.transform.localScale.x;
    }

    void Update()
    {
        if (transform.position.x * 2 < -gameObject.transform.localScale.x)
        {
            RepositionBackground();
        }
    }
    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(gameObject.transform.localScale.x, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}

