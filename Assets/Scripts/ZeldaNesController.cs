using UnityEngine;
using System.Collections;

public class ZeldaNesController : MonoBehaviour
{

    public float Speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical) > 0)
        {
            Vector3 newPosition = transform.position;
            newPosition.x += horizontal * Speed * Time.deltaTime;
            newPosition.y += vertical * Speed * Time.deltaTime;
            transform.position = newPosition;
        }
    }
}
