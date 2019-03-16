using Assets.DataModels;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class PolaroidCycle : MonoBehaviour
{
    List<PolaroidModel> polaroids = new List<PolaroidModel>();

    public GameObject polaroidPrefab;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        var fileNames = Directory.GetFiles("GameData");
        foreach(string file in fileNames)
        {
            string dataAsJson = File.ReadAllText($"{file}");
            var gameData = JsonUtility.FromJson<PlayerGallery>(dataAsJson);
            
            foreach(PictureModel pictureM in gameData.Pictures)
            {
                if(pictureM.Score > 200)
                {
                    polaroids.Add(new PolaroidModel() { PlayerName = gameData.PlayerName.Substring(0, 15), PictureModel = pictureM });

                }
            }
        }
        polaroids = polaroids.OrderByDescending(x => x.PictureModel.Score).ToList();


        InvokeRepeating("SpawnPolaroid", 0f, 5f);
    }

    void SpawnPolaroid()
    {
        if (counter == polaroids.Count)
            counter = 0;
        var polaroid = Instantiate(polaroidPrefab, transform);
        polaroid.GetComponent<Polaroid>().SetProps(polaroids[counter]);
        counter++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
