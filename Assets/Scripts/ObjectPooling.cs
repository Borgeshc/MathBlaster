using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooling : MonoBehaviour
{

    public GameObject pooledObject; //The object you want to pool
    public int pooledAmount;        //The amount of objects you want to pool.
    public bool willGrow = true;    //Allows the script to instantiate more objects if needed.
    public float spawnFreq;         //The spawn frequency of the object.
    float lastSpawn;                //The time that the object spawned last.

    int quad1;  //Used to split the screen into fourths.
    int quad2;
    int quad3;
    int quad4;

    int quadNum; //Used to tell the script which quad to use.

    public GameObject spawnPoint1;  //Spawnpoints for each quad.
    public GameObject spawnPoint2;
    public GameObject spawnPoint3;
    public GameObject spawnPoint4;

    public List<GameObject> pooledObjects;  //A list of all the active pooled objects.

    //[HideInInspector]
    public bool quad1InUse; //Bools to tell if the lane is being used.
    //[HideInInspector]
    public bool quad2InUse;
    //[HideInInspector]
    public bool quad3InUse;
    //[HideInInspector]
    public bool quad4InUse;

    GameObject spawnPoint; //The point where the object will spawn.
    public int objectCount;       //Keeps track of how many objects are active in the scnene.

    // Use this for initialization
    void Start()
    {
        pooledObjects = new List<GameObject>(); //Populates the list with the instantiated gameobjects.

        SetSpawnPoints();
        for (int i = 0; i < pooledAmount; i++)  //Instantiates as many objects as you specified.
        {
            StartCoroutine(InstantiatePool());
        }

        ActivateObject(); //Spawns a gameobject at the start.
    }
    void Update()
    {
        if (Time.time > lastSpawn + spawnFreq && objectCount < 3)  //Makes sure that objects spawn according to the spawn frequency chosen.
        {// && quad1InUse != true || quad2InUse != true || quad3InUse != true || quad4InUse != true
            ActivateObject();                   //Spawns the object.
        }
    }

    void SetSpawnPoints()
    {
        //Splits the screen into fourths.
        quad1 = Screen.height - (Screen.height / 5);
        quad2 = Screen.height / 5 * 2;
        quad3 = Screen.height / 5 * 3;
        quad4 = 0 + (Screen.height / 5);

        //Sets the spawn points to the quad positions.
        spawnPoint1.transform.position = new Vector2(Screen.width + (Screen.width / 6), quad1);
        spawnPoint2.transform.position = new Vector2(Screen.width + (Screen.width / 6), quad2);
        spawnPoint3.transform.position = new Vector2(Screen.width + (Screen.width / 6), quad3);
        spawnPoint4.transform.position = new Vector2(Screen.width + (Screen.width / 6), quad4);
    }
    public GameObject GetPooledObject() //Can be called to get a gameobject in the pool.
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        if (willGrow)   //If there are not enough gameobjects, spawns more.
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.transform.parent = transform;
            pooledObjects.Add(obj);
            return obj;
        }
        return null;
    }

    IEnumerator InstantiatePool()   //Instantiates all gameobjects in the pool.
    {
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.transform.parent = transform;
        obj.SetActive(false);
        pooledObjects.Add(obj);
        yield break;
    }

    void ActivateObject()   //Turns on the gameobject.
    {
        lastSpawn = Time.time;                      //A timestamp of when the object spawned.
        GameObject obj = GetPooledObject();         //Gets a gameobject from the list

        if (obj == null)
        {
            return;
        }

        ChooseQuad();

        obj.transform.position = spawnPoint.transform.position;    //Spawns the gameobject in the lane.
        obj.GetComponent<AsteroidMovement>().QuadNum(quadNum);     //Tells the gameobject which lane it is in.

        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
        objectCount++;                                             //Increases the count of objects in the scene.
        
    }

    void ChooseQuad()
    {
        quadNum = Random.Range(1, 4);
        if (quadNum == 1 && !quad1InUse)                                                //If the lane is not in use
        {
            print("Quad1 if called");
            quad1InUse = true;                                          //Marks the lane as in use.
            quadNum = 1;
            spawnPoint = spawnPoint1;       //sets the spawnpoint to the quads position.
        }
        else if (quadNum == 2 && !quad2InUse)                                           //If the lane is not in use
        {
            print("Quad2 if called");
            quad2InUse = true;                                          //Marks the lane as in use.
            quadNum = 2;
            spawnPoint = spawnPoint2;
        }
        else if (quadNum == 3 && !quad3InUse)                                           //If the lane is not in use
        {
            print("Quad3 if called");
            quad3InUse = true;                                          //Marks the lane as in use.
            quadNum = 3;
            spawnPoint = spawnPoint3;
        }
        else if (quadNum == 4 && !quad4InUse)                                           //If the lane is not in use
        {
            print("Quad4 if called");
            quad4InUse = true;                                          //Marks the lane as in use.
            quadNum = 4;
            spawnPoint = spawnPoint4;
        }
    }
}
/*
 * object to pool
 * amount of objects to pool
 * list to hold pooled objects
 * current pooled object
 * bool to allow instantiation of objects when pool is empty
 * 
*/