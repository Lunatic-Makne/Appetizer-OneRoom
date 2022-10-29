using UnityEngine;

public class DerivedClickObject : MonoBehaviour
{
    public GameObject parentObject;

    void Start()
    {
        if (parentObject != null)
        {
            GetComponent<SpriteRenderer>().forceRenderingOff = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void Update()
    {
        if (parentObject != null)
        {
            var clickComponent = parentObject.GetComponent<MyToggleClickObject>();
            if (clickComponent != null)
            {
                if (clickComponent.IsOpened() && GetComponent<SpriteRenderer>().forceRenderingOff == true)
                {
                    GetComponent<SpriteRenderer>().forceRenderingOff = false;
                    GetComponent<BoxCollider2D>().enabled = true;
                }
                else if (!clickComponent.IsOpened() && !GetComponent<SpriteRenderer>().forceRenderingOff)
                {
                    GetComponent<SpriteRenderer>().forceRenderingOff = true;
                    GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
    }

    public void OnClicked()
    {
        print(string.Format("DerivedClickObject OnClicked called. obj[{0}]", name));
    }
}