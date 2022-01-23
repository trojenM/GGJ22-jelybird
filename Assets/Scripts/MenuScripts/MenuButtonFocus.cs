using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtonFocus : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private bool isHovering = false;
    private float initialSize;
    [SerializeField] private float sizeDelte = 3f;
    [SerializeField] private float expandMul = 1f;
    
    private AudioSource audioS;
    [SerializeField] private AudioClip[] audioClips;
    void Awake()
    {
        audioS = GetComponentInParent<AudioSource>();
        initialSize = transform.localScale.x;
    }

    void Update()
    {
        if (isHovering)
        {
            transform.localScale = Vector3.one * sizeDelte;
        }
        else if (!isHovering && transform.localScale.x > initialSize)
        {
            transform.localScale -= Vector3.one * expandMul;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        audioS.PlayOneShot(audioClips[0]);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioS.PlayOneShot(audioClips[1]);
    }
}
