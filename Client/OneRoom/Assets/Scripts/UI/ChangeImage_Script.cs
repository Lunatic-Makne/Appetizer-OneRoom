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

    private void ChangeSprite(Int32 frame)
    {
        Debug.Log(string.Format("ChangeSprite frame[{0}]", frame));

        var image = GetComponent<Image>();
        if (image == null) return;

        image.sprite = ImageInfos[frame].sprite;
    }

    [SerializeField]
    public bool ChangeStreak = false;

    [SerializeField]
    public float ChangeImageDelaySec = 0.0f;

    private IEnumerator ChangeImageStreak()
    {
        while (true)
        {
            CurrentIndex++;

            if (CurrentIndex >= ImageInfos.Count)
            {
                if (OptionType == EOptionType.DISPOSE_WHEN_END)
                {
                    if (ParentObject != null)
                    {
                        ParentObject.SetActive(false);
                    }
                }
                break;
            }

            ChangeSprite(CurrentIndex);
            yield return new WaitForSeconds(ChangeImageDelaySec);
        }
    }

    public void OnClick()
    {
        if (GetComponent<Image>() != null)
        {
            if (ChangeStreak)
            {
                StartCoroutine(ChangeImageStreak());
            }
            else
            {
                // Change To Next Image
                if (CurrentIndex + 1 < ImageInfos.Count)
                {
                    CurrentIndex = CurrentIndex + 1;

                    ChangeSprite(CurrentIndex);
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
}
