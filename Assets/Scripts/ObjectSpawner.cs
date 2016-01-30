using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class ObjectSpawner : MonoBehaviour
{
   

    public enum Level
    {
        Bottom,
        Middle,
        Top
    }
    public Level LevelSpawn=Level.Bottom;
    public GameObject[] GameObjectsToSpawn;
    public int Element;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("SchoolDetect"))
        {
            var number = Random.Range(-4, 4);
            switch (LevelSpawn)
            {
                case Level.Bottom:
                 
                    var gameo = Instantiate(GameObjectsToSpawn[Element], transform.position + new Vector3(3, 3), Quaternion.identity) as GameObject;
                    //gameo.transform.localScale = new Vector3(5, 5, 0);
                    break;
                case Level.Middle:
                    int num = 3;
                    var game1 = Instantiate(GameObjectsToSpawn[Element], transform.position+new Vector3(num,num), Quaternion.identity) as GameObject;
                    //game1.transform.localScale = new Vector3(5, 5, 0);
                    break;
                case Level.Top:
   
                    var game2 = Instantiate(GameObjectsToSpawn[Element], transform.position + new Vector3(2, 2), Quaternion.identity) as GameObject;
                    //game2.transform.localScale = new Vector3(5, 5, 0);
                    break;
            }
        }
        
    }


}
