using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class grapplingHook_01 : MonoBehaviour
{
    public GameObject rope_02;
    private GameObject ropeInstance;
    public float hookRange = 10f;
    public float hookSpeed = 20f;
    Vector3 attachedPosition;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootHook();
        }
    }
    void shootHook()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.z));
        Vector3 mouseDirection = spawnPosition - transform.position;


        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0,1,0), mouseDirection, out hit, hookRange))
        {
            //FixedUpdate();

            ropeInstance = Instantiate(rope_02, hit.point , Quaternion.identity);

            //SpringJoint spring = gameObject.AddComponent<SpringJoint>();
            //spring.connectedBody = GetComponent<Rigidbody>();
            //spring.spring = 1000f;
            //spring.damper = 5f;
            //spring.maxDistance = Vector3.Distance(transform.position, hit.point);
            //spring.connectedAnchor = hit.point;
            

            Destroy(ropeInstance, 10f);
        }

        //void FixedUpdate()
        //{
        //    if (Vector3.Distance(attachedPosition, transform.position) >= 2 && rb!=null)
        //    {
        //        rb.AddForce((attachedPosition - transform.position));
        //        Debug.Log("rb founded" + rb.name);
        //    }
        //    else if(rb==null)
        //    {
        //        Debug.Log("rb not found");
        //    }
        //    else if(Vector3.Distance(attachedPosition, transform.position) < 5)
        //    {
        //        Debug.Log("rb too short");
        //    }
        //}

    }
}
