using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private float _rotation = 180f;
    [SerializeField] private CharacterController _controller;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotation * Time.deltaTime);
        this.transform.Rotate(rotation);

        float moveTopBotton = Input.GetAxisRaw("Vertical") * _speed;
        transform.Translate(Vector3.forward * moveTopBotton * _speed * Time.deltaTime);

        MoveAnimation(moveTopBotton);
    }

    public void MoveAnimation(float moving)
    {
        anim.SetFloat("moving", Mathf.Abs(moving));
    }
}
