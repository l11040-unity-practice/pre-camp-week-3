using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cat : MonoBehaviour
{
    public RectTransform Front;
    public GameObject HungryCat;
    public GameObject FullCat;

    float _full = 5.0f;
    float _energe = 0.0f;
    bool _isFull = false;

    void Start()
    {
        float x = Random.Range(-12.0f, 12.0f);
        transform.position = new Vector3(x, 30f, 1f);
    }

    void Update()
    {
        if (_energe < _full)
        {
            transform.position += Vector3.down * 0.05f;
            if (transform.position.y < -16.0f)
            {
                GameManager.Instance.GameOver();
            }
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
                if (!_isFull)
                {
                    _isFull = true;
                    HungryCat.SetActive(false);
                    FullCat.SetActive(true);
                    Destroy(gameObject, 5.0f);
                    GameManager.Instance.AddScore();
                }
            }
        }
    }
}
