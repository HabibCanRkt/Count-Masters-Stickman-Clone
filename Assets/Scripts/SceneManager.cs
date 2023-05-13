using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceneManager : MonoBehaviour
{
    [Header("Scene Assignments")]
    [SerializeField] public float fillamount;
    public GameObject StartGamePanel;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform EndLine;
    [SerializeField] private Image sliderimage;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject tryAgainPanel;
    [SerializeField] private GameObject levelCompletedPanel;
    [SerializeField] private Button vibrationOnButton;
    [SerializeField] private Button vibrationOffButton;
    [SerializeField] private Button soundOnButton;
    [SerializeField] private Button soundOffButton;
    public static SceneManager SceneManagerInstance;


   

    
    private float endlinefirstpos;
    private float distance;

    public bool GameStarted = false;
    
    void Start()
    {
        PauseGame();

        settingsPanel.SetActive(false);
        distance = (EndLine.position.z-Player.position.z);  //oyun durunca yapılması gerekenler çalışır
        endlinefirstpos = distance;
        
        soundOffButton.gameObject.SetActive(false);
        vibrationOffButton.gameObject.SetActive(false);
        SceneManagerInstance = this;

    }

    // Update is called once per frame
    void Update()
    {
        distance = (EndLine.position.z-Player.position.z);  //level ilerleme sayacını çalıştırır ve günceller.

        fillamount= 1- (distance / endlinefirstpos);
        sliderimage.fillAmount =  fillamount;
        
        
        if(PlayerManager.PlayerManagerInstance.numberofstickman < 1)
        {
            StartCoroutine(TryAgainPanelUpdate());  
        }

        StartCoroutine(LevelCompletedPanelUpdate());
    }



    public void ResumeGame()  //oyuna devam etme butonu
    {
        Time.timeScale = 1;

        GameStarted = true;
        

        StartGamePanel.SetActive(false);
    }

    public void PauseGame() //oyunu durduram butonu
    {
        GameStarted = false;
    }

    public void OpenSettings()  //ayarları açma butonu
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()  // ayarları kapama butonu
    {
        settingsPanel.SetActive(false);
    }

    public void VibrationOn()  // titreşimi açma butonu
    {
        vibrationOnButton.gameObject.SetActive(false);
        vibrationOffButton.gameObject.SetActive(true);

      
    }

    public void VibrationOff() // titreşimi kapama butonu
    {
        vibrationOnButton.gameObject.SetActive(true);
        vibrationOffButton.gameObject.SetActive(false);


       
    }

    public void SoundOn()  // sesi açma butonu
    {
        soundOnButton.gameObject.SetActive(false);
        soundOffButton.gameObject.SetActive(true);

        
    }

    public void SoundOff() // sesi kapama butonu
    {
        soundOnButton.gameObject.SetActive(true);
        soundOffButton.gameObject.SetActive(false);

       
    }



    IEnumerator TryAgainPanelUpdate()  //yeniden dene paneli açma butonu
    {
        yield return new WaitForSecondsRealtime(2);
        tryAgainPanel.gameObject.SetActive(true);
    }
   
    public void RestartGame()
    {
         UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);  // oyunu yenden başlatan buton

    }

    IEnumerator LevelCompletedPanelUpdate()  // level tamamlanınca çıkan paneli bos öldükten 4 saniye sonra açar.
    {
        

        if ( BossManager.bossManagerInstance.currenthealth < 1)
        {
            PlayerManager.PlayerManagerInstance.roadSpeed =0f;
            PlayerManager.PlayerManagerInstance.playerSpeed=0f;

            yield return new WaitForSecondsRealtime(4f);
            levelCompletedPanel.gameObject.SetActive(true);
            
            
        }
    }

    

}
