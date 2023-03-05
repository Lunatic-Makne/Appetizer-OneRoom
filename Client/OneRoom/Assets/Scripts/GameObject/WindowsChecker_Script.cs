using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsChecker_Script : MonoBehaviour
{

    [Serializable]
    public class WindowInfo
    {
        public GameObject Window;
        public bool AnswerToggleStatus = false;
    }

    [SerializeField]
    public List<WindowInfo> windows = new List<WindowInfo>();

    private bool clear = false;

    [SerializeField]
    public GameObject LinkedObject = null;

    // Start is called before the first frame update
    void Start()
    {
        int idx = 0;
        foreach (var info in windows)
        {
            do
            {
                if (info.Window == null)
                {
                    Debug.Assert(false, string.Format("object index[{0}] is null", idx));
                    break;
                }

                if (info.Window.GetComponent<ToggleImage_Script>() == null)
                {
                    Debug.Assert(false, string.Format("[{0}] object hasn't ToggleImage_Script", info.Window.name));
                    break;
                }
            } while (false);

            ++idx;
        }

        if (LinkedObject)
        {
            LinkedObject.SetActive(clear);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (clear) return;

        bool check = true;

        foreach (var info in windows)
        {
            var script = info.Window.GetComponent<ToggleImage_Script>();
            if (script)
            {
                if (info.AnswerToggleStatus != script.status)
                {
                    check = false;
                }
            }
            else
            {
                check = false;
                Debug.Assert(false, string.Format("[{0}] object hasn't ToggleImage_Script"));
            }
        }

        if (check)
        {
            if (LinkedObject)
            {
                LinkedObject.SetActive(true);
            }
        }
    }
}
