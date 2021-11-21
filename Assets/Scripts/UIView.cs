using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIView : MonoBehaviour
{
    [SerializeField] private GameObject _textGame;

    private void Awake()
    {
        _textGame.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (Input.touchCount > 0)
            _textGame.SetActive(false);
    }

}
