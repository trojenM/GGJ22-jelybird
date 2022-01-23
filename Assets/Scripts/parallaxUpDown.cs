using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxUpDown : MonoBehaviour
{
    public GameObject BackgroundBir;
    public GameObject BackgroundIki;

    Rigidbody2D fizikBir;
    Rigidbody2D fizikIki;
    Vector3 startPos;
    Vector3 startPos2;
    float uzunluk = 0;

    public float hiz = 6;
    void Start()
    {
        fizikBir = BackgroundBir.GetComponent<Rigidbody2D>();
        fizikIki = BackgroundIki.GetComponent<Rigidbody2D>();

        fizikBir.velocity = new Vector2(-hiz, 0);
        fizikIki.velocity = new Vector2(-hiz - 1, 0);

        startPos = new Vector3(BackgroundBir.GetComponent<BoxCollider2D>().size.x,
            BackgroundBir.transform.position.y,
            BackgroundBir.transform.position.z);
        startPos2 = new Vector3(BackgroundIki.GetComponent<BoxCollider2D>().size.x,
            BackgroundIki.transform.position.y,
            BackgroundIki.transform.position.z);
        uzunluk = BackgroundBir.GetComponent<BoxCollider2D>().size.x;
    }


    void FixedUpdate()
    {

        repeat();
        //speedUp();
    }

    private void repeat()
    {
        fizikBir.velocity = new Vector2(-hiz, 0);
        fizikIki.velocity = new Vector2(-hiz - 1, 0);
        if (BackgroundBir.transform.position.x <= -uzunluk/2)
        {
            BackgroundBir.transform.position += new Vector3(uzunluk * 2, 0);
        }

        if (BackgroundIki.transform.position.x <= -uzunluk/2)
        {
            BackgroundIki.transform.position += new Vector3(uzunluk * 2, 0);
        }
    }
}
