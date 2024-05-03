using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class movement : MonoBehaviour
{
    GameObject Player;
    float cooldown = 1f;
    float jumpForce = 5f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(5, 0, 0)*Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(-5, 0, 0)*Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(5, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(-5, 0, 0) * Time.deltaTime;
        }
        cooldown -= Time.deltaTime;
        if (cooldown<=0)
        {
            if (cooldown <= 0)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    rb.AddForce(Vector3.up *jumpForce, ForceMode.Impulse);
                    cooldown = 1f;
                }

            }
        }
        
        
       
    }
}
