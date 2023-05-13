using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    [Header ("Gate Settings")]
    [SerializeField] private int lowerLimit = 10;
    [SerializeField] private int higherLimit = 40;
    public int randomnumber;
    public bool multiply;
    [Header ("--------------------------------------------------------------------------------------------------------------------")]


    [Header ("Gate Assignments")]
    [SerializeField] private TextMesh gateno;
    


    void Start()
    {
        if (multiply)
        {
            randomnumber = Random.Range(2,4);
            gateno.text = randomnumber.ToString() + "x";        //çarmpa işlemi seçeneği seçilirse kapı çarpma işlemi gösterir
        }
        else
        {
            randomnumber = Random.Range(lowerLimit,higherLimit); //kapı toplama işlemi gösterir
            gateno.text = "+" + randomnumber.ToString();

           
          randomnumber+=1;
         
        }

        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("blue"))
        {   
            transform.parent.GetChild(1).GetChild(0).transform.gameObject.SetActive(false);  //eğer çöpadamlar kapıdan geçerse kapılardaki sayılar görünmez olur
            transform.parent.GetChild(0).GetChild(0).transform.gameObject.SetActive(false);
        }
        
    }


}
