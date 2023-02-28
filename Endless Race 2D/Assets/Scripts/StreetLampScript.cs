using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLampScript : MonoBehaviour
{
    private StreetGenerator streetGenerator;
    // Start is called before the first frame update

    public void Initialized(StreetGenerator streetGenerator)
    {
        this.streetGenerator = streetGenerator;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * streetGenerator.currentSpeedd * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextLine"))
        {
            streetGenerator.generateNextStreetLampWihtGap();
        }

        if (collision.gameObject.CompareTag("FinishLine"))
        {
            Destroy(this.gameObject);
        }
    }
}
