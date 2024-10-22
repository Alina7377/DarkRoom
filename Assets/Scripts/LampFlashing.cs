using UnityEngine;

public class LampFlashing : MonoBehaviour, IActivationObjects
{
    [SerializeField] private GameObject  _spotLight;
    [SerializeField] private GameObject _pointLight;
    // Для времени активации/деактивации: x - мин., y - макс. длительность
    [SerializeField] private Vector2 _timeActive;
    [SerializeField] private Vector2 _timeOut;
    [SerializeField] private bool _isActive;


    private float _currentTimeToChange;
    private float _currentTime;

    

    private void Start()
    {
        Change();
    }

    private void Update()
    {
        if (Time.time - _currentTime >= _currentTimeToChange) 
        {
            _currentTime = Time.time;
            Change();
        } 
    }

    private void Change()
    {
        if (_isActive)
        {
            OnDiactivate();
            _isActive = false;
        }
        else 
        {
            OnActivate();
            _isActive=true;
        }
    }

    public void OnActivate()
    {
        _spotLight.SetActive(true);
        _pointLight.SetActive(true);
        _currentTimeToChange = UnityEngine.Random.Range(_timeActive.x, _timeActive.y);
    }

    public void OnDiactivate()
    {
        _spotLight.SetActive(false);
        _pointLight.SetActive(false);
        _currentTimeToChange = UnityEngine.Random.Range(_timeOut.x, _timeOut.y);
    }

    
}
