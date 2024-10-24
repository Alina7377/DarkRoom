using UnityEngine;

public class AnimateObjects : MonoBehaviour, IActivationObjects
{
    [SerializeField] private Animation _animation;
    [SerializeField] private bool _isReactivate;

    private bool _isActiv = true;

    public void OnActivate()
    {
        if (!_animation.isPlaying & (_isActiv || _isReactivate))            
            _animation.Play();
    }

    public void OnDiactivate()
    {
        _isActiv = false;
    }
 
}
