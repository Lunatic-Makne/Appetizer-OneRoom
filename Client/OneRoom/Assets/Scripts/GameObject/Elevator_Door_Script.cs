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
    private Int32 CurrentFloor = 1;

    private bool DoingAction = false;
    private bool Blinking = false;

    private void ChangeSprite(Int32 frame)
    {
        print(string.Format("ChangeSprite frame[{0}]", frame));

        var image = GetComponent<Image>();
        if (image == null) return;

        image.sprite = SpriteList[frame].sprite;
    }

    private IEnumerator OpenDoor()
    {
        print("OpenDoor Start");

        while (true)
        {
            if (Blinking)
            {
                yield return null;
                continue;
            }

            if (DisplayFloorObject.activeSelf == false) 
            { 
                DisplayFloorObject.SetActive(true);
            }

            DoorFrame++;

            if (DoorFrame >= SpriteList.Count)
            {
                DoorFrame = SpriteList.Count - 1;
                print("OpenDoor End");

                yield return new WaitForSeconds(DoorOpenDuration);

                StartCoroutine("CloseDoor");
                yield break;
            }

            ChangeSprite(DoorFrame);

            yield return new WaitForSeconds(DoorSpeed);
        }
    }

    private IEnumerator CloseDoor()
    {
        print("CloseDoor Start");

        while(true)
        {
            DoorFrame--;

            if (DoorFrame < 0)
            {
                DoorFrame = 0;
                print("CloseDoor End");
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
        print("Blink Start");
        Blinking = true;
        DisplayFloorObject.SetActive(false);

        for (int i = 0; i < BlinkCount; i++)
        {
            gameObject.SetActive(!gameObject.activeSelf);
            yield return new WaitForSeconds(BlinkSpeed);
            gameObject.SetActive(!gameObject.activeSelf);
            yield return new WaitForSeconds(BlinkSpeed);
        }

        gameObject.SetActive(false);
        Blinking = false;
    }

    private void UpdateDisplayPannel()
    {
        var script = DisplayFloorObject.GetComponent<Elevator_Display_Pannel_Script>();
        if (script != null)
        {
            script.OnFloorButtonClicked(CurrentFloor);
        }
    }

    public void OnFloorButtonSelected(Int32 floor_button)
    {
        if (DoingAction) { return; }

        print(string.Format("Button Clicked: {0}", floor_button));

        DoingAction = true;

        if (floor_button > CurrentFloor)
        {
            StartCoroutine("BlinkImpl", UpArrowObject);
        }
        else if (CurrentFloor > floor_button)
        {
            StartCoroutine("BlinkImpl", DownArrowObject);
        }

        StartCoroutine("OpenDoor");

        CurrentFloor = floor_button;

        UpdateDisplayPannel();
    }
}
