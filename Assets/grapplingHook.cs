using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
 
public class grapplingHook : MonoBehaviour
{

    public GameObject Player;
    public GameObject rope_02;
    GameObject ropeInstantiate = null;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
       
       if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.z));
            GameObject ropeInstantiate = Instantiate(rope_02,spawnPosition, Quaternion.identity);
        }
        if (ropeInstantiate != null && Player!=null)
        {
            ropeInstantiate.transform.SetParent(Player.transform);
            ropeInstantiate.transform.localPosition = Vector3.zero;
        }
    }
}
