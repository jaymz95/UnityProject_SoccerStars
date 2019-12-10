using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{   
    Image myImageComponent;
    public Sprite myFirstImage; //Drag your first sprite here in inspector.
    public Sprite mySecondImage; //Drag your second sprite here in inspector.
    
    void Start() //Lets start by getting a reference to our image component.
    {
        myImageComponent = GetComponent<Image>(); //Our image component is the one attached to this gameObject.
    }
    
    public void SetImage1() //method to set our first image
    {
        myImageComponent.sprite = myFirstImage;
    }
 
    public void SetImage2()
    {
        myImageComponent.sprite = mySecondImage;
    }

    void Update()
    {
        SetImage2();

    }
}
