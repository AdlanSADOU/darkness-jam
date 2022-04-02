using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    GameObject entity_prefab;
    GameObject torch;

    class Entity
    {
        public GameObject gameObject;
        public Vector2 direction;
        public float speed;

    };
    List<Entity> entities;

    void Start()
    {
        torch = GameObject.Find("Torch");
        entity_prefab = Resources.Load<GameObject>("Prefabs/Entity");

        entities = new List<Entity>();

        for (int i = 0; i < 300; i++)
        {
            Entity e = new Entity();
            e.gameObject = Instantiate<GameObject>(entity_prefab, new Vector3(0, 0, 0), Quaternion.identity);


            float r_x = Random.Range(40, 100);
            float r_y = Random.Range(40, 100);
            e.speed = 16;

            e.direction = new Vector2(r_x, r_y);
            e.direction.Normalize();
            print(e.direction);
            entities.Add(e);
        }
    }

    public float spot_z = -2f;

    void Update()
    {
        ///////////////////////////////
        // Torch
        Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos;

        pos.x = mouse_pos.x;
        pos.y = mouse_pos.y;
        pos.z = spot_z;

        torch.transform.position = pos;





        ///////////////////////////////
        // Entities
        for (int i = 0; i < entities.Count; i++)
        {
            entities[i].gameObject.transform.Translate(entities[i].direction * Time.deltaTime * entities[i].speed);
            Vector3 entity_pos = entities[i].gameObject.transform.position;

            // print("wToS: "+Camera.main.WorldToScreenPoint(entity_pos).x);
            if (((Camera.main.WorldToScreenPoint(entity_pos).x >= Screen.width) || (Camera.main.WorldToScreenPoint(entity_pos).x <= 0))
            )
            {
                entities[i].direction.x = (entities[i].direction.x) * -1;

            }
            if (((Camera.main.WorldToScreenPoint(entity_pos).y >= Screen.height) || (Camera.main.WorldToScreenPoint(entity_pos).y <= 0)))
            {
                entities[i].direction.y = (entities[i].direction.y) * -1;

            }
        }
    }
}
