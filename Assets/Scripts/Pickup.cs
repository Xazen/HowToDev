﻿using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
	public void OnCollisionEnter(Collision col)
    {
        gameObject.SetActive(false);
    }
}
