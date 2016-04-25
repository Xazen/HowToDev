using UnityEngine;
using System.Collections;

public class ShowMultipleGameObjectsCommand : SlideCommand
{
    public GameObject[] Objects;
    public float delay;

    public void Start()
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            GameObject go = Objects[i];
            go.SetActive(false);
        }
    }

    public override void Execute()
    {
        base.Execute();

        if (delay >= 0)
        {
            StartCoroutine(ShowObjects());
        }
    }

    public IEnumerator ShowObjects()
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            GameObject go = Objects[i];
            go.SetActive(true);

            yield return new WaitForSeconds(delay);
        }
    }
}
