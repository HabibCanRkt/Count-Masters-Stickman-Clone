using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [Header ("Obstacle Settings")]
    [SerializeField]private float obstacleRotaitonSpeed = 50f;
    [Header ("-----------------------------------------------------------------------------------------------------------------------------------------------------")]

    [Header ("Obstacle Assignments")]
    [SerializeField]private GameObject Obstacle;
    [SerializeField]private Rigidbody ObstacleRB;
    [SerializeField]private Transform ObstacleTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        Obstacle = gameObject;
        ObstacleRB = Obstacle.GetComponent<Rigidbody>();
        ObstacleTransform = Obstacle.GetComponent<Transform>();   
    }

    // Update is called once per frame
    void Update()
    {
       ObstacleTransform.Rotate(Vector3.up * obstacleRotaitonSpeed * Time.deltaTime, Space.Self);  //engeller belirlenen hızda kendi etraflarında dönerler
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "blue")  //eğer mavi çöpadamlar engele çarparsa çöp adamalr ölür
        {
            
            Destroy(col.gameObject);
        }
        StartCoroutine(ExecuteAfterTime(1));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        PlayerManager.PlayerManagerInstance.FormatStickman();   //çöpadamlar engele çarptıktan 1 saniye sonra yeniden posizyon alırlar
    }
}
