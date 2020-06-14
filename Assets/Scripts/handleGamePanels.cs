using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class handleGamePanels : MonoBehaviour
{
    public GameObject introPanel;
    public GameObject setupPanel;
    public GameObject enterGamePanel;
    public GameObject gamePanel;
    public GameObject gameOverPanel;
    private Animator introPanelAnim;
    private Animator setupPanelAnim;
    private Animator enterGamePanelAnim;
    private Animator gamePanelAnim;
    private Animator gameOverPanelAnim;
    public Text clue1;
    public Text clue2;
    public Text clue3;
    public Text clue4;
    public Text clue5;
    public Text clue6;
    public Text clue7;
    public Text clue8;
    public Text clue9;
    public Text clue10;
    public Text clue11;
    public Text clue12;
    public Text clue13;
    public Text clue14;
    public Text clue15;
    public Text clue16;

    public GameObject imageTarget1;
    public GameObject imageTarget2;
    public GameObject imageTarget3;
    public GameObject imageTarget4;
    public GameObject imageTarget5;
    public GameObject imageTarget6;
    public GameObject imageTarget7;
    public GameObject imageTarget8;
    public GameObject imageTarget9;
    public GameObject imageTarget10;
    public GameObject imageTarget11;
    public GameObject imageTarget12;
    public GameObject imageTarget13;
    public GameObject imageTarget14;
    public GameObject imageTarget15;
    public GameObject imageTarget16;

    public Text target1Txt;
    public Text target2Txt;
    public Text target3Txt;
    public Text target4Txt;
    public Text target5Txt;
    public Text target6Txt;
    public Text target7Txt;
    public Text target8Txt;
    public Text target9Txt;
    public Text target10Txt;
    public Text target11Txt;
    public Text target12Txt;
    public Text target13Txt;
    public Text target14Txt;
    public Text target15Txt;
    public Text target16Txt;

    public Text currentClue;

    private Boolean shouldEndGame = false;
    public static handleGamePanels instance;
    public Text numberOfClues;
    private int currentClueNumber = 1;

    // check for last clue at 8 11 15 and have boy give update
    private void Awake()
    {
        if ( instance == null )
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        introPanelAnim = introPanel.GetComponent<Animator>();
        setupPanelAnim = setupPanel.GetComponent<Animator>();
        enterGamePanelAnim = enterGamePanel.GetComponent<Animator>();
        gamePanelAnim = gamePanel.GetComponent<Animator>();
        gameOverPanelAnim = gameOverPanel.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitApp()
    {
        // Application.Quit();
    }

    /* 
     * 
     * 
     * 
     * Animate In set 
     * 
     * 
     * 
     */

    public void startGame()
    {
        if (this.currentClueNumber == 1)
        {
            saveClues();
            playEnterGameAnimOut();
            playGameAnim();
        }
    }

    public void callDestroyBoy()
    {
        handleAnimationsController.instance.destroyBoy();
    }

    public void saveClues()
    {
        target1Txt.text = getClueFromPrefs(1);
        target2Txt.text = getClueFromPrefs(2);
        target3Txt.text = getClueFromPrefs(3);
        target4Txt.text = getClueFromPrefs(4);
        target5Txt.text = getClueFromPrefs(5);
        target6Txt.text = getClueFromPrefs(6);
        target7Txt.text = getClueFromPrefs(7);
        target8Txt.text = getClueFromPrefs(8);
        target9Txt.text = getClueFromPrefs(9);
        target10Txt.text = getClueFromPrefs(10);
        target11Txt.text = getClueFromPrefs(11);
        target12Txt.text = getClueFromPrefs(12);
        target13Txt.text = getClueFromPrefs(13);
        target14Txt.text = getClueFromPrefs(14);
        target15Txt.text = getClueFromPrefs(15);
        target16Txt.text = getClueFromPrefs(16);
    }

    public void playIntroAnim()
    {
        introPanelAnim.SetTrigger("playIntroPanelIn");
        handleAnimationsController.instance.destroyShip();
        handleAnimationsController.instance.destroyWelcomeTxt();
    }

    public void playSetupAnim()
    {
        setupPanelAnim.SetTrigger("playSetupPanelIn");
    }

    public void playEnterGameAnim()
    {
        playIntroAnimOut();
        enterGamePanelAnim.SetTrigger("playEnterGamePanelIn");
        handleAnimationsController.instance.showBoy();
    }

    public void playGameAnim()
    {
        gamePanelAnim.SetTrigger("playGamePanelIn");
    }

    public void playGameOverAnim()
    {
        gameOverPanelAnim.SetTrigger("playGameOverPanelIn");
    }

    /*
     *
     * 
     * Animate Out set
     * 
     * 
     * 
     */

    public void playIntroAnimOut()
    {
        introPanelAnim.SetTrigger("playIntroPanelOut");
    }

    public void playSetupAnimOut()
    {
        setupPanelAnim.SetTrigger("playSetupPanelOut");
    }

    public void playEnterGameAnimOut()
    {
        enterGamePanelAnim.SetTrigger("playEnterGamePanelOut");
    }

    public void playGameAnimOut()
    {
        gamePanelAnim.SetTrigger("playGamePanelOut");
    }

    /*
     *
     * 
     * 
     */

    public void updateGameState(int clueNum)
    {
        updateCurrentClueNumber(clueNum);
        checkForEndOfGame();
        if (this.shouldEndGame)
        {
            playGameAnimOut();
            showTreasureWhenTargetFound();
        }
        else
        {
            updateCurrentClueText(clueNum);
            destoryImageTarget(this.currentClueNumber - 1);
        }
    }

    private void destoryImageTarget(int clueNum)
    {
        GameObject targetToDestory = GameObject.Find(String.Format("imageTarget{0}", clueNum));
        Destroy(targetToDestory);
    }

    public String getClueFromPrefs(int clueNum)
    {

        String savedClue = PlayerPrefs.GetString(String.Format("clue{0}", clueNum));
        return savedClue;
    }

    private void showTreasureWhenTargetFound()
    {
        playGameOverAnim();
    }

    public void updateCurrentClueNumber(int num)
    {
        this.currentClueNumber = num;
    }

    private void checkForEndOfGame()
    {
        if (this.currentClueNumber == int.Parse(this.numberOfClues.text) + 1)
        {
            this.shouldEndGame = true;
        }
    }

    public void updateCurrentClueText(int num)
    {
        currentClue.text = getClueFromPrefs(num);
    }

    /* 
     * 
     * 
     * Save Each Clue
     * 
     * 
     */
    public void saveClue1ToPrefs()
    {
        PlayerPrefs.SetString("clue1", clue1.text);
    }

    public void saveClue2ToPrefs()
    {
        PlayerPrefs.SetString("clue2", clue2.text);
    }

    public void saveClue3ToPrefs()
    {
        PlayerPrefs.SetString("clue3", clue3.text);
    }

    public void saveClue4ToPrefs()
    {
        PlayerPrefs.SetString("clue4", clue4.text);
    }

    public void saveClue5ToPrefs()
    {
        PlayerPrefs.SetString("clue5", clue5.text);
    }

    public void saveClue6ToPrefs()
    {
        PlayerPrefs.SetString("clue1", clue1.text);

    }

    public void saveClue7ToPrefs()
    {
        PlayerPrefs.SetString("clue2", clue2.text);
    }

    public void saveClue8ToPrefs()
    {
        PlayerPrefs.SetString("clue3", clue3.text);
    }

    public void saveClue9ToPrefs()
    {
        PlayerPrefs.SetString("clue4", clue4.text);
    }

    public void saveClue10ToPrefs()
    {
        PlayerPrefs.SetString("clue5", clue5.text);
    }

    public void saveClue11ToPrefs()
    {
        PlayerPrefs.SetString("clue1", clue1.text);
    }

    public void saveClue12ToPrefs()
    {
        PlayerPrefs.SetString("clue2", clue2.text);
    }

    public void saveClue13ToPrefs()
    {
        PlayerPrefs.SetString("clue3", clue3.text);
    }

    public void saveClue14ToPrefs()
    {
        PlayerPrefs.SetString("clue4", clue4.text);
    }

    public void saveClue15ToPrefs()
    {
        PlayerPrefs.SetString("clue5", clue5.text);
    }

    public void saveClue16ToPrefs()
    {
        PlayerPrefs.SetString("clue5", clue5.text);
    }
}
