using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleImage_Script : MonoBehaviour
{
    [SerializeField]
    public Sprite OnImage;
    [SerializeField]
    public Sprite OffImage;

    private bool status { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClicked()
    {
        status = !status;

        var image = GetComponent<Image>();
        if (image != null)
        {
            if (status)
            {
                image.sprite = OnImage;
            }
            else
            {
                image.sprite= OffImage;
            }
        }
    }
}
