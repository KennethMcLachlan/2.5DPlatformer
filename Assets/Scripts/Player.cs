using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private float _gravity = 1.0f;

    [SerializeField]
    private float _jumpHeight = 15.0f;

    private float _yVelocity;

    private bool _canDoubleJump;

    [SerializeField]
    private int _coins;

    private UIManager _uiManager;

    [SerializeField]
    public int _lives = 3;

    private Vector3 _direction, _velocity;

    private bool _canWallJump;

    private Vector3 _wallSurfaceNormal;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager == null)
        {
            Debug.Log("UI Manager is null");
        }

        _uiManager.UpdateLivesDisplay(_lives);
    }

    void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        if (_controller.isGrounded == true)
        {
            _canWallJump = true;
            _direction = new Vector3(horizontalInput, 0, 0);
            _velocity = _direction * _speed;

            //_yVelocity = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && _canWallJump == false)
            {
                if (_canDoubleJump == true)
                {
                    _yVelocity += _jumpHeight;
                    _canDoubleJump = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && _canWallJump == true)
            {
                _yVelocity = _jumpHeight;
                _velocity = _wallSurfaceNormal * _speed;
            }

            _yVelocity -= _gravity;
        }

        _velocity.y = _yVelocity;

        _controller.Move(_velocity * Time.deltaTime);

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (_controller.isGrounded == false && hit.transform.tag == "Wall")
        {
            Debug.DrawRay(hit.point, hit.normal, Color.blue);
            _wallSurfaceNormal = hit.normal;
            _canWallJump = true;
        }
    }

    //// UI Updates
    public void AddCoins()
    {
        _coins ++;
        _uiManager.UpdateCoinDisplay(_coins);
    }
    public int CoinTally()
    {
        return _coins;
    }

    public void OnPLayerDeath()
    {
        _lives--;
        _uiManager.UpdateLivesDisplay(_lives);
    
        //GAME OVER
        if (_lives < 1)
        {
            SceneManager.LoadScene(0);
        }
    }

}
