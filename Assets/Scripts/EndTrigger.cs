
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndTrigger : MonoBehaviour
{
    [SerializeField] string triggeringTag;
    [SerializeField] string sceneName;

    void OnTriggerEnter(Collider other)
    {
        if(triggeringTag == other.tag){
            SceneManager.LoadScene(sceneName);
        }
    }
}