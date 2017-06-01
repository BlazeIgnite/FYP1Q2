using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
    Script Name: Text Script
    Author: Nurhidayat
     
    Description: Scales the feedback text image when instantiateS
*/
public class TextScript : MonoBehaviour {

    // Private Variables
    float transformval;
    float timer;
    Color c;
    

	// Use this for initialization
	void Start () {
        transformval = 1;
        timer = 0.0f;
        transform.localScale = transform.localScale * 0.5f;
        c = gameObject.GetComponent<Image>().color;
        c.a = 0;
	}
	
	// Update is called once per frame
	void Update () {
        transformval = 1;
        timer += Time.deltaTime;
        if (timer > 0.75f)
        {
            transformval = 0;
            timer = 0.0f;
            Destroy(gameObject);
        }
        
        transform.position = new Vector3(transform.position.x, transform.position.y + transformval, transform.position.z);
        //transform.localScale = new Vector3(scaleval, scaleval, 1);

    }
}
