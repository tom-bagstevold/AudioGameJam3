using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    Transform myTransform;
    Vector3 myRotation;
    

    // Start is called before the first frame update
    void Start()
    {
        myTransform = gameObject.transform;
        myRotation = myTransform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

        //gameObject.transform.position += new Vector3(0, 1, 0);

        if(Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(myRotation.x, myRotation.y - 90, myRotation.z);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(myRotation.x, myRotation.y + 90, myRotation.z);
        }

    }
}
