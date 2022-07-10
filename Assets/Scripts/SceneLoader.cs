using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    private Button _loadButton;

    private void Start()
    {
        _loadButton = GetComponent<Button>();
        _loadButton.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(index, LoadSceneMode.Single);
    }
}