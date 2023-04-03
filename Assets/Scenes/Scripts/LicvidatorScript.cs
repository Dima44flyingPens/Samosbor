using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LicvidatorScript : MonoBehaviour
{
    
    public float speed = 10;
    float translation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        translation = -speed * Time.deltaTime;
        gameObject.transform.Translate(translation, 0, 0);
    }
}
