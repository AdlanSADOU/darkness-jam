using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public float spot_z = -.8f;

    void Update()
    {
        Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos;

        pos.x = mouse_pos.x;
        pos.y = mouse_pos.y;
        pos.z = spot_z;

        gameObject.transform.position = pos;
    }
}
