using UnityEngine;

public class BinBagCollector : MonoBehaviour
{
    public int binBagsCollected = 0; 
    public int binBagsDeposited = 0; 

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Bin"))
        {

            Destroy(other.gameObject);


            binBagsCollected++;
            Debug.Log("Bin Bag Collected! Total: " + binBagsCollected);
        }


        if (other.CompareTag("Dumpster"))
        {
            if (binBagsCollected > 0)
            {

                binBagsDeposited += binBagsCollected;

                Debug.Log($"Deposited {binBagsCollected} bin bags. Total Deposited: {binBagsDeposited}");


                binBagsCollected = 0;
            }
            else
            {
                Debug.Log("No bin bags to deposit!");
            }
        }
    }
}
