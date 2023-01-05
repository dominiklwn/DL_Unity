using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Watergirl : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    private CircleCollider2D _collider;
    private Rigidbody2D _rbPlayer;

    private Vector2 _boxSize;
    [SerializeField]
    private float _jumpPower;
    [SerializeField]
    [Range(1f, 5f)]
    private float _jumpFallGravityMultiplier;
    private Vector2 _moveInputPlayer;

    private TwoPlayers _playerActions;
    [SerializeField]
    private float _speed;
    private Vector2 _moveInput;
    private Vector2 _boxCenter;
    [Header("Ground Check")]

    [SerializeField]
    private float _groundCheckHeight;
    [SerializeField]
    private LayerMask _groundMask;
    [SerializeField]
    private float _disableGCTime;
    private bool _jumping;
    private float _initialGravityScale;
    private bool _groundCheckEnabled = true;
    private WaitForSeconds _wait;

    void Awake()
    {
        _playerActions = new TwoPlayers();
        _rbPlayer = GetComponent<Rigidbody2D>();
        if (!_rbPlayer)
        {
            Debug.Log("RB is missing on Watergirl");
        }
        _initialGravityScale = _rbPlayer.gravityScale;
        _collider = GetComponent<CircleCollider2D>();
        if (!_collider)
        {
            Debug.Log("No collider on Watergirl");
        }
        _wait = new WaitForSeconds(_disableGCTime);
        _playerActions.Player1.Jump.performed += JumpPerformedWatergirl;
        InputSystem.EnableDevice(Keyboard.current);
    }

    void Update()
    {
        _moveInput = _playerActions.Player1.Movement.ReadValue<Vector2>();
        _rbPlayer.velocity = new Vector2(_moveInput.x * _speed, _rbPlayer.velocity.y);
    }
    void FixedUpdate()
    {

        HandleGravity();
    }
    private void OnEnable()
    {
        _playerActions.Player1.Enable();
    }
    private void OnDisable()
    {
        _playerActions.Player1.Disable();
    }
    private bool IsGroundedWatergirl()
    {
        _boxCenter = new Vector2(_collider.bounds.center.x, _collider.bounds.center.y)
         + (Vector2.down * (_collider.bounds.extents.y + (_groundCheckHeight / 2f)));

        _boxSize = new Vector2(_collider.bounds.size.x, _groundCheckHeight);
        var groundBox = Physics2D.OverlapBox(_boxCenter, _boxSize, 0f, _groundMask);
        if (groundBox)
            return true;
        return false;
    }
    private void JumpPerformedWatergirl(InputAction.CallbackContext context)
    {
        if (IsGroundedWatergirl())
        {
            _rbPlayer.velocity += Vector2.up * _jumpPower;
            _jumping = true;
            StartCoroutine(EnableGroundCheckAfterJumpWatergirl());
        }
    }
    private IEnumerator EnableGroundCheckAfterJumpWatergirl()
    {
        _groundCheckEnabled = false;
        yield return _wait;
        _groundCheckEnabled = true;
    }
    private void HandleGravity()
    {
        if (_groundCheckEnabled && IsGroundedWatergirl())
        {
            _jumping = false;
        }
        else if (_jumping && _rbPlayer.velocity.y < 0f)
        {
            _rbPlayer.gravityScale = _initialGravityScale * _jumpFallGravityMultiplier;
        }
        else
        {
            _rbPlayer.gravityScale = _initialGravityScale;
        }

    }
}
