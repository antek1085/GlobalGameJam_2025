using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSettings : MonoBehaviour
{
   [SerializeField] string sceneToLoad;
   public void ExitGame()
   {
      Application.Quit();
   }

   public void PlayGame()
   {
      SceneManager.LoadScene(sceneToLoad);
   }
}
