using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{

    private SpriteRenderer _renderer;
    private Rigidbody2D _body;
    private Animator _animator;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 jumpHeight = new Vector2(0, 0.01f);

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

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
        // if(Input.GetKey(KeyCode.Space))
        // {
        //     _body.AddForce(jumpHeight, ForceMode2D.Impulse);
        // }
    }

   
}
