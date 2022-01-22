using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxRightLeft : MonoBehaviour
{
    public GameObject BackgroundBýr;
    public GameObject BackgroundIký;

    Rigidbody2D fizikBir;
    Rigidbody2D fizikIki;
    Vector3 startPos;
    Vector3 startPos2;
    float uzunluk = 0;

    public float hiz = 8;
    void Start()
    {
        fizikBir = BackgroundBýr.GetComponent<Rigidbody2D>();
        fizikIki = BackgroundIký.GetComponent<Rigidbody2D>();

        fizikBir.velocity = new Vector2(-hiz, 0);
        fizikIki.velocity = new Vector2(-hiz - 1, 0);

        startPos = new Vector3(BackgroundBýr.GetComponent<BoxCollider2D>().size.x,
                                BackgroundBýr.transform.position.y,
                                BackgroundBýr.transform.position.z);
        startPos2 = new Vector3(BackgroundIký.GetComponent<BoxCollider2D>().size.x,
                                BackgroundIký.transform.position.y,
                                BackgroundIký.transform.position.z);
        uzunluk = BackgroundBýr.GetComponent<BoxCollider2D>().size.x;
    }


    void FixedUpdate()
    {

        repeat();
        //speedUp();
    }

    private void repeat()
    {

        if (BackgroundBýr.transform.position.x <= -uzunluk - 3f)
        {
            Debug.Log(BackgroundBýr.transform.position.y);
            BackgroundBýr.transform.position += new Vector3(uzunluk * 3, 0);
        }

        if (BackgroundIký.transform.position.x <= -uzunluk - 3f)
        {
            BackgroundIký.transform.position += new Vector3(uzunluk * 3, 0);
        }
    }
}
