using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV_Script : MonoBehaviour
{
    private int m_ChannelNum { get; set; } = 0;

    private List<int> m_ChannelList = new List<int> {26,34,40,56,89};

    private int m_ChannelIndex { get; set; } = 0;

    public GameObject ChannelIconObject { private get; set; } = null;

    public List<Sprite> m_TVSprites { get; set; } = new List<Sprite>();
    public List<Sprite> m_ChannelIconSprites { get; set; } = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var newChannelNum = m_ChannelList[m_ChannelIndex];
        if (newChannelNum != m_ChannelNum)
        {
            m_ChannelNum = newChannelNum;
            var TVSprite = GetComponent<SpriteRenderer>();
            if (TVSprite != null && m_TVSprites.Count > m_ChannelIndex && m_TVSprites[m_ChannelIndex] != null)
            {
                TVSprite.sprite = m_TVSprites[m_ChannelIndex];
            }

            if (ChannelIconObject != null)
            {
                var channelIconSpriteR = ChannelIconObject.GetComponent<SpriteRenderer>();
                if (channelIconSpriteR != null && m_ChannelIconSprites.Count > m_ChannelIndex && m_ChannelIconSprites[m_ChannelIndex] != null)
                {
                    channelIconSpriteR.sprite = m_ChannelIconSprites[m_ChannelIndex];
                }
            }
        }
    }

    public void UpChannel()
    {
        if (m_ChannelIndex + 1 < m_ChannelList.Count)
        {
            m_ChannelIndex = 0;
        }
        else
        {
            m_ChannelIndex++;
        }
    }

    public void DownChannel()
    {
        if (m_ChannelIndex - 1 < 0)
        {
            m_ChannelIndex = m_ChannelList.Count - 1;
        }
        else
        {
            m_ChannelIndex--;
        }
    }
}
