using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletspawn : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Objectpooling.instance.getpooledobjects();
            if (bullet != null)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
               
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
