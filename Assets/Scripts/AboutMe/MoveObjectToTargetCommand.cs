using UnityEngine;
using System.Collections;

public class MoveObjectToTargetCommand : SlideCommand
{
    public Transform CurrentTransform;
    public Transform TargetTransform;
    public float Speed = 5;
    public float Accuracy = 0.01f;

    private bool _shouldMove = false;

    public override void Execute()
    {
        base.Execute();
        _shouldMove = true;
    }

    public void Update()
    {
        float distance = Vector3.Distance(CurrentTransform.position, TargetTransform.position);

        if (distance > Accuracy && _shouldMove)
        {
            CurrentTransform.position = Vector3.MoveTowards(CurrentTransform.position, TargetTransform.position, Time.deltaTime * Speed);
            if (distance < Accuracy)
            {
                _shouldMove = false;
            }
        }
    }
}
