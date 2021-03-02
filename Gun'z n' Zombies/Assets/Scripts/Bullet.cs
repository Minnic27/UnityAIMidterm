using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;

    public UIText uText;

    void Start()
    {
        uText = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIText>(); // access UIText script
    }

    void FireBullet()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            uText.AddScore(); // access AddScore from UIText
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        FireBullet();
    }
}
