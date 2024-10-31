using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed; 
    [SerializeField] private float jumpPower;
    [SerializeField] private float accX = 50f;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    private float _horizontalInput;
    private float _wallJumpCooldown;
    private float _gScale;
    private const float WallFriction = 1f;

    private Rigidbody2D _body;
    private BoxCollider2D _boxCollider;

    private float _moveX;
    private bool _grounded;

    private void Awake()
    {
        // Grab references
        _body = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        // Save initial gravity scale
        _gScale = _body.gravityScale;
    }

    private void Update()
    {   
        // Facing direction change
        _horizontalInput = Input.GetAxis("Horizontal");

        transform.localScale = _horizontalInput switch
        {
            > 0.01f => Vector3.one,
            < -0.01f => new Vector3(-1, 1, 1),
            _ => transform.localScale
        };

        // Horizontal Acceleration Calculation
        _moveX = _horizontalInput != 0 
            ? Mathf.MoveTowards(_moveX, moveSpeed, Time.deltaTime * accX) 
            : Mathf.MoveTowards(_moveX, moveSpeed, Time.deltaTime * accX * 2);


        // Jumping
        if (_wallJumpCooldown > 0.2f)
        {
            // Horizontal Movement
            _body.velocity = new Vector2(_horizontalInput * _moveX, _body.velocity.y);

            if (OnWall() && !IsGrounded())
            {
                // Sticks player to wall and decreases gravity by friction
                _body.gravityScale = _gScale * WallFriction;
                _body.velocity = Vector2.zero;
            }
            else
                _body.gravityScale = _gScale;

            // Check Jump Input
            if (Input.GetKey(KeyCode.Space))
                Jump();

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                print("No Implementation");
        }
        else
            _wallJumpCooldown += Time.deltaTime;
            
    }

    private void Jump()
    {
        // Basic Jump
        if (IsGrounded())
            _body.velocity = new Vector2(_body.velocity.x, jumpPower);
        // Wall Jump
        else if (OnWall() && !IsGrounded())
        {
            if (_horizontalInput == 0)
            {
                _body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                _body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 6, 8);

            _wallJumpCooldown = 0;
            
        }
    }

    private bool IsGrounded()
    {
        var raycastGround = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size,
            0, Vector2.down, 0.05f, groundLayer);
        return raycastGround.collider is not null;
    }

    private bool OnWall()
    {
        var raycastWall = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 
            0, new Vector2(transform.localScale.x, 0), 0.05f, wallLayer);
        return raycastWall.collider is not null && _horizontalInput != 0;
    }
}
