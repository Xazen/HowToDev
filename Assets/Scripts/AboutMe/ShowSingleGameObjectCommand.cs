using UnityEngine;
using System.Collections;

public class ShowSingleGameObjectCommand : SlideCommand
{

    public GameObject GameObjectToShow;

    public void Start()
    {
        GameObjectToShow.SetActive(false);
    }

    public override void Execute()
    {
        base.Execute();
        GameObjectToShow.SetActive(true);
    }
}
