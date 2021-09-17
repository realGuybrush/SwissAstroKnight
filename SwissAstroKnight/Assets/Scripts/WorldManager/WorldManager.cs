using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public const int _shipSystem0 = 21;
    public List<GameObject> items;
    List<(int, int)> shipWeapons = new List<(int, int)>();
    List<int> shipSystems = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        UploadShip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DebugSetGuns()
    {
        shipWeapons = new List<(int, int)>();
        shipWeapons.Add((0, 0));
        shipWeapons.Add((1, 1));
        shipWeapons.Add((-1, 0));
        shipWeapons.Add((-1, 0));
        shipWeapons.Add((-1, 0));
        shipWeapons.Add((-1, 0));
        shipWeapons.Add((-1, 0));
        shipWeapons.Add((2, -1));
    }
    void DebugSetSystems()
    {
        shipSystems = new List<int>();
        shipSystems.Add(27);
        shipSystems.Add(27);
        shipSystems.Add(27);
    }

    public void LoadScene(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
        switch (name) 
        {
            case "Space":
                break;
        }
    }

    public void EditShipMunitions(List<(int, int)> weapons, List<int> systems)
    {
        shipWeapons = weapons;
        shipSystems = systems;
    }

    public void UploadShip()
    {
        DebugSetGuns();
        DebugSetSystems();
        GameObject kss = GameObject.Find("KnightSpaceShip");
        kss = kss.transform.GetChild(1)?.gameObject;
        if (kss == null)
            return;
        for (int i = 0; i < shipWeapons.Count; i++)
        {
            if (shipWeapons[i].Item1 != -1)
            {
                GameObject newG = GameObject.Instantiate(items[shipWeapons[i].Item1], kss.transform.GetChild(i));
                newG.transform.localEulerAngles = new Vector3(0, 0, 45 * shipWeapons[i].Item2);
                newG.GetComponent<Gun>().rotation = shipWeapons[i].Item2;
            }
        }
        kss.GetComponent<KnightControls>()?.UpdateGuns();
        for (int i = 0; i < shipSystems.Count; i++)
        {
            if (shipSystems[i] != -1)
            {
                GameObject.Instantiate(items[shipSystems[i]], kss.transform.GetChild(i + shipWeapons.Count));
                BoostSystemBy1Level(kss, shipSystems[i] - _shipSystem0);
            }
        }
    }

    private void BoostSystemBy1Level(GameObject kss, int systemNumber)
    {
        kss.transform.GetChild(shipWeapons.Count + shipSystems.Count + systemNumber).gameObject.SetActive(true);
        kss.transform.GetChild(shipWeapons.Count + shipSystems.Count + systemNumber).gameObject.GetComponent<ShipSystem>().Level++;
    }

    private void BoostSystemMax(GameObject kss, int systemNumber)
    {
        kss.transform.GetChild(shipWeapons.Count + shipSystems.Count + systemNumber).gameObject.SetActive(true);
        kss.transform.GetChild(shipWeapons.Count + shipSystems.Count + systemNumber).gameObject.GetComponent<ShipSystem>().Level = 2;
    }

    private void TurnOffSystem(GameObject kss, int systemNumber)
    {
        kss.transform.GetChild(shipWeapons.Count + shipSystems.Count + systemNumber).gameObject.GetComponent<ShipSystem>().Level = 0;
        kss.transform.GetChild(shipWeapons.Count + shipSystems.Count + systemNumber).gameObject.SetActive(false);
    }
}
