using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private float _rotation = 180f;
    [SerializeField] private CharacterController _controller;
    public int score = 0;
    private Animator anim;
    public bool _Sprint = false;

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

        if (_Sprint)
        {
            StartCoroutine(sprinttingCoroutine());
            _speed = 5.0f;
        }
        else
        {
            _speed = 3.0f;
        }

        SprintAnimation(_Sprint);
    }

    public void MoveAnimation(float moving)
    {
        anim.SetFloat("moving", Mathf.Abs(moving));
    }

    public void SprintAnimation(bool sprint)
    {
        anim.SetBool("sprint", sprint);
    }

    IEnumerator sprinttingCoroutine()
    {
        yield return new WaitForSeconds(5f);
        _Sprint = false;
    }
}
