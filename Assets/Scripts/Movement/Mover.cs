using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MA.Util;

namespace MA.Movement
{
    public class Mover : MonoBehaviour
    {
        bool _grounded = true;
        float _timeSinceJump = 0;
        Vector2 scale;

        [SerializeField] float runSpeed = 10f;
        [SerializeField] float jumpForce = 7f;
        [SerializeField] Transform _foot;
        [SerializeField] Transform _center;

        // static layermask has all the non moving stuff   
        LayerMask lm_static;
        Rigidbody2D rb;
        Animator animator;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            lm_static = LayerMask.GetMask("env");
        }
        private void Update()
        {

            float _footDistance = Vector2.Distance(_center.position, _foot.position);
            Collider2D hit = Physics2D.OverlapPoint(_foot.position, lm_static);
            if (hit) _grounded = true;
            else _grounded = false;

            // Debug.DrawRay(_center.position, _foot.position, Color.red, 1f);
        }


        void FixedUpdate()
        {
            _timeSinceJump += Time.deltaTime;

        }
        public void Move(short x, bool jump, bool crouch, bool dash)
        {
            // which dir player is facing
            scale = transform.localScale;

            if (x != 0)
            {
                scale.x = x > 0 ? 1 : -1;
                rb.velocity = new Vector2(x * runSpeed, rb.velocity.y);
                if (_grounded)
                {
                    SetAnimations(run: true);
                }
            }
            else
            {
                // gives good control in air
                rb.velocity = new Vector2(0, rb.velocity.y);
                SetAnimations();
            }
            transform.localScale = scale;

            if (_grounded && jump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                SetAnimations(jump: true);
            }
            else if (_grounded && crouch)
            {
                SetAnimations(crouch: true);
            }
            // else
            // {
            // SetAnimations();
            // }
        }

        public void SetAnimations(bool run = false, bool crouch = false, bool jump = false, bool dash = false, bool attack = false, bool fall = false)
        {
            animator.SetBool(Tags.Anim.Run, run);
            animator.SetBool(Tags.Anim.Crouch, crouch);
            animator.SetBool(Tags.Anim.Jump, jump);
            animator.SetBool(Tags.Anim.Dash, dash);
            animator.SetBool(Tags.Anim.Attack, attack);
            animator.SetBool(Tags.Anim.Fall, fall);
        }
    }
}