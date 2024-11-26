using System.Collections.Generic;
using UnityEngine;

public class SpawnLevelMap : MonoBehaviour
{
    //Declarations
    private int biomas;
    [SerializeField] private List<GameObject> spawns;
    [SerializeField] private List<GameObject> levelKingdomMaps;
    [SerializeField] private List<GameObject> levelVikingMaps;
    [SerializeField] private List<GameObject> levelCityMaps;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SelectLevelMaps();
        biomas = 1;
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
                    Instantiate(levelKingdomMaps[levelMapsIndex], spawns[index].transform.position, spawns[index].transform.rotation);
                    break;
                case 2:
                    Instantiate(levelVikingMaps[levelMapsIndex], spawns[index].transform.position, spawns[index].transform.rotation);
                    break;
                case 3:
                    Instantiate(levelCityMaps[levelMapsIndex], spawns[index].transform.position, spawns[index].transform.rotation);
                    break;
            } 
        }     
    }
}
