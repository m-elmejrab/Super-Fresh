using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class CustomerRequestController : MonoBehaviour
{

    public int maxNumOfFruitsRequest = 2;
    

    public List<Transform> customers;
    private List<Fruit> currentRequest;
    private List<Vector3> customerPositions;
    private float customerAnimationDuration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        currentRequest = new List<Fruit>();
        customerPositions = new List<Vector3>();
       

        for (int i = 0; i < customers.Count; i++)
        {
            customerPositions.Add(customers[i].position);
        }


        SetNextCustomerRequest();

    }

    private void SetNextCustomerRequest()
    {
        currentRequest.Clear();

        int numOfFruits = Random.Range(2, maxNumOfFruitsRequest + 1); //added +1 because the int variant of Random.Range is exclusive of Max
        
        for (int i = 0; i <numOfFruits; i++)
        {
            int randomIndex = Random.Range(0, 4);

            switch (randomIndex)
            {
                case 0:
                    currentRequest.Add(new Fruit(Fruit.FruitType.Apple));
                    break;
                case 1:
                    currentRequest.Add(new Fruit(Fruit.FruitType.Banana));
                    break;
                case 2:
                    currentRequest.Add(new Fruit(Fruit.FruitType.Lemon));
                    break;
                case 3:
                    currentRequest.Add(new Fruit(Fruit.FruitType.Pear));
                    break;
                default:
                    break;
            }

        }
        UIManager.instance.UpdateCustomerRequestText(currentRequest);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerInventory>().InventoryHasAllRequestItems(currentRequest))
            {
                other.GetComponent<PlayerInventory>().FinishRequest(currentRequest);
                if (customers.Count <=1)
                {
                    Transform customerToRemove = customers[0];
                    customers.RemoveAt(0);
                    Destroy(customerToRemove.gameObject);
                    GameManager.instance.CustomerServed();
                    GameManager.instance.GameWon();
                    enabled = false;
                }
                else
                {
                    SetNextCustomerRequest();
                    Transform customerToRemove = customers[0];

                    Animator anim = customerToRemove.GetComponent<Animator>();
                    anim.SetTrigger("Wave");
                    UpdateCustomerPositions();
                    customers.RemoveAt(0);
                    Destroy(customerToRemove.gameObject, 2f);

                    GameManager.instance.CustomerServed();

                }

            }
        }
    }

    private void UpdateCustomerPositions()
    {

        for (int i = 1; i < customers.Count; i++)
        {
            StartCoroutine(AnimateMove(customerAnimationDuration, i));
        }
    }

    IEnumerator AnimateMove(float duration, int customerIndex)
    {
        
        Transform customerToMove = customers[customerIndex];

        float percent = 0;
        Vector3 initialPos = customerToMove.position;
        Vector3 target = customerPositions[customerIndex-1];

        Quaternion orientation = customerToMove.rotation;
        Quaternion targetOrientation = customers[customerIndex - 1].rotation;

        yield return new WaitForSeconds(2f);

        Animator anim = customerToMove.GetComponent<Animator>();
        anim.SetTrigger("Walk");

        while (percent < 1)
        {
            percent += Time.deltaTime / duration;
            customerToMove.position = Vector3.Lerp(initialPos, target, percent);
            customerToMove.rotation = Quaternion.Lerp(orientation, targetOrientation, percent);
            yield return null;
        }
    }

}
