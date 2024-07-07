using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Tools for development stage.
/// </summary>
public class DeveloperScript : MonoBehaviour
{
  [Tooltip("Shift + R = Restart")]
  public bool restartGameEnabled = true;

  void Start()
  {
    if (!Application.isEditor)
    {
      Destroy(gameObject);
    }
  }

  void Update()
  {
    if (restartGameEnabled && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.R))
    {
      //  Restart the game
      SceneManager.LoadScene(0);
    }
  }
}
