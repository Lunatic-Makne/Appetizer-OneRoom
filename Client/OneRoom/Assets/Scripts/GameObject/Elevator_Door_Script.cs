using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct FDoorSprite
{
    [SerializeField]
    public Sprite sprite;
};

public class Elevator_Door_Script : MonoBehaviour
{
    //Start is called before the first frame update
    void Start()
    {
        UpdateDisplayPannel();
    }

    //Update is called once per frame
    void Update()
    {

    }

    [SerializeField]
    private List<FDoorSprite> SpriteList = new List<FDoorSprite>();

    [SerializeField]
    private GameObject DownArrowObject;
    [SerializeField]
    private GameObject UpArrowObject;
    [SerializeField]
    private GameObject DisplayFloorObject;

    private Int32 DoorFrame = 0;

    [SerializeField]
    private float DoorSpeed = 0.5f;
    [SerializeField]
    private float DoorOpenDuration = 3.0f;
    [SerializeField]
    private float BlinkSpeed = 0.5f;
    [SerializeField]
    private Int32 BlinkCount = 3;
    [SerializeField]
    private float DoorOpenDelaySec = 1.0f;

    [SerializeField]
    private Int32 CurrentFloor = 1;

    [SerializeField]
    private GameObject CurrentViewObject;

    [SerializeField]
    private GameObject NextViewObject;
    [SerializeField]
    private Int32 NextViewFloor = 0;

    [SerializeField]
    private List<Int32> AnswerList;

    private Queue<Int32> Inputed = new Queue<Int32>();

    private bool DoingAction = false;

    private void ChangeSprite(Int32 frame)
    {
        Debug.Log(string.Format("ChangeSprite frame[{0}]", frame));

        var image = GetComponent<Image>();
        if (image == null) return;

        image.sprite = SpriteList[frame].sprite;
    }

    public void FadeOutAfterCallbcak()
    {
        CurrentViewObject.SetActive(false);
    }

    public void ArrivedTopFloor()
    {
        var fade_script = CurrentViewObject.GetComponent<FadeInOut_Script>();
        if (fade_script == null) return;

        fade_script.AfterFadeOutCallback = new FadeInOut_Script.FadeCallback(FadeOutAfterCallbcak);
        fade_script.FadeOut();

        DoingAction = false;
    }

    private IEnumerator OpenDoor()
    {
        Debug.Log("OpenDoor Start");

        if (DisplayFloorObject.activeSelf == false)
        {
            DisplayFloorObject.SetActive(true);
        }

        yield return new WaitForSeconds(DoorOpenDelaySec);

        while (true)
        {
            DoorFrame++;

            if (DoorFrame >= SpriteList.Count)
            {
                DoorFrame = SpriteList.Count - 1;
                Debug.Log("OpenDoor End");

                if (CurrentFloor == NextViewFloor)
                {
                    ArrivedTopFloor();
                }
                else
                {
                    yield return new WaitForSeconds(DoorOpenDuration);
                    StartCoroutine("CloseDoor");
                }
                
                yield break;
            }

            ChangeSprite(DoorFrame);

            yield return new WaitForSeconds(DoorSpeed);
        }
    }

    private IEnumerator CloseDoor()
    {
        Debug.Log("CloseDoor Start");

        while(true)
        {
            DoorFrame--;

            if (DoorFrame < 0)
            {
                DoorFrame = 0;
                Debug.Log("CloseDoor End");
                DoingAction = false;
                yield break;
            }

            ChangeSprite(DoorFrame);

            yield return new WaitForSeconds(DoorSpeed);
        }

    }

    private IEnumerator BlinkImpl(object obj)
    {
        GameObject gameObject = obj as GameObject;
        Debug.Log("Blink Start");
        DisplayFloorObject.SetActive(false);

        for (int i = 0; i < BlinkCount; i++)
        {
            gameObject.SetActive(!gameObject.activeSelf);
            yield return new WaitForSeconds(BlinkSpeed);
            gameObject.SetActive(!gameObject.activeSelf);
            yield return new WaitForSeconds(BlinkSpeed);
        }

        gameObject.SetActive(false);
        StartCoroutine("OpenDoor");
    }

    private void UpdateDisplayPannel()
    {
        var script = DisplayFloorObject.GetComponent<Elevator_Display_Pannel_Script>();
        if (script != null)
        {
            script.OnFloorButtonClicked(CurrentFloor);
        }
    }

    private bool CheckAnswer()
    {
        if (Inputed.Count < AnswerList.Count) { return false; }

        var temp_stack = new Queue<Int32>();
        bool result = true;

        foreach(var answer_floor in AnswerList)
        {
            var input = Inputed.Dequeue();
            temp_stack.Enqueue(input);

            if (input != answer_floor)
            {
                result = false;
            }
        }

        Inputed = temp_stack;
        Inputed.Dequeue();

        return result;
    }

    public void OnFloorButtonSelected(Int32 floor_button)
    {
        if (DoingAction) { return; }

        Debug.Log(string.Format("Button Clicked: {0}", floor_button));

        DoingAction = true;

        if (floor_button > CurrentFloor)
        {
            StartCoroutine("BlinkImpl", UpArrowObject);
        }
        else if (CurrentFloor > floor_button)
        {
            StartCoroutine("BlinkImpl", DownArrowObject);
        }
        else
        {
            StartCoroutine("OpenDoor");
        }

        Inputed.Enqueue(floor_button);
        
        if (CheckAnswer())
        {
            floor_button = NextViewFloor;
            NextViewObject.SetActive(true);
        }

        CurrentFloor = floor_button;

        UpdateDisplayPannel();

        
    }
}
