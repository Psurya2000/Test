using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnEnable()
    {
        Invoke("HideBullet", 1.0f);
    }
    void HideBullet()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}
