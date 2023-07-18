using UnityEngine;

public class DerivedClickObject : MonoBehaviour
{
    public GameObject parentObject;
    protected bool disabled = false;

    void Start()
    {
        if (parentObject != null)
        {
            disabled = true;
        }
    }

    void Update()
    {
        CheckDisableStatus();

        var spriteRender = GetComponent<SpriteRenderer>();
        var boxCollider = GetComponent<BoxCollider2D>();
        if (disabled)
        {
            if (spriteRender != null) spriteRender.forceRenderingOff = true;
            if (boxCollider != null) boxCollider.enabled = false;
        }
        else
        {
            if (spriteRender != null) spriteRender.forceRenderingOff = false;
            if (boxCollider != null) boxCollider.enabled = true;
        }
    }

    public virtual void OnClicked()
    {
        print(string.Format("DerivedClickObject OnClicked called. obj[{0}]", name));
    }

    protected virtual void CheckDisableStatus()
    {
        if (parentObject != null)
        {
            var clickComponent = parentObject.GetComponent<MyToggleClickObject>();
            if (clickComponent != null)
            {
                if (clickComponent.IsOpened())
                {
                    disabled = false;
                }
                else if (!clickComponent.IsOpened())
                {
                    disabled = true;
                }
            }
        }
    }
}