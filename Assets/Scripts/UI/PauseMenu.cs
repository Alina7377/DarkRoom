using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseWindow;
    [SerializeField] private GameObject _messageWindow;

    private PlayerControl _control;
    private PlayerCharacter _player;

    private bool _isExit;

    private void Awake()
    {
        _control = new PlayerControl();
        _control.UI.PauseMenu.started += context => ActivatePauseMenu();
        _player = GameObject.FindAnyObjectByType<PlayerCharacter>();

    }

    private void OnEnable()
    {
        _control.Enable();
    }

    private void OnDisable() 
    {
        _control.Disable();
    }

    private void ActivatePauseMenu() 
    {
        if (_pauseWindow.activeSelf) ClosePauseMenu();
        else OpenPauseMenu();

    }

    private void OpenPauseMenu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;        
        _player.DiactivateControl();
        _pauseWindow.SetActive(true);
    }

    private void ClosePauseMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _player.ActivateControl();
        _player.SetCursorSetting();
        _pauseWindow.SetActive(false);
    }

    public void OnContinue() 
    {
        ClosePauseMenu();
        // В любом случие выклоючаем окно с сообщением
        _messageWindow.SetActive(false);
    }

    public void OnToMainMenu() 
    {
        _pauseWindow.SetActive(false);
        _messageWindow.SetActive(true);
        _isExit = false;
    }

    public void OnQuit()
    {
        _pauseWindow.SetActive(false);
        _messageWindow.SetActive(true);
        _isExit = true;
    }

    public void OnYes() 
    {
        if (_isExit) Application.Quit();
        else SceneManager.LoadScene("MainMenu");
    }

    public void OnNo() 
    {
        _messageWindow.SetActive(false);
        _pauseWindow.SetActive(true);
    }
}
