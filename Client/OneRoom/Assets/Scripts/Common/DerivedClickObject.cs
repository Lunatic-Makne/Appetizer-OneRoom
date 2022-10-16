using UnityEngine;

public class DerivedClickObject : MonoBehaviour
{
    public GameObject parentObject;

    void Start()
    {
        GetComponent<SpriteRenderer>().forceRenderingOff = true;
    }

    void Update()
    {
        var clickComponent = parentObject.GetComponent<MyClickObject>();
        if (clickComponent != null)
        {
            if (clickComponent.IsOpened() && GetComponent<SpriteRenderer>().forceRenderingOff == true)
            {
                GetComponent<SpriteRenderer>().forceRenderingOff = false;
            }
            else if (!clickComponent.IsOpened() && !GetComponent<SpriteRenderer>().forceRenderingOff)
            {
                GetComponent<SpriteRenderer>().forceRenderingOff = true;
            }
        }
    }
}