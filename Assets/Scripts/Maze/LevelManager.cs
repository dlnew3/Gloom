using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    public GameObject Maze;
    public GameObject Teleporter;
    public Transform lastMazePos;
    public GameObject TeleportLoc;
    public GameObject[] pickups;
    public int numPickups;
    public GameObject enemies;
    public int enemyCount;
    public int maxNewEnemies;
    public NavMeshSurface nav;
//    public Vector3[] MazeLocations = new Vector3[16];
//    private int LocationIndex = 0;

    public void enemyPopulate(Vector3 mazeLoc)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            //Creates Vector3 within bounds of the new Maze
            Vector3 enemyPos = new Vector3(Random.Range((mazeLoc.x - 25), (mazeLoc.x + 25)), 0.5f, Random.Range((mazeLoc.z - 25), mazeLoc.z + 25));
            Instantiate(enemies, enemyPos, Quaternion.identity);
        }
    }

    public void decorateMaze(Vector3 mazeLoc)
    {
        for(int i = 0; i < numPickups; i++)
        {
            //Creates Vector3 within bounds of the new Maze
            Vector3 pickupPos = new Vector3(Random.Range((mazeLoc.x - 25), (mazeLoc.x + 25)), 0.5f, Random.Range((mazeLoc.z - 25), mazeLoc.z + 25));
            Instantiate(pickups[Random.Range(0, numPickups)], pickupPos, Quaternion.identity);
        }
    }
    

    public void initNewMaze()
    {

        //predicts next Maze location based on the last recorded Maze position
        Vector3 newMazePos = lastMazePos.position;
        if (newMazePos.x + 50 > 200)
        {
            newMazePos.z += 50;
            newMazePos.x = -200;
        }
        else
        {
            newMazePos.x += 50;
        }
        //Initializes new Maze at newMazePos coordinates
        GameObject initMaze = Instantiate(Maze, newMazePos, Quaternion.identity);
        Debug.Log("Created New Maze at position: " + newMazePos);
        
        //Creates Vector3 within bounds of the new Maze
        Vector3 teleportPos = new Vector3(Random.Range((newMazePos.x - 25), (newMazePos.x + 25)), 0.5f, Random.Range((newMazePos.z - 25), newMazePos.z + 25));
        
        //Instantiates new Teleporter using teleportPos coordinates
        GameObject initTeleport = Instantiate(Teleporter, teleportPos, Quaternion.identity);
        Debug.Log("Created New Teleporter at position: " + teleportPos);

        //Instantiates new TeleportLocation at the center of the Maze
        //  new TeleportLocation will then be set based on TeleportLocationSet.cs
        GameObject initLocation = Instantiate(TeleportLoc, newMazePos, Quaternion.identity);
        Debug.Log("Created New TeleportLocation at position: " + newMazePos);

        //Assigns initLocation to initTeleport
        Teleport location = initTeleport.GetComponent<Teleport>();
        location.teleportTarget = initLocation.transform;
        Debug.Log("Assigned " + initLocation + " to " + initTeleport + ".Teleport.TeleportTarget.");
        //fills Maze with pickups
        decorateMaze(newMazePos);

        //fills Maze with enemies; increments the amount of enemies per maze by a random amount
        enemyPopulate(newMazePos);
        //Assigns NavMesh to initMaze and Builds NavMesh
        Manager initManager = initMaze.GetComponent<Manager>();
        initManager.surface = nav;
        initManager.surface.BuildNavMesh();

        enemyCount += Random.Range(1, maxNewEnemies);
        //Assigns lastMazePos the latest 
        lastMazePos = initMaze.transform;
        //Adds coordinates of Mazes to Array
 //   TODO: Create a hard limit of mazes to prevent memory overload
 //       MazeLocations[LocationIndex] = lastMazePos.position;
 //       LocationIndex++;
    }



    
    // Start is called before the first frame update
    void Start()
    {
 //       MazeLocations[LocationIndex] = lastMazePos.position;
 //       LocationIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)) {
            Debug.Log("Initiating LevelManager.initNewMaze()...");
            initNewMaze();
            Debug.Log("Completed LevelManager.initNewMaze()!");
        }
    }
}
