using UnityEngine;
using System.Collections;

public class CoinBox : MonoBehaviour
{
    public GameObject ObjectToShow;

    public void Start()
    {
        ObjectToShow.SetActive(false);
    }

	void OnCollisionEnter(Collision col)
    {
        ObjectToShow.SetActive(true);
        GetComponent<Animator>().SetTrigger("BounceUp");
    }
}
