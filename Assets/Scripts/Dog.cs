using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public GameObject Food;
    void Start()
    {
        InvokeRepeating("MakeFood", 0f, 0.5f);
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = mousePos.x;
        if (x > 9.4f) x = 9.4f;
        if (x < -9.4f) x = -9.4f;
        transform.position = new Vector2(x, transform.position.y);
    }

    void MakeFood()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        Instantiate(Food, new Vector2(x, y + 2), Quaternion.identity);
    }
}
