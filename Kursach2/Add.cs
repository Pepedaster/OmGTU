//using UnityEngine;
//using UnityEngine.Advertisements;

//public class Add : MonoBehaviour
//{
//    [SerializeField] string androidGameID = "5074781";
//    [SerializeField] string iOSGameID = "5061566";
//    [SerializeField] bool testMode = true;
//    private string gameID;

//    private void Awake()
//    {
//        gameID = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSGameID : androidGameID;
//        Advertisement.Initialize(gameID, testMode, this);
//    }


//    public void OnInitializationComplete()
//    {
//        Debug.Log("Инициализация прошла успешно.");
//    }



//}