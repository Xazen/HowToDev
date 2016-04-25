using UnityEngine;
using System.Collections;
using System;

public class ShowSingleGameObjectCommand : SlideCommand
{
    public GameObject GameObjectToShow;
    public float Duration = 0;

    public void Start()
    {
        GameObjectToShow.SetActive(false);
    }

    public override void Execute()
    {
        base.Execute();
        GameObjectToShow.SetActive(true);
        if (Duration > 0)
        {
            StartCoroutine(HideGameObject());
        }
    }

    private IEnumerator HideGameObject()
    {
        yield return new WaitForSeconds(Duration);
        GameObjectToShow.SetActive(false);
    }
}
