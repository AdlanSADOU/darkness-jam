using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public float speed = 20;
    GameObject square;
    SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        square = GameObject.Find("Square");
        sp = square.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float x_axis = Input.GetAxisRaw("Horizontal");
        float y_axis = Input.GetAxisRaw("Vertical");

        Debug.Log(x_axis + ", " + y_axis);

        Vector2 direction;
        direction.x = x_axis;
        direction.y = y_axis;

        gameObject.transform.Translate(direction * Time.deltaTime * speed);
        square.transform.Translate(direction * Time.deltaTime * speed);
    }
}
