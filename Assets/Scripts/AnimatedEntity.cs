using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedEntity : MonoBehaviour
{
    [HideInInspector]
    public List<Sprite> AnimationCycle;
    
    public float Framerate = 12f;//Animation frames per second
    public SpriteRenderer sr;

    //Private animation stuff
    private float animationTimer;//Current number of seconds since last animation frame update
    private float animationTimerMax;//Max number of seconds for each frame, defined by Framerate
    protected int index;//Current index in the AnimationCycle


    //Set up logic for animation stuff
    protected void AnimationSetup()
    {
        animationTimerMax = 1.0f / ((float)(Framerate));
        index = 0;
    }

    //Animation update
    protected void AnimationUpdate()
    {
        animationTimer += Time.deltaTime;
        if (animationTimer > animationTimerMax)
        {
            animationTimer = 0;
            index++;

            if (AnimationCycle.Count == 0 || index >= AnimationCycle.Count)
            {
                index = 0;
            }
            if (AnimationCycle.Count > 0)
            {
                sr.sprite = AnimationCycle[index];
            }

        }
    }
}

