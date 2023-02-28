using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject spike;
    [SerializeField] private float MinSpeed;
    [SerializeField] private float MaxSpeed;
    public float currentSpeed;
    public float speedMultiplier;
    // Start is called before the first frame update
    private void Awake()
    {
        currentSpeed=MinSpeed;
        generateSpike();
        
    }
    public void generateNextSpikeWihtGap()
    {
        float randomwait = Random.Range(0.1f, 3f);
        InvokeRepeating("generateSpike", randomwait, 0);//InvokeRepeating dung de gan 1 ham

    }
     public void generateSpike()
    {
        GameObject SpikeIns=Instantiate(spike, transform.position,transform.rotation);
        SpikeIns.GetComponent<SpikeScript>().Initialized(this);    
    }    
    // Update is called once per frame
    void Update()
    {
        SpeedSpike();
        
    }
    private void SpeedSpike()
    {
        if(currentSpeed < MaxSpeed) 
        {
            currentSpeed +=speedMultiplier;
        }
    }

}
