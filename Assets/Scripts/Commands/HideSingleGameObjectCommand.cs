using UnityEngine;
using System.Collections;

public class HideSingleGameObjectCommand : SlideCommand
{

    public GameObject GameObjectToShow;

    public override void Execute()
    {
        base.Execute();
        GameObjectToShow.SetActive(false);
    }
}
