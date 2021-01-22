using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Is Dependable")]
    [SerializeField] bool isPlanet = false;
    [SerializeField] float apoapsis = 10f;
    [SerializeField] float pereapsis = 10f;
    [SerializeField] float rotationSpead = 0.1f;
    [SerializeField] float currentAngle = 0f;
    [SerializeField] CelestialBody gravitationalCenter;
    [SerializeField] float size = 0.5f;
    [SerializeField] Sprite texture;
    private float x;
    private float y;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Move()
    {
        //Двигаем наше тело
    }
}
