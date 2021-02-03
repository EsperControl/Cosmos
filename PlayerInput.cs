using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector] public PlayerInput Instance;
    [HideInInspector] public float horizontal;
    [HideInInspector] public float throttle;
    [HideInInspector] public bool fire;
    [HideInInspector] public Vector3 mousePosition;
    public event EventHandler<OnMovementPointSetEventArgs> OnMovementPointSet;
    bool readyToClear = true;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

    }
    public class OnMovementPointSetEventArgs : EventArgs
    {
        public Vector2 movePoint;
    }
    // Update is called once per frame
    void Update()
    {
        //Clear_input();
        ProcessInputs();
    }
    void FixedUpdate()
    {
        //In FixedUpdate() we set a flag that lets inputs to be cleared out during the 
        //next Update(). This ensures that all code gets to use the current inputs
        readyToClear = true;
    }
    private void Clear_input()
    {
        if (!readyToClear)
            return;
        horizontal = 0f;
        throttle = 0f;
        readyToClear = false;
    }
    private void ProcessInputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        throttle = Input.GetAxis("Vertical");
        fire = Input.GetMouseButton(0);
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        /*        if (Input.GetMouseButtonDown(1))
                {
                    OnActiveBuildingTypeChanged?.Invoke(this, new OnActiveBuildingTypeChangedEventArgs {activeBuildingType = activeBuildingType });
                }*/
        if (Input.GetMouseButtonDown(1))
        {
            OnMovementPointSet?.Invoke(this, new OnMovementPointSetEventArgs { movePoint = mousePosition });
        }
        //horizontal = Mathf.Clamp(horizontal, -100, 100);
        //throttle = Mathf.Clamp(throttle, -100, 100);
        print(string.Format("horizontal = {2}\nvertical = {1}\nfire = {2}", horizontal, throttle,fire));

    }
}