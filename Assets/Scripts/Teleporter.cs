using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public int DestinationSceneIndex = -1;

    public void OnTriggerEnter(Collider col)
    {
        if (DestinationSceneIndex != -1)
        {
            SceneManager.LoadScene(DestinationSceneIndex);
        }
    }
}
