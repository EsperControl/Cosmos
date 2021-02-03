using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector] public float horizontal;
    [HideInInspector] public float throttle;
    [HideInInspector] public bool fire;
    bool readyToClear = true;
    // Start is called before the first frame update
    void Start()
    {

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
    void Clear_input()
    {
        if (!readyToClear)
            return;
        horizontal = 0f;
        throttle = 0f;
        readyToClear = false;
    }
    void ProcessInputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        throttle = Input.GetAxis("Vertical");
        fire = Input.GetMouseButton(0);
        //horizontal = Mathf.Clamp(horizontal, -100, 100);
        //throttle = Mathf.Clamp(throttle, -100, 100);
        print(string.Format("horizontal = {2}\nvertical = {1}\nfire = {2}", horizontal, throttle,fire));

    }
}