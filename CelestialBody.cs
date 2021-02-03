using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Is Dependable")]
    [SerializeField] bool isPlanet = false;
    [SerializeField] float radius = 10f;
    [SerializeField] float rotationSpead = 0.1f;
    [HideInInspector] public float currentAngle = 0f;
    [SerializeField] CelestialBody gravitationalCenter;


    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (isPlanet = true)
        {
            currentAngle += rotationSpead;
            float sin = Mathf.Sin(currentAngle + Mathf.Deg2Rad);
            float cos = Mathf.Cos(currentAngle + Mathf.Deg2Rad);
            Vector3 distance = new Vector3(cos, sin, 0f) * radius;
            //distance.x -= 2 * radius;
            transform.position = gravitationalCenter.transform.position + distance;
            print(string.Format("d={1}", gravitationalCenter.transform.position, distance));
        }

    }

}
