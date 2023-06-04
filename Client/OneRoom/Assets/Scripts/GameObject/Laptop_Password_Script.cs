using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Laptop_Password_Script : MonoBehaviour
{
    public TMP_InputField _InputField;
    public string _Password;
    public GameObject _PrevView;
    public GameObject _NextView;
    public GameObject _ErrorText;

    // Start is called before the first frame update
    void Start()
    {
        _InputField.onSubmit.AddListener(OnPasswordEntered);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCorrect()
    {
        if (_PrevView)
        {
            _PrevView.SetActive(false);
        }

        if (_NextView)
        {
            _NextView.SetActive(true);
        }
    }

    public void OnPasswordEntered(string password)
    {
        Debug.Log(password);

        if (_Password == password)
        {
            OnCorrect();
        }
        else
        {
            _ErrorText.SetActive(true);
        }
    }

    public void PasswordEntered(TMP_InputField inputField)
    {
        Debug.Log(inputField.text);

        if (_Password == inputField.text)
        {
            OnCorrect();
        }
        else
        {
            _ErrorText.SetActive(true);
        }
    }
}
