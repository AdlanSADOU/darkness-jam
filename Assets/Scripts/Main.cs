using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;


public class Main : MonoBehaviour
{
    GameObject entity_prefab;
    GameObject canvas;
    GameObject timer_text;

    EntityManager entityManager;

    class Mob
    {
        public GameObject gameObject;
        public Vector2 direction;
        public float speed;

    };

    public float time_scale = 1;
    float countdown = 3;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        timer_text = GameObject.Find("Timer");
        timer_text.GetComponent<Text>().text = countdown.ToString();
        entity_prefab = Resources.Load<GameObject>("Prefabs/Mob");

        Torch.Init();



        // entityManager = World.Active.EntityManager;
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        EntityArchetype archetype = entityManager.CreateArchetype(
            typeof(Translation),
            typeof(RenderMesh),
            typeof(LocalToWorld) // Needed for rendering
        );

        Entity entity = entityManager.CreateEntity(archetype);


        entityManager.SetComponentData<Translation>(entity, new Translation {
            Value = new Vector3(0,0,0)
        });
        entityManager.SetSharedComponentData<RenderMesh>(entity, new RenderMesh {
            mesh = entity_prefab.GetComponent<SpriteRenderer>().sprite.GetPhysicsShape()
        });

    }

    public float elapsed_time = 0;

    bool first = true;

    void Update()
    {
        elapsed_time += Time.deltaTime;
        if (elapsed_time >= 1 && countdown > 0)
        {
            countdown -= 1;
            timer_text.GetComponent<Text>().text = countdown.ToString();
            elapsed_time = 0;
        }

        if (first && countdown <= 0)
        {
            canvas.transform.GetChild(0).gameObject.SetActive(false);
            first = false;
        }

        if (first) return;


        Torch.Update();


        ///////////////////////////////
        // Entities
        // for (int i = 0; i < entities.Count; i++)
        // {
        //     entities[i].gameObject.transform.Translate(entities[i].direction * Time.deltaTime * entities[i].speed);
        //     Vector3 entity_pos = entities[i].gameObject.transform.position;

        //     // print("wToS: "+Camera.main.WorldToScreenPoint(entity_pos).x);
        //     if (((Camera.main.WorldToScreenPoint(entity_pos).x > Screen.width) || (Camera.main.WorldToScreenPoint(entity_pos).x < 0))
        //     )
        //     {
        //         entities[i].direction.x = (entities[i].direction.x) * -1;
        //     }
        //     if (((Camera.main.WorldToScreenPoint(entity_pos).y > Screen.height) || (Camera.main.WorldToScreenPoint(entity_pos).y < 0)))
        //     {
        //         entities[i].direction.y = (entities[i].direction.y) * -1;
        //     }
        // }
    }
}
