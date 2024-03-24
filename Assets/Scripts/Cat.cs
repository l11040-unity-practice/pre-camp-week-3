using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public RectTransform Front;
    public GameObject HungryCat;
    public GameObject FullCat;

    float _full = 5.0f;
    float _energe = 0.0f;

    void Start()
    {
        Application.targetFrameRate = 60;
        float x = Random.Range(-13.0f, 13.0f);
        transform.position = new Vector3(x, 30f, 1f);
    }

    void Update()
    {
        if (_energe < _full)
        {
            transform.position += Vector3.down * 0.05f;
        }
        else
        {
            if (transform.position.x < 0)
            {
                transform.position += Vector3.left * 0.05f;
            }
            else
            {
                transform.position += Vector3.right * 0.05f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            if (_energe < _full)
            {
                _energe += 1.0f;
                Front.localScale = new Vector3(_energe / _full, 1.0f, 1.0f);
                Destroy(other.gameObject);
            }
            if (_energe == _full)
            {
                HungryCat.SetActive(false);
                FullCat.SetActive(true);
            }
        }
    }
}
