using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPointMarker : MonoBehaviour
{
    public PlayerInput input;
    // Start is called before the first frame update
    void Start()
    {
        input.OnMovementPointSet += Input_OnMovementPointSet;
    }

    private void Input_OnMovementPointSet(object sender, PlayerInput.OnMovementPointSetEventArgs e)
    {
        transform.position = e.movePoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
