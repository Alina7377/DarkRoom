using UnityEngine;

public class AnimateObjects : MonoBehaviour, IActivationObjects
{
    [SerializeField] private Animation _animation;

    private bool _isActiv = true;

    public void OnActivate()
    {
        if (_isActiv)
            _animation.Play();
    }

    public void OnDiactivate()
    {
        _isActiv = false;
    }
 
}
