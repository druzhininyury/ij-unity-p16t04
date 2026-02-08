using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2.0f;
    [SerializeField] private Camera _camera;

    private readonly string VerticalAxisName = "Vertical";
    private readonly string HorizontalAxisName = "Horizontal";
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float verticalInputValue = Input.GetAxisRaw(VerticalAxisName);
        float horizontalInputValue = Input.GetAxisRaw(HorizontalAxisName);
        
        Vector3 moveDirection = _camera.transform.up * verticalInputValue + _camera.transform.right * horizontalInputValue;
        moveDirection.y = 0;
        moveDirection.Normalize();
        
        _rigidbody.velocity = moveDirection * _moveSpeed;
    }
}
