using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenue : MonoBehaviour
{
  public void PlayButton()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

  }
  public void QuitGame()
  {
    Application.Quit();
  }
}
