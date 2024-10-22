using UnityEngine;
/// <summary>
/// Сдлеать абстрактный класс-родитель
/// </summary>
public class AnimatorObjects : MonoBehaviour, IActivationObjects
{
    [SerializeField] private GameObject _activateObject;
    [SerializeField] private Animator _animatorControll;

    private bool _isActive = true;

    private void Awake()
    {
        if(_animatorControll != null) _animatorControll.enabled = false;
    }
  
    public void OnActivate()
    {
        if (_isActive)
        {
            _animatorControll.enabled = true;
            _activateObject.SetActive(true);
        }
    }

    public void OnDiactivate()
    {
        _activateObject.SetActive(false);
        _isActive = false;
    }

}
