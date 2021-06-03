using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 8.0f;
    private float _normalSpeed = 8.0f;
    [SerializeField] private float _rotation = 180f;
    public int score = 0;
    public Animator anim;
    public bool _Sprint = false;
    public bool _Slow = false;

    public bool lp;

    // Update is called once per frame
    public void movement()
    {
        Vector3 rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotation * Time.deltaTime);
        this.transform.Rotate(rotation);

        float moveTopBotton = Input.GetAxisRaw("Vertical") * _speed;
        transform.Translate(Vector3.forward * moveTopBotton * _speed * Time.deltaTime);

        MoveAnimation(moveTopBotton);

        if (_Sprint)
        {
            StartCoroutine(sprinttingCoroutine());
            _speed = _normalSpeed * 1.5f;
        }
        else
        {
            _speed = _normalSpeed;
        }

        if (_Slow)
        {
            StartCoroutine(slowCoroutine());
            _speed = _normalSpeed * 0.5f;
        }
        else
        {
            _speed = _normalSpeed;
        }

        SprintAnimation(_Sprint);
        SlowAnimation(_Slow);
    }

    public void MoveAnimation(float moving)
    {
        anim.SetFloat("moving", Mathf.Abs(moving));
    }

    public void SprintAnimation(bool sprint)
    {
        anim.SetBool("sprint", sprint);
    }

    public void DieAnimation(bool death)
    {
        anim.SetBool("Death", death);
    }

    public void SlowAnimation(bool slow)
    {
        anim.SetBool("slowWalking", slow);
    }

    IEnumerator sprinttingCoroutine()
    {
        yield return new WaitForSeconds(5f);
        _Sprint = false;
    }

    IEnumerator slowCoroutine()
    {
        yield return new WaitForSeconds(2.5f);
        _Slow = false;
    }

    void OnMouseDown()
    {
        if (!lp)
        {
            DieAnimation(true);
        }
    }
}