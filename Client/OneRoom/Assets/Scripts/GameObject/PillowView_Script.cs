using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowView_Script : MonoBehaviour
{
    [SerializeField]
    public GameObject ParentObject;

    public void BeforeFadeIn()
    {
        ParentObject?.SetActive(true);
    }

    public void AfterFadeOut()
    {
        ParentObject?.SetActive(false);
    }

    private void Awake()
    {
        var fade_script = ParentObject?.GetComponent<FadeInOut_Script>();
        if (fade_script != null)
        {
            fade_script.BeforeFadeInCallback = new FadeInOut_Script.FadeCallback(BeforeFadeIn);
            fade_script.AfterFadeOutCallback = new FadeInOut_Script.FadeCallback(AfterFadeOut);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
