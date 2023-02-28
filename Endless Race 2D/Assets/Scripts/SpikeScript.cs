using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    private SpikeGenerator spikeGenerator;
    // Start is called before the first frame update

    public void Initialized(SpikeGenerator spikeGenerator)
    {
        this.spikeGenerator = spikeGenerator;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left*spikeGenerator.currentSpeed*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextLine")) 
        {
            spikeGenerator.generateNextSpikeWihtGap();
        }

        if (collision.gameObject.CompareTag("FinishLine"))
        {
            Destroy(this.gameObject);
           
        }
    }
}
