using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ParallaxingEffect : MonoBehaviour
{
    private float startXPosition;
    public float amountOfParallaxing;

    public Transform targetTransform;
    public bool useMainCameraAsTarget = true;
   
    void Start()
    {
        startXPosition = transform.position.x;

        if (useMainCameraAsTarget)
            targetTransform = Camera.main.transform;       
    }

   
    void Update()
    {
        float distance = (targetTransform.position.x * amountOfParallaxing);

        transform.position = new Vector3(startXPosition + distance, transform.position.y, transform.position.z);
    }
}
