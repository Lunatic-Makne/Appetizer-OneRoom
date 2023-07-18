using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut_Script : MonoBehaviour
{
    public GameObject TargetObject;
    public float AlphaSpeed = 0.0f;
    public float TickSpeed = 0.0f;

    void DefaultFadeInBeforeCallback()
    {
        TargetObject?.SetActive(true);
    }

    void DefaultFadeOutAfterCallback()
    {
        TargetObject?.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (BeforeFadeInCallback == null)
        {
            BeforeFadeInCallback = new FadeCallback(DefaultFadeInBeforeCallback);
        }

        if (AfterFadeOutCallback == null)
        {
            AfterFadeOutCallback = new FadeCallback(DefaultFadeOutAfterCallback);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAlpha(float alpha)
    {
        alpha = Math.Min(Math.Max(alpha, 0.0f), 1.0f);

        var images = TargetObject.GetComponentsInChildren<Image>();

        foreach(var image in images)
        {
            Color color = image.color;
            color.a = alpha;
            image.color = color;
        }
    }

    public IEnumerator FadeInImpl()
    {
        float alpha = 0.0f;
        while (alpha < 1.0f) 
        {
            alpha += AlphaSpeed;
            SetAlpha(alpha);

            yield return new WaitForSeconds(TickSpeed);
        }

        if (AfterFadeInCallback != null) { AfterFadeInCallback(); }
    }

    public IEnumerator FadeOutImpl()
    {
        float alpha = 1.0f;
        while (alpha > 0.0f)
        {
            alpha -= AlphaSpeed;
            SetAlpha(alpha);

            yield return new WaitForSeconds(TickSpeed);
        }

        if (AfterFadeOutCallback != null) { AfterFadeOutCallback(); }
    }

    public void FadeIn()
    {
        if (BeforeFadeInCallback != null) { BeforeFadeInCallback(); }
        StartCoroutine(FadeInImpl());
    }

    public void FadeOut() 
    {
        if (BeforeFadeOutCallback != null) { BeforeFadeOutCallback(); }
        StartCoroutine(FadeOutImpl());
    }

    public delegate void FadeCallback();

    public FadeCallback BeforeFadeInCallback { get; set; }
    public FadeCallback AfterFadeInCallback { get; set; }

    public FadeCallback BeforeFadeOutCallback { get; set; }
    public FadeCallback AfterFadeOutCallback { get; set; }
}
