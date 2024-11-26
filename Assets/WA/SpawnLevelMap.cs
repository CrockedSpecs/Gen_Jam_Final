using System.Collections.Generic;
using UnityEngine;

public class SpawnLevelMap : MonoBehaviour
{
    //Declarations
    private int biomas;
    [SerializeField] private List<GameObject> spawns;
    [SerializeField] private List<GameObject> levelMaps;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SelectLevelMaps();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SelectLevelMaps()
    {
        int index = 0;
        while(index < spawns.Count)
        {
            int levelMapsIndex = Random.Range(0, spawns.Count);
            switch (biomas)
            {
                default:

                    break;
                case 1:
                    Instantiate(levelMaps[levelMapsIndex], spawns[index].transform.position, spawns[index].transform.rotation);
                    break;
                case 2:
                    Instantiate(levelMaps[levelMapsIndex], spawns[index].transform.position, spawns[index].transform.rotation);
                    break;
                case 3:
                    Instantiate(levelMaps[levelMapsIndex], spawns[index].transform.position, spawns[index].transform.rotation);
                    break;
                case 4:
                    Instantiate(levelMaps[levelMapsIndex], spawns[index].transform.position, spawns[index].transform.rotation);
                    break;
                case 5:
                    Instantiate(levelMaps[levelMapsIndex], spawns[index].transform.position, spawns[index].transform.rotation);
                    break;
                case 6:
                    Instantiate(levelMaps[levelMapsIndex], spawns[index].transform.position, spawns[index].transform.rotation);
                    break;
            } 
        }     
    }
}
