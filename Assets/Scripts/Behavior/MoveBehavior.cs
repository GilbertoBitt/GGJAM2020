using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Behavior
{
    public class MoveBehavior : MonoBehaviour
    {
        public PlayerMain main;
        public Vector2 direction;
        public float speed;
        public Rigidbody2D rdbody;

        public void OnValidate()
        {
            TryGetComponent(out rdbody);
        }

        // Start is called before the first frame update
        void Start()
        {
           main = new PlayerMain();     
           main.main.move.performed += OnMove;
           main.main.move.canceled += OnMoveStopped;
           main.main.Enable();
        }

        private void OnMoveStopped(InputAction.CallbackContext obj)
        {
            direction = Vector2.zero;
            UpdateMovement();
        }

        private void OnMove(InputAction.CallbackContext ctx)
        {
            direction = ctx.ReadValue<Vector2>();
            UpdateMovement();
        }

        private void UpdateMovement()
        {
            rdbody.velocity = direction * speed;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
