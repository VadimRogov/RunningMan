using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject _startMenu;
    [SerializeField] TextMeshProUGUI _levelText;
    [SerializeField] GameObject _finishWindow;
    [SerializeField] CoinManager _coinManager;

    private void Start() 
    {
        _levelText.text = SceneManager.GetActiveScene().name;
    }
    public void Play()
    {
        _startMenu.SetActive(false);
        FindFirstObjectByType<PlayerBehaviour>().Play();
    }

    public void ShowFinishWindow()
    {
        _finishWindow.SetActive(true);
    }

    public void NextLevel()
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;
        if(next < SceneManager.sceneCountInBuildSettings) {

            _coinManager.SaveToProgress();

            SceneManager.LoadScene(next);
        }
        
    }
}
