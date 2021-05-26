
using UnityEngine;
using UnityEngine.SceneManagement;
public class musicmanager : MonoBehaviour
{
    public AudioSource BGM;

    public AudioClip townmusic;

    public AudioClip scene1to5;

    public AudioClip bossmusic5;

    public AudioClip scene6to10;
    public bool canplay = true;
    public bool canplayscene1to5 = true;

    private static musicmanager musicmanagerinstance;


    void Awake()
    {
        DontDestroyOnLoad(this);

        if(musicmanagerinstance == null)
        {
            musicmanagerinstance = this;
        }

        else{
            Destroy(gameObject);    
        }

        
        if(SceneManager.GetActiveScene().buildIndex ==1){
            BGM.Stop();
        }

        if(SceneManager.GetActiveScene().buildIndex >1 && SceneManager.GetActiveScene().buildIndex<5 ){
            if(canplayscene1to5){
            BGM.PlayOneShot(scene1to5);
            canplayscene1to5 = false;
            BGM.loop = true;
            BGM.playOnAwake = true;
            }
            
        }

        if(SceneManager.GetActiveScene().buildIndex == 6 ){
            if(canplay){
                BGM.Stop();
                canplay = false;
            }
            BGM.clip = bossmusic5;
            BGM.loop = true;
            BGM.playOnAwake = true;
            
            
        }
    }

    void start(){
        BGM = GetComponent<AudioSource>();
    }
    void Update()
    {   
        if(SceneManager.GetActiveScene().buildIndex ==1){
            BGM.Stop();
        }

        if(SceneManager.GetActiveScene().buildIndex >1 && SceneManager.GetActiveScene().buildIndex<5 ){
            if(canplayscene1to5){
            BGM.PlayOneShot(scene1to5);
            canplayscene1to5 = false;
            BGM.loop = true;
            }
            
        }

        if(SceneManager.GetActiveScene().buildIndex == 6 ){
            if(canplay){
                BGM.Stop();
                canplay = false;
            }
            BGM.clip = bossmusic5;
            BGM.loop = true;

        }

        if(player.healthvalue ==0){
            BGM.Stop();
        }
        
        
    }
    
}
