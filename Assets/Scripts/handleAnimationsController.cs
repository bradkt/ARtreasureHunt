using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class handleAnimationsController : MonoBehaviour
{

    public GameObject flyingShip;
    public GameObject boy;
    public GameObject AppStartTxt;
    private Animator flyingShipAnim;
    private Animator AppStartTxtAnim;
    public AudioClip welcomeClip;
    public static handleAnimationsController instance;
    private AudioSource boyAudioSource;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        hideBoy();
        AppStartTxtAnim = AppStartTxt.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAppStartTxt()
    {
        AppStartTxtAnim.SetTrigger("playAppStartUpTxt");
    }

    public void playAudio(string clipName)
    { 
        // maybe create new fuction for getComponent audio and check if it's null first
        boyAudioSource = boy.GetComponent<AudioSource>();
        if (clipName == "welcome")
        {
            boyAudioSource.Play();
        }
        
    }

    public void destroyShip()
    {
        Destroy(flyingShip);
    }

    public void destroyWelcomeTxt()
    {
        Destroy(AppStartTxt);
    }

    public void showBoy()
    {
        boy.SetActive(true);
    }

    public void destroyBoy()
    {
        Destroy(boy);
    }

    public void hideBoy()
    {
        boy.SetActive(false);
    }

    public void callPlayIntroAnim()
    {
        handleGamePanels.instance.playIntroAnim();
    }

}
