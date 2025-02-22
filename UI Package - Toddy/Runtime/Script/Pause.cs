using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private CanvasGroup _pausePanel;
    [SerializeField] private CanvasGroup _HUDPanel;
    
    void Start()
    {
        _pausePanel.alpha = 0;
        _HUDPanel.alpha = 1;
        _pausePanel.gameObject.SetActive(false);
        _HUDPanel.gameObject.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                _pausePanel.LeanAlpha(0, 0.4f).setOnComplete( () => {
                    _pausePanel.gameObject.SetActive(false);
                    _HUDPanel.gameObject.SetActive(true);
                    _HUDPanel.LeanAlpha(1, 0.4f);
                });
                FPSController.Instance.canMove = true;
                
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                
            }
            else
            {
                _HUDPanel.LeanAlpha(0, 0.4f).setOnComplete(() =>
                {
                    _HUDPanel.gameObject.SetActive(false);
                });
                _pausePanel.gameObject.SetActive(true);
                _pausePanel.LeanAlpha(1, 0.4f).setOnComplete(() =>
                {
                    Time.timeScale = 0;
                });
                FPSController.Instance.canMove = false;
                
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
    
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    
    
}
