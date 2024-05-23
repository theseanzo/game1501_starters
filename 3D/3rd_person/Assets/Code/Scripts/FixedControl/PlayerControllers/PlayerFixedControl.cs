using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts.FixedControl;
using UnityEngine;
namespace Code.Scripts.TankControl
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerFixedControl : MonoBehaviour, IMovementListener 
    {
        [SerializeField]
        private FixedPlayerData data;

        private CharacterController _characterController;

        private Vector3 _movement;
        // Start is called before the first frame update
        void Start()
        {
            var fixedInput = FindObjectOfType<FixedControlGameInput>(); //there are lots of better ways to do this, but this is a quick and dirty way for getting projects started
            if (fixedInput)
                fixedInput.Movement += HandleMovement;
            _characterController = GetComponent<CharacterController>();
        }
    
        // Update is called once per frame
        void Update()
        {
           _characterController.Move(_movement * data.Speed * Time.deltaTime);
           if(_movement != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_movement), data.Speed * Time.deltaTime);
        }
        

        void HandleMovement(Vector2 movement)
        {
            Vector3 forward = Camera.main.transform.forward;
            forward.y = 0;
            Vector3 right = Camera.main.transform.right;
            right.y = 0;
            _movement = forward.normalized * movement.y + right.normalized * movement.x;
        }
        
        


    }
}