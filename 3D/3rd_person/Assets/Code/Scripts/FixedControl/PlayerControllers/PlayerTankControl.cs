using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts.FixedControl;
using UnityEngine;
namespace Code.Scripts.TankControl
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerTankControl : MonoBehaviour, IMovementListener 
    {
        [SerializeField]
        private TankPlayerData data;

        private CharacterController _characterController;
        private float _forwardMovement;

        private float _rotationMovement;
        // Start is called before the first frame update
        void Start()
        {
            var tankInput = FindObjectOfType<FixedControlGameInput>(); //there are lots of better ways to do this, but this is a quick and dirty way for getting projects started
            if (tankInput)
                tankInput.Movement += HandleMovement;
            _characterController = GetComponent<CharacterController>();
        }
    
        // Update is called once per frame
        void Update()
        {
            transform.Rotate(Vector3.up, _rotationMovement * Time.deltaTime * data.RotationSpeed);
            _characterController.Move(transform.forward * _forwardMovement * data.MovementSpeed * Time.deltaTime);
        }
        

        void HandleMovement(Vector2 movement)
        {
            _forwardMovement = movement.y;
            _rotationMovement = movement.x;
        }
        
        


    }
 }
