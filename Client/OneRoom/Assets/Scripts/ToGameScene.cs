using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToGameScene : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnClick()
    {
        
    }
}
