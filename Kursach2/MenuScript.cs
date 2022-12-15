using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    //public Banner add;

    private void Awake()
    {
        //add.ShowAd();
    }

    public void Play()
    {
        SceneManager.LoadScene(sceneName: "Norm");
    }

}
