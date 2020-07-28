using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCountryTouch : MonoBehaviour
{
    //concept from this tutorial https://www.youtube.com/watch?v=G8cePMSkALI 18.05.2020

    public string touchedCountryName = "EMPTY";
    public bool clickDetectedFlag = false;

    public List<string> ARtouchedCountriesInSession = new List<string>();
    public string ARtouchedCountriesString;

    public List<string> nonARtouchedCountriesInSession = new List<string>();
    public string nonARtouchedCountriesString;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit touchInformation;
            if (Physics.Raycast(ray, out touchInformation))
            {
                var rig = touchInformation.collider.GetComponent<MeshRenderer>();
                if(rig != null)
                {
                    //rig.GetComponent<MeshRenderer>().material = redMaterial;
                    touchedCountryName = touchInformation.collider.gameObject.name;

                    //Check which scene is active. Logic from https://answers.unity.com/questions/1173303/how-to-check-which-scene-is-loaded-and-write-if-co.html 03.07.2020
                    Scene currentScene = SceneManager.GetActiveScene();
                    string sceneName = currentScene.name;

                    if (sceneName == "AugmentedImage" && touchedCountryName != "EARTH_MESH" && touchedCountryName != "EARTH_MESH_map")
                    {
                        ARtouchedCountriesString += touchedCountryName + ", ";
                        PlayerPrefs.SetString("ARtouchedCountries", ARtouchedCountriesString);

                        ARtouchedCountriesInSession.Add(touchedCountryName);
                        int ARtouchedCountriesAmount = ARtouchedCountriesInSession.Count;
                        PlayerPrefs.SetInt("ARtouchedCountrAmount", ARtouchedCountriesAmount);
                        PlayerPrefs.Save();

                    } else if (sceneName == "nonAR" && touchedCountryName != "EARTH_MESH" && touchedCountryName != "EARTH_MESH_map")
                    {
                        nonARtouchedCountriesString += touchedCountryName + ", ";
                        PlayerPrefs.SetString("nonARtouchedCountries", nonARtouchedCountriesString);

                        nonARtouchedCountriesInSession.Add(touchedCountryName);
                        int nonARtouchedCountriesAmount = nonARtouchedCountriesInSession.Count;
                        PlayerPrefs.SetInt("nonARtouchedCountrAmount", nonARtouchedCountriesAmount);
                        PlayerPrefs.Save();
                    }
                }
            }
            clickDetectedFlag = true;
        }     
    }

    public string catchClickedCountry()
    {
        return touchedCountryName;
    }

    public bool isClickedDetected()
    {
        return clickDetectedFlag;
    }
}
