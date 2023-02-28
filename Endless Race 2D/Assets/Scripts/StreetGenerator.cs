using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StreetGenerator : MonoBehaviour
{
    [SerializeField] private GameObject streetlamp;
    [SerializeField] private float MinSpeedd;
    [SerializeField] private float MaxSpeedd;
    public float currentSpeedd;
    public float speedMultiplier;
    // Start is called before the first frame update
    private void Awake()
    {
        currentSpeedd = MinSpeedd;
        generateStreetLamp();
    }
    public void generateNextStreetLampWihtGap()
    {
        float randomwait = Random.Range(0.5f, 2f);
        InvokeRepeating("generateStreetLamp", randomwait, 0);
    }
    public void generateStreetLamp()
    {
        GameObject StreetLampIns = Instantiate(streetlamp, transform.position, transform.rotation);
        StreetLampIns.GetComponent<StreetLampScript>().Initialized(this);
    }
    // Update is called once per frame
    void Update()
    {
        SpeedStreet();
    }
    private void SpeedStreet()
    {
        if (currentSpeedd < MaxSpeedd)
        {
            currentSpeedd += speedMultiplier;
        }
    }

}

