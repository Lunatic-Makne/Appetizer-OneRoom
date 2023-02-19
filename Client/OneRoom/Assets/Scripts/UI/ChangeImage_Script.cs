using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage_Script : MonoBehaviour
{
    [Serializable]
    public class ImageInfo
    {
        public Sprite sprite;
    }

    [SerializeField]
    public List<ImageInfo> ImageInfos;

    private Int32 CurrentIndex = 0;

    public GameObject ParentObject;

    public enum EOptionType
    {
        DISPOSE_WHEN_END,
        REPEAT,
        MAX
    }

    public EOptionType OptionType = EOptionType.MAX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (GetComponent<Image>() != null)
        {
            // Change To Next Image
            if (CurrentIndex + 1 < ImageInfos.Count)
            {
                CurrentIndex = CurrentIndex + 1;

                GetComponent<Image>().sprite = ImageInfos[CurrentIndex].sprite;
            }
            else if (OptionType == EOptionType.DISPOSE_WHEN_END)
            {
                if (ParentObject != null)
                {
                    ParentObject.SetActive(false);
                }
            }
        }
    }
}
