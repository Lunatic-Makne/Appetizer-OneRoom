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

    [SerializeField]
    private GameObject CloseObject;
    public void BeforeFadeOut()
    {
        var door_script = CloseObject?.GetComponent<Door_Script>();
        if (door_script != null)
        {
            if (door_script.LinkedObject != null)
            {
                door_script.LinkedObject.SetActive(true);
            }
        }
    }

    public void AfterFadeOut()
    {
        DoingAction = false;

        var door_script = CloseObject?.GetComponent<Door_Script>();
        if (door_script != null )
        {
            door_script.OnClick();
        }
    }

    private void Awake()
    {
        var fade_script = ParentObject?.GetComponent<FadeInOut_Script>();
        if (fade_script != null)
        {
            fade_script.BeforeFadeInCallback = new FadeInOut_Script.FadeCallback(BeforeFadeIn);
            fade_script.BeforeFadeOutCallback = new FadeInOut_Script.FadeCallback(BeforeFadeOut);
            fade_script.AfterFadeOutCallback = new FadeInOut_Script.FadeCallback(AfterFadeOut);
        }
    }

    public bool DoingAction { get; set; } = false;
    
    public void OnClose()
    {
        var fade_script = ParentObject?.GetComponent<FadeInOut_Script>();
        if (fade_script != null)
        {
            if (DoingAction == false)
            {
                DoingAction = true;
                fade_script.FadeOut();
            }
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
