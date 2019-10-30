using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    public string cityName;
    public int woodQuantity = 150, stoneQuantity = 120, goldQuantity = 75, houseQuantity=0;
    public int population=0;

    public enum HouseSize
    {
        Small, Medium, Large
    }

    public enum ResourceType
    {
        Wood, Stone, Gold
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Bienvenide a : " + cityName);
        buildHouse(HouseSize.Small);
        buildHouse(HouseSize.Medium);
        buildHouse(HouseSize.Large);

        this.makeBabies();

        Debug.Log("Numero de poblacion: " + population);
    }

    void setQuantity(ResourceType resourcetype, int newQuantity)
    {
        switch (resourcetype)
        {
            case ResourceType.Wood:
                woodQuantity = woodQuantity + newQuantity;
                break;
            case ResourceType.Stone:
                stoneQuantity = stoneQuantity + newQuantity;
                break;
            case ResourceType.Gold:
                goldQuantity = goldQuantity + newQuantity;
                break;
            default:
                break;
        }
    }

    bool enoughResources(ResourceType resourceType, int quantity)
    {
        bool result = false;

        switch (resourceType)
        {
            case ResourceType.Wood:
                result = woodQuantity >= quantity;
                break;
            case ResourceType.Stone:
                result = stoneQuantity >= quantity;
                break;
            case ResourceType.Gold:
                result = goldQuantity >= quantity;
                break;
            default:
                break;
        }

        return result;
    }

    void buildHouse(HouseSize size)
    {
        switch (size)
        {
            case HouseSize.Small:
                if (enoughResources(ResourceType.Wood, 50))
                {
                    setQuantity(ResourceType.Wood, -50);
                    this.population++;
                    this.houseQuantity++;
                }
                break;

            case HouseSize.Medium:
                Debug.Log("Entro a medium antes de comprobar");
                if (enoughResources(ResourceType.Wood, 25) && enoughResources(ResourceType.Stone, 50))
                {
                    Debug.Log("Entro a medium después de comprobar");
                    setQuantity(ResourceType.Wood, -25);
                    setQuantity(ResourceType.Stone, -50);
                    this.population += 2;
                    this.houseQuantity++;
                }
                break;

            case HouseSize.Large:
                if (enoughResources(ResourceType.Wood, 50) && enoughResources(ResourceType.Stone, 50) && enoughResources(ResourceType.Gold, 25))
                {
                    setQuantity(ResourceType.Wood, -50);
                    setQuantity(ResourceType.Stone, -50);
                    setQuantity(ResourceType.Gold, -25);
                    this.population = this.population + 4;
                    this.houseQuantity++;
                }
                break;

            default:
                break;
        }
    }

    void makeBabies()
    {
        int temporalPopu = population;
        if(population > 2)
        {
            population = population + population / 2;
            for(int i=0; i<population-temporalPopu; i++)
            {
                Debug.Log("NACIMIENTO " + i);
            }
        }
    }
}
