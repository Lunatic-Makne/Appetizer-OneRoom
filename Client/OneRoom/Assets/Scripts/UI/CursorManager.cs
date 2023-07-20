using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class CursorManager : MonoBehaviour
    {
        [SerializeField]
        Sprite HandSprite;
        [SerializeField]
        Sprite CursorSprite;

        void Start()
        {
            
        }

        public void OnMouseOver()
        {
            Cursor.SetCursor(HandSprite.texture, new Vector2(HandSprite.texture.width / 3.0f, 0), CursorMode.Auto);
        }

        public void OnMouseExit()
        {
            Cursor.SetCursor(CursorSprite.texture, new Vector2(0,0), CursorMode.Auto);
        }
    }
}
