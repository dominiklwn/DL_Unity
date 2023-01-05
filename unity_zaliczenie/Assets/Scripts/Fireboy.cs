using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fireboy : MonoBehaviour
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
    private Vector2 _boxCenter;
    [SerializeField]
    private float _speed;
    private Vector2 _moveInput;
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
            Debug.Log("RB is missing on Player2");
        }
        _initialGravityScale = _rbPlayer.gravityScale;
        _collider = GetComponent<CircleCollider2D>();
        if (!_collider)
        {
            Debug.Log("No collider on Player2");
        }
        _wait = new WaitForSeconds(_disableGCTime);
        _playerActions.Player2.Jump.performed += Jump_performedPlayer2;
    }

    void Update()
    {
        _moveInput = _playerActions.Player2.Movement.ReadValue<Vector2>();
        _rbPlayer.velocity = new Vector2(_moveInput.x * _speed, _rbPlayer.velocity.y);
    }
    void FixedUpdate()
    {

        HandleGravity();
    }
    private void OnEnable()
    {
        _playerActions.Player2.Enable();
    }
    private void OnDisable()
    {
        _playerActions.Player2.Disable();
    }
    private bool IsGroundedPlayer2()
    {
        _boxCenter = new Vector2(_collider.bounds.center.x, _collider.bounds.center.y) +
        (Vector2.down * (_collider.bounds.extents.y + (_groundCheckHeight / 2f)));
        _boxSize = new Vector2(_collider.bounds.size.x, _groundCheckHeight);
        var groundBox = Physics2D.OverlapBox(_boxCenter, _boxSize, 0f, _groundMask);
        if (groundBox != null)
            return true;
        return false;
    }
    private void Jump_performedPlayer2(InputAction.CallbackContext context)
    {
        if (IsGroundedPlayer2())
        {
            _rbPlayer.velocity += Vector2.up * _jumpPower;
            _jumping = true;
            StartCoroutine(EnableGroundCheckAfterJumpPlayer2());
        }
    }
    private IEnumerator EnableGroundCheckAfterJumpPlayer2()
    {
        _groundCheckEnabled = false;
        yield return _wait;
        _groundCheckEnabled = true;
    }
    private void HandleGravity()
    {
        if (_groundCheckEnabled && IsGroundedPlayer2())
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
