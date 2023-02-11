using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomDic;
using UnityEngine.UIElements;

public class TV_View_Script : MonoBehaviour
{
    public enum EChannel
    {
        CH_26,
        CH_34,
        CH_40,
        CH_56,
        CH_83,
        CH_89,
    }

    [System.Serializable]
    public class TVSceneDic : CustomDic.SerializableDictionary<EChannel, GameObject>
    {
    }

    public TVSceneDic SceneDic;

    [SerializeField]
    private EChannel channel = EChannel.CH_26;

    public void Open()
    {
        EnableCurrentScene();
    }

    public void Close()
    {
        DisableCurrentScene();
    }

    private void EnableCurrentScene()
    {
        GameObject scene;
        if (SceneDic.TryGetValue(channel, out scene))
        {
            scene.SetActive(true);
        }
    }

    private void DisableCurrentScene()
    {
        GameObject scene;
        if (SceneDic.TryGetValue(channel, out scene))
        {
            scene.SetActive(false);
        }
    }

    public void ChannelUp()
    {
        DisableCurrentScene();

        --channel;
        if (Enum.IsDefined(typeof(EChannel), channel) == false)
        {
            channel = EChannel.CH_89;
        }

        EnableCurrentScene();
    }

    public void ChannelDown()
    {
        DisableCurrentScene();

        ++channel;
        if (Enum.IsDefined(typeof(EChannel), channel) == false)
        {
            channel = EChannel.CH_26;
        }

        EnableCurrentScene();
    }

    // Start is called before the first frame update
    void Start()
    {
        channel = EChannel.CH_26;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
