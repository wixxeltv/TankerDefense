using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public void Reset()
    {
        EnemyCounter.ResetCounter();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
