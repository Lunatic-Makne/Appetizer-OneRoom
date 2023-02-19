using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ch83_Script : MonoBehaviour
{
    public enum ESubSceneType
    {
        ROOM,
        HALLWAY,
        TOILET,
    }

    [System.Serializable]
    public class SubSceneDic : CustomDic.SerializableDictionary<ESubSceneType, GameObject>
    {
    }

    public SubSceneDic SceneDic;

    public ESubSceneType LastSceneType;

    public void ChangeSubScene(ESubSceneType sceneType)
    {
        if (SceneDic.ContainsKey(LastSceneType))
        {
            SceneDic[sceneType].SetActive(false);
        }

        if (SceneDic.ContainsKey(sceneType))
        {
            SceneDic[sceneType].SetActive(true);
            LastSceneType = sceneType;
        }
        else
        {
            // �� ��ü ������ ���. ���� ���� �ٽ� Ȱ��ȭ ��Ų��.
            if (SceneDic.ContainsKey(LastSceneType))
            {
                SceneDic[sceneType].SetActive(true);
            }
        }
    }

    private void OnEnable()
    {
        ChangeSubScene(LastSceneType);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
