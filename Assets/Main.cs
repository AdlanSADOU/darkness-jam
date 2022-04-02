using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{

    GameObject entity_prefab;
    GameObject torch;
    GameObject canvas;
    GameObject timer_text;

    class Entity
    {
        public GameObject gameObject;
        public Vector2 direction;
        public float speed;

    };
    List<Entity> entities;

    public float time_scale = 1;
    float countdown = 3;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        timer_text = GameObject.Find("Timer");
        print(timer_text);
        timer_text.GetComponent<Text>().text = countdown.ToString();





        torch = GameObject.Find("Torch");
        entity_prefab = Resources.Load<GameObject>("Prefabs/Entity");




        entities = new List<Entity>();

        for (int i = 0; i < 300; i++)
        {
            float r_x = Random.Range(40, 100);
            float r_y = Random.Range(40, 100);
            Entity e = new Entity();
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(r_x, r_y, 0));
            pos.z = 0;
            e.gameObject = Instantiate<GameObject>(entity_prefab, pos, Quaternion.identity);

            e.speed = 16;

            e.direction = new Vector2(r_x, r_y);
            e.direction.Normalize();
            entities.Add(e);
        }
    }

    public float spot_z = -2f;

    public float elapsed_time = 0;
    bool first = true;

    int i;
    void Update()
    {
        print(countdown);

        elapsed_time += Time.deltaTime;
        if (elapsed_time >= 1 && countdown > 0)
        {
            countdown -= 1;
            timer_text.GetComponent<Text>().text = countdown.ToString();
            elapsed_time = 0;
        }

        if (first && countdown <= 0)
        {
            print(first);
            Time.timeScale = 1;
            canvas.transform.GetChild(0).gameObject.SetActive(false);
            first = false;
        }

        if (first) return;

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
            if (((Camera.main.WorldToScreenPoint(entity_pos).x > Screen.width) || (Camera.main.WorldToScreenPoint(entity_pos).x < 0))
            )
            {
                entities[i].direction.x = (entities[i].direction.x) * -1;
            }
            if (((Camera.main.WorldToScreenPoint(entity_pos).y > Screen.height) || (Camera.main.WorldToScreenPoint(entity_pos).y < 0)))
            {
                entities[i].direction.y = (entities[i].direction.y) * -1;
            }
        }
    }
}
