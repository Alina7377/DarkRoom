using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _speedWalk;
    [SerializeField] private float _speedRotate;
    [SerializeField] private float _speedRun;
    [SerializeField] private float _speedSneak;

    private PlayerControl _control;
    private Rigidbody _rigidbody;
    private float _currentSpeed;
    private Vector3 _walkColliderSize;
    private Vector3 _sneakColliderSize = new Vector3(1, 1f, 1);
    private BoxCollider _collider;

    private void Awake()
    {
        _control = new PlayerControl();
        SetCursorSetting();
        _rigidbody = GetComponent<Rigidbody>();
        _currentSpeed = _speedWalk;
        _collider = GetComponent<BoxCollider>();
        _walkColliderSize = _collider.size;
        // Подпись на кнопки бега и приседеа
        _control.Player.Run.started += context => Run();
        _control.Player.Sneak.started += context => Sneak();
        // Подпись на возыращение к хотьбе
        _control.Player.Run.canceled += context => Walk();
        _control.Player.Sneak.canceled += context => Walk();
    }

    /// <summary>
    /// Для плавного поворота
    /// </summary>
    private void Update()
    {
        Rotate(_control.Player.Look.ReadValue<Vector2>());        
    }

    /// <summary>
    /// Для корректного расчета физики при передвижении 
    /// </summary>
    private void FixedUpdate()
    {
        Move(_control.Player.Move.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _control.Enable();
    }

    private void OnDisable()
    {
        _control.Disable();
    }

    private void Run() 
    {
        _currentSpeed = _speedRun;
    }

    private void Walk() 
    { 
        _currentSpeed = _speedWalk;
        _collider.size = _walkColliderSize;
    }

    private void Sneak() 
    {
        _currentSpeed = _speedSneak;
       // _collider.center = _sneakOffsetCenter;
        _collider.size = _sneakColliderSize;
        
    }

    private void Move(Vector2 direction) 
    {
        _rigidbody.velocity = (transform.forward * direction.y + transform.right * direction.x) * _currentSpeed;
        _rigidbody.angularVelocity = Vector3.zero;
    }

    private void Rotate(Vector2 rotate)
    {
        float mauseX = rotate.x * _speedRotate * Time.deltaTime;
        float mauseY = rotate.y * _speedRotate * Time.deltaTime;

        float rotateX = Mathf.Clamp(-mauseY, -90, 90);

        Quaternion rotation = _cameraTransform.localRotation;       
        rotation *= Quaternion.Euler(rotateX, 0, 0);
        if (rotation.x < 0.55 && rotation.x > -0.55)
            _cameraTransform.localRotation = rotation;
        transform.Rotate(0, mauseX, 0);
    }

    public void SetCursorSetting() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void DiactivateControl() 
    {
        _control.Disable();
    }

    public void ActivateControl() 
    {
        _control.Enable();
    }

}
