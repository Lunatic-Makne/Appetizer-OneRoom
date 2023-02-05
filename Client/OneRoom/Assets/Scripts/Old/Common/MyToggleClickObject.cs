using UnityEngine;

public class MyToggleClickObject : MonoBehaviour
{
    public GameObject parentObject;
    protected bool is_opened { set; get; } = false;

    public Sprite opened;
    public Sprite closed;
    public bool IsOpened() { return is_opened; }

    protected void Start()
    {
        ChangeSprite();
    }

    public void ChangeSprite()
    {
        var component = parentObject.GetComponent<SpriteRenderer>();
        if (component == null)
        {
            print("SpriteRenderer Component is null");
            return;
        }

        if (is_opened)
        {
            component.sprite = opened;
        }
        else
        {
            component.sprite = closed;
        }
    }

    public virtual void OnClicked()
    {
        is_opened = !is_opened;

        ChangeSprite();
    }
}
