using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door_Script : MonoBehaviour
{
    [SerializeField]
    public Sprite OpenDoorSprite = null;

    [SerializeField]
    public GameObject PasswordPannel;

    [SerializeField]
    public bool Opened = false;

    [SerializeField]
    public GameObject ParentObject;

    [SerializeField]
    public GameObject LinkedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        Console.Write("Object[{0}] Clicked.", name);
    }

    public void OnClick()
    {
        if (Opened == false)
        {
            var correct = true;
            if (PasswordPannel != null && PasswordPannel.GetComponent<PasswordPannel_Script>() != null)
            {
                correct = PasswordPannel.GetComponent<PasswordPannel_Script>().IsCorrect();
            }

            if (correct)
            {
                if (GetComponent<Image>() != null && OpenDoorSprite != null)
                {
                    GetComponent<Image>().sprite = OpenDoorSprite;    
                }

                // 문이 열릴 때 패스워드 패널이 열려 있으니 닫아준다.
                if (PasswordPannel != null && PasswordPannel.activeSelf == true)
                {
                    PasswordPannel.SetActive(false);
                }

                Opened = true;
            }
            else
            {
                if (PasswordPannel != null)
                {
                    if (PasswordPannel.activeSelf == true)
                    {
                        PasswordPannel.SetActive(false);
                    }
                    else
                    {
                        PasswordPannel.SetActive(true);
                    }
                }
            }
        }
        else
        {
            // 오픈 이후엔 문을 통해 다른 씬으로 넘어가야 한다.
            ParentObject.SetActive(false);
            LinkedObject.SetActive(true);
        }
    }
}
