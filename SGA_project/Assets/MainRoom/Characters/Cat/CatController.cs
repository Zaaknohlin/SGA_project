using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{

    private SpriteRenderer _renderer;
    private Rigidbody2D _body;
    private Animator _animator;

    private bool canJump = false;

    public bool canMove = true;

    public int level = 0;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 jumpHeight = new Vector2(0, 0.01f);

    [SerializeField] private GameObject _question;
    [SerializeField] private GameObject _exclamation;

    [SerializeField] private GameObject[] _botColliders;

    [SerializeField] private GameObject[] _topColliders;

    [SerializeField] private GameObject[] _roomColliders;


    private bool isInteracted = false;

    [SerializeField] Transform arrivalTransform;

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(!canMove) 
        { 
            // Reset any input
            _animator.SetFloat("hor_move", 0);
            _animator.SetFloat("ver_move", 0);
            return;
        }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        _animator.SetFloat("hor_move", Mathf.Abs(h));
        _animator.SetFloat("ver_move", v);


        gameObject.transform.position = new Vector2 (transform.position.x + (h * moveSpeed), 
        transform.position.y + (v * moveSpeed));

        // flip the sprite when changing direction
        if(h == -1)
        {
            _renderer.flipX = false;
        }
        else if(h == 1)
        {
            _renderer.flipX = true;
        }

        // Jump
        if(Input.GetKey(KeyCode.Space) && canJump)
        {

            deactivateAllColliders();

            canMove = false;
            var posDelta = transform.position.x - arrivalTransform.position.x;
            Debug.Log(posDelta);
            if(posDelta < 0)
            {
                // Animate to the right
                if(_renderer.flipX){
                    _renderer.flipX = false;
                }
            }else
            {
                // Animate to the left
                if(!_renderer.flipX)
                {
                    _renderer.flipX = true;
                }
            }

            // Play jump animation
            _animator.Play("Jump");
        }

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
       

        // Pop the question mark when approaching a POI
        if(collider.tag == "Interactions")
        {
            _question.SetActive(true);
            isInteracted = true;
        }
        // Detect JumpPoints
        if(collider.tag == "JumpPoint")
        {
            canJump = true;
            _exclamation.SetActive(true);
            arrivalTransform = collider.transform;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        // Hide the question mark when exiting a POI
        if(other.tag == "Interactions")
        {
            _question.SetActive(false);
            isInteracted = false;
        }
        // Detect JumpPoints
        if(other.tag == "JumpPoint")
        {
            canJump = false;
            _exclamation.SetActive(false);
        }
    }

    public void Unlock()
    {
        canMove = true;
        _exclamation.SetActive(false);
        Debug.Log("unlocked");

    }

    public void TeleportCat()
    {
        transform.position = arrivalTransform.position;
    }

    // public void ActivateAllColliders()
    // {
    //     foreach (var collider in _botColliders)
    //     {
    //         collider.SetActive(true);
    //     }
    //     foreach (var collider in _topColliders)
    //     {
    //         collider.SetActive(true);
    //     }
    // }

    // ANIMATION CONTROLLED : Activate colliders according to level of navigation
    private void updateNavLvl(int nextLvl)
    {
        if(nextLvl == 0)
        {
            // Deactivate top colliders and activate bot colliders
        }else if(nextLvl == 1)
        {
            // Activate top colliders
            foreach (var collider in _topColliders)
            {
                collider.SetActive(true);
            }
        }
    }

    private void deactivateAllColliders()
    {
        // Deactivate all colliders
        foreach (var collider in _botColliders)
        {
            collider.SetActive(false);
        }
        foreach (var collider in _topColliders)
        {
            collider.SetActive(false);
        }
        foreach (var collider in _roomColliders)
        {
            collider.SetActive(false);
        }
    }

}
