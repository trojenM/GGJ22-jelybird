using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    float FPS = 35f;
    public Sprite[] frames;
    private SpriteRenderer outputRenderer;
    private float secondsToWait;
 
    private int currentFrame;
    private bool stopped = false;
    
    [SerializeField] private float animSpeedMultiplier = 10f;
 
    public void Awake () {
 
        outputRenderer = this.GetComponent<SpriteRenderer>();
 
        currentFrame = 0;
        if(FPS > 0) 
            secondsToWait = 1/FPS * animSpeedMultiplier;
        else 
            secondsToWait = 0f;
    }
 
    public void Play(bool reset = false) {
 
        if(reset) {
            currentFrame = 0;
        }
 
        stopped = false;
        outputRenderer.enabled = true;
 
        if(frames.Length > 1) {
            Animate();
        } else if(frames.Length > 0) {
            outputRenderer.sprite = frames[0];
        }
    }
 
    public virtual void Animate() {
        CancelInvoke("Animate");
        if(currentFrame >= frames.Length) {
             
            currentFrame = 0;
 
        }
 
        outputRenderer.sprite = frames[currentFrame];
 
        if(!stopped) {
            currentFrame++;
        }
 
        if(!stopped && secondsToWait > 0) {
            Invoke("Animate", secondsToWait);
        }
    }
 
    void Start ()
    {
        Play();
    }
}

