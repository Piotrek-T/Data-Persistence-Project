using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public GameObject placeholder;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     
    // }
    //
    // // Update is called once per frame
    // void Update()
    // {
    //     
    // }
    
    public void StartNew()
    {
        if (MainManager.Instance.GetPlayerName() != null)
        {
            SceneManager.LoadScene(1);
        }
        // else
        // {
        //     placeholder.GetComponents<>()
        // }
    }
    
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
        
        MainManager.Instance.SaveScore(); 
    }
    
}
