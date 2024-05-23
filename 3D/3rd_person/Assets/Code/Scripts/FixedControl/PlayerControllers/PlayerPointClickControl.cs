using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts.FixedControl;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Scripts.FixedControl
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerPointClickControl : MonoBehaviour, IMouseControlListener
    {
        [SerializeField] private PointClickPlayerData data;

        private NavMeshAgent _agent;
        private Vector3 _mousePosition;
        // Start is called before the first frame update
        void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();

        }

        private void RegisterListeners()
        {
            var inputDevice = FindObjectOfType<PointClickGameInput>();
            inputDevice.LeftClick += LeftClick;
            inputDevice.RightClick += RightClick;
            inputDevice.PositionChanged += PositionChanged;
        }

        private void DeregisterListeners()
        {
            var inputDevice = FindObjectOfType<PointClickGameInput>();
            inputDevice.LeftClick -= LeftClick;
            inputDevice.RightClick -= RightClick;
            inputDevice.PositionChanged -= PositionChanged;
        }
        private void OnEnable()
        {
            _agent.enabled = true;
            RegisterListeners();
        }

        private void OnDisable()
        {
            _agent.enabled = false;
            DeregisterListeners();

        }

        // Update is called once per frame
        void Update()
        {
        
        }

        void LeftClick()
        {
            var ray = Camera.main.ScreenPointToRay(_mousePosition);
            if (Physics.Raycast(ray,  out var hitInfo, Mathf.Infinity, LayerMask.GetMask("Navigation")))
            {
               
                _agent.SetDestination(hitInfo.point);
            }
        }

        void RightClick()
        {
        
        }

        void PositionChanged(Vector2 newPosition)
        {
            
            _mousePosition = new Vector3(newPosition.x, newPosition.y, 0);
            
        }
    }

}
