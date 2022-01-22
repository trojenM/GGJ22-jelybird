using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxRightLeft : MonoBehaviour
{
    public GameObject BackgroundB�r;
    public GameObject BackgroundIk�;

    Rigidbody2D fizikBir;
    Rigidbody2D fizikIki;
    Vector3 startPos;
    Vector3 startPos2;
    float uzunluk = 0;

    public float hiz = 8;
    void Start()
    {
        fizikBir = BackgroundB�r.GetComponent<Rigidbody2D>();
        fizikIki = BackgroundIk�.GetComponent<Rigidbody2D>();

        fizikBir.velocity = new Vector2(-hiz, 0);
        fizikIki.velocity = new Vector2(-hiz - 1, 0);

        startPos = new Vector3(BackgroundB�r.GetComponent<BoxCollider2D>().size.x,
                                BackgroundB�r.transform.position.y,
                                BackgroundB�r.transform.position.z);
        startPos2 = new Vector3(BackgroundIk�.GetComponent<BoxCollider2D>().size.x,
                                BackgroundIk�.transform.position.y,
                                BackgroundIk�.transform.position.z);
        uzunluk = BackgroundB�r.GetComponent<BoxCollider2D>().size.x;
    }


    void FixedUpdate()
    {

        repeat();
        //speedUp();
    }

    private void repeat()
    {

        if (BackgroundB�r.transform.position.x <= -uzunluk - 3f)
        {
            Debug.Log(BackgroundB�r.transform.position.y);
            BackgroundB�r.transform.position += new Vector3(uzunluk * 3, 0);
        }

        if (BackgroundIk�.transform.position.x <= -uzunluk - 3f)
        {
            BackgroundIk�.transform.position += new Vector3(uzunluk * 3, 0);
        }
    }
}
