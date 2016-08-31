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
        if (Time.time > lastSpawn + spawnFreq && quad1InUse != true || quad2InUse != true || quad3InUse != true || quad4InUse != true)  //Makes sure that objects spawn according to the spawn frequency chosen.
        {
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
        spawnPoint1.transform.position = new Vector2(Screen.width + (Screen.width / 5), quad1);
        spawnPoint2.transform.position = new Vector2(Screen.width + (Screen.width / 5), quad2);
        spawnPoint3.transform.position = new Vector2(Screen.width + (Screen.width / 5), quad3);
        spawnPoint4.transform.position = new Vector2(Screen.width + (Screen.width / 5), quad4);
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

        if (!quad1InUse)                                                //If the lane is not in use
        {
            quad1InUse = true;                                          //Marks the lane as in use.
            obj.transform.position = spawnPoint1.transform.position;    //Spawns the gameobject in the lane.
            obj.GetComponent<AsteroidMovement>().QuadNum(1);            //Tells the gameobject which lane it is in.
        }
        else if (!quad2InUse)                                           //If the lane is not in use
        {
            quad2InUse = true;                                          //Marks the lane as in use.
            obj.transform.position = spawnPoint2.transform.position;    //Spawns the gameobject in the lane.
            obj.GetComponent<AsteroidMovement>().QuadNum(2);            //Tells the gameobject which lane it is in.
        }
        else if (!quad3InUse)                                           //If the lane is not in use
        {
            quad3InUse = true;                                          //Marks the lane as in use.
            obj.transform.position = spawnPoint3.transform.position;    //Spawns the gameobject in the lane.
            obj.GetComponent<AsteroidMovement>().QuadNum(3);            //Tells the gameobject which lane it is in.
        }
        else if (!quad4InUse)                                           //If the lane is not in use
        {
            quad4InUse = true;                                          //Marks the lane as in use.
            obj.transform.position = spawnPoint4.transform.position;    //Spawns the gameobject in the lane.
            obj.GetComponent<AsteroidMovement>().QuadNum(4);            //Tells the gameobject which lane it is in.
        }

        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
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