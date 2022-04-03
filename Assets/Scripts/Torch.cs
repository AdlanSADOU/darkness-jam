using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Torch
{
    static GameObject torch;

    public static void Init()
    {
        torch = GameObject.Find("Torch");

    }


    static public float spot_z = -2f;

    public static void Update()
    {

        ///////////////////////////////
        // Torch
        Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos;

        pos.x = mouse_pos.x;
        pos.y = mouse_pos.y;
        pos.z = spot_z;

        torch.transform.position = pos;

    }
}
