using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    public float movespeed = 4f;
    public Transform movePoint;

    public LayerMask stopmoving;

    public LayerMask yellowdoor;
    public LayerMask bluedoor;
    public LayerMask reddoor;

    public LayerMask enemy;

    public Animator anim;

    public GameObject FightorBack;
    
    public Text ExpectedDamage;

    public string PredictDamage;

    public float dmgValue;
    [SerializeField] public bool enemyright;
    [SerializeField] public bool enemyleft;
    [SerializeField] public bool enemyup;
    [SerializeField] public bool enemydown;
    [SerializeField] public bool canmove = true;
    public player thisplayer;

    Vector2 move;
    

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        
        if(FightorBack.activeInHierarchy){
                FightorBack.SetActive(false);
            }

    }

    // Update is called once per frame
    void Update()
    {       
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Horizontal",move.x);
        anim.SetFloat("Vertical",move.y);
        anim.SetFloat("speed",move.sqrMagnitude);
        
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movespeed * Time.deltaTime);

        if(Mathf.Abs(Input.GetAxisRaw("Horizontal"))==1f ){
            anim.SetFloat("LastMoveY",0);
            anim.SetFloat("LastMoveX",Input.GetAxisRaw("Horizontal"));
            //anim.SetFloat("LastMoveX",Input.GetAxisRaw("Vertical"));
        }

        if( Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f){
            anim.SetFloat("LastMoveX",0);
            anim.SetFloat("LastMoveY",Input.GetAxisRaw("Vertical"));
        }

        if(Vector3.Distance(transform.position, movePoint.position) <= 0.05f) 
        {
            
            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if(Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"),0f,0f),0.25f,stopmoving))
                {
                    //Debug.Log("Collider Ahead");
                    //anim.SetBool("idle",true);
                    //movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    //  lock, Left, Right, Up, Down  https://answers.unity.com/questions/1011742/prevent-player-from-moving-in-a-certain-direction.html
                }

                else if(Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"),0f,0f),0.25f,yellowdoor))
                {
                        //Debug.Log("check yellow door");
                        if(Keymanager.yellowkeyAmount>=1)
                        {
                            Debug.Log("i have yellow key");
                            
                            movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                            
                        }

                 }

                else if(Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"),0f,0f),0.25f,bluedoor))
                {
                        //Debug.Log("check blue door");
                        if(Keymanagerblue.bluekeyAmount>=1)
                        {
                            movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                        }

                }

                else if(Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"),0f,0f),0.25f,reddoor))
                {
                        //Debug.Log("check red door");
                        if(Keymanagerred.redkeyAmount>=1)
                        {
                            movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                        }

                }

                else if(Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"),0f,0f),0.25f,enemy))
                {

                        Debug.Log("enemy nearby");
                        
                        if(Input.GetKeyDown(KeyCode.LeftArrow)){

                            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left,1f,enemy);

                            Enemytype hitobject = hit.collider.GetComponent<Enemystats>().enemytype;

                            //Debug.Log("There is an enemy at left :" + hit.collider.gameObject.name);
                            enemyleft = true;

                            canmove=false;

                            if(player.attackvalue<hitobject.enemydefense){
                                print("this enemy too strong");
                                FightorBack.SetActive(true);
                                ExpectedDamage.text = "Expected Damage: Infinity" ;
                            }

                            else{

                                FightorBack.SetActive(true);

                                dmgValue = Mathf.Ceil((float)hitobject.enemystartinghp/(float)(player.attackvalue -hitobject.enemydefense))*(hitobject.enemyattack-player.defensevalue);

                                if(dmgValue < 0) {dmgValue = 0;}{

                                    ExpectedDamage.text = "Expected Damage: " + dmgValue;

                                }
                            }
                           // ExpectedDamage.text = "Expected Damage: " + Mathf.Ceil((float)hitobject.enemystartinghp/(float)(player.attackvalue -hitobject.enemydefense))*(hitobject.enemyattack-player.defensevalue);
                            //Debug.Log("Consle output" + thisplayer.DamageCalculation);
                        }

                            if(Input.GetKeyDown(KeyCode.Z)&&enemyleft){
                                //Debug.Log("fight enemy at left");
                                enemyleft = !true;
                                movePoint.position += new Vector3(-1, 0f, 0f);

                                FightorBack.SetActive(false);
                            }

                            if(Input.GetKeyDown(KeyCode.X)&&enemyleft){
                                //Debug.Log("do nothing");
                                enemyleft = !true;
                                FightorBack.SetActive(false);
                            }
                    

                        if(Input.GetKeyDown(KeyCode.RightArrow)){

                            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right,2f,enemy);
                            Enemytype hitobject = hit.collider.GetComponent<Enemystats>().enemytype;

                            //Debug.Log("There is an enemy at right"+ hit.collider.gameObject.name);

                            enemyright = true;
                            if(player.attackvalue<hitobject.enemydefense){
                                print("this enemy too strong");
                                FightorBack.SetActive(true);
                                ExpectedDamage.text = "Expected Damage: Infinity" ;
                            }
                            
                            else{

                            FightorBack.SetActive(true);
                            //DamageCalculation = Mathf.Ceil((float)hitobject.enemystartinghp/(float)(attackvalue-hitobject.enemydefense))*(hitobject.enemyattack-defensevalue);
                            dmgValue = Mathf.Ceil((float)hitobject.enemystartinghp/(float)(player.attackvalue -hitobject.enemydefense))*(hitobject.enemyattack-player.defensevalue);
                            if(dmgValue < 0) {dmgValue = 0;}
                            ExpectedDamage.text = "Expected Damage: " + dmgValue;
                            //Debug.Log("Consle output" + thisplayer.DamageCalculation);
                            }
                        }
                            
                        if(Input.GetKeyDown(KeyCode.Z)&&enemyright){
                            //Debug.Log("fight enemy at right");

                            movePoint.position += new Vector3(1, 0f, 0f);
                            enemyright =! true;
                             FightorBack.SetActive(false);
                        }

                        if(Input.GetKeyDown(KeyCode.X)&&enemyright){
                            enemyright =! true;
                            FightorBack.SetActive(false);
                        }
                        
                }
                
                else
                {
                    animationcheck();
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    FightorBack.SetActive(false);
                    //anim.SetBool("left",false);
                    //anim.SetBool("right",false);
                    //Debug.Log("Ignored");
                    //anim.SetBool("idle",true);
                }
              
        

            }

            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if(Physics2D.OverlapCircle(movePoint.position + new Vector3(0f,Input.GetAxisRaw("Vertical"),0f),0.25f,stopmoving))
                {
                    //Debug.Log("Collider Ahead");
                }

                else if(Physics2D.OverlapCircle(movePoint.position + new Vector3(0f,Input.GetAxisRaw("Vertical"),0f),0.25f,yellowdoor))
                {
                        //Debug.Log("check yellow door");
                        if(Keymanager.yellowkeyAmount>=1)
                        {
                            Debug.Log("i have yellow key");
                            movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                        }

                 }

                else if(Physics2D.OverlapCircle(movePoint.position + new Vector3(0f,Input.GetAxisRaw("Vertical"),0f),0.25f,bluedoor))
                {
                        //Debug.Log("check blue door");
                        if(Keymanagerblue.bluekeyAmount>=1)
                        {
                            movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                        }

                }

                else if(Physics2D.OverlapCircle(movePoint.position + new Vector3(0f,Input.GetAxisRaw("Vertical"),0f),0.25f,reddoor))
                {
                        //Debug.Log("check red door");
                        if(Keymanagerred.redkeyAmount>=1)
                        {
                            movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                        }

                }

                else if(Physics2D.OverlapCircle(movePoint.position + new Vector3(0f,Input.GetAxisRaw("Vertical"),0f),0.25f,enemy))
                {

                        //Debug.Log("enemy nearby");
                        
                        if(Input.GetKeyDown(KeyCode.UpArrow)){

                            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up,1f,enemy);
                            Enemytype hitobject = hit.collider.GetComponent<Enemystats>().enemytype;

                            //Debug.Log("There is an enemy at top :" + hit.collider.gameObject.name);

                            enemyup = true;

                            if(player.attackvalue<hitobject.enemydefense){
                                print("this enemy too strong");
                                FightorBack.SetActive(true);
                                ExpectedDamage.text = "Expected Damage: Infinity" ;
                            }
                            
                            else{
                            FightorBack.SetActive(true);
                            //DamageCalculation = Mathf.Ceil((float)hitobject.enemystartinghp/(float)(attackvalue-hitobject.enemydefense))*(hitobject.enemyattack-defensevalue);
                            dmgValue = Mathf.Ceil((float)hitobject.enemystartinghp/(float)(player.attackvalue -hitobject.enemydefense))*(hitobject.enemyattack-player.defensevalue);
                            if(dmgValue < 0) {dmgValue = 0;}
                            ExpectedDamage.text = "Expected Damage: " + dmgValue;
                            //Debug.Log("Consle output" + thisplayer.DamageCalculation);
                            }
                        }

                            if(Input.GetKeyDown(KeyCode.Z)&&enemyup){
                               // Debug.Log("fight enemy at top");
                                
                                movePoint.position += new Vector3(0f, 1f, 0f);
                                enemyup = !enemyup;
                                FightorBack.SetActive(false);
                                movespeed =4f;
                            }

                            if(Input.GetKeyDown(KeyCode.X)&&enemyup){
                               // Debug.Log("do nothing");
                                enemyup = !enemyup;
                                FightorBack.SetActive(false);
                                movespeed=4f;
                            }
                    

                        if(Input.GetKeyDown(KeyCode.DownArrow)){

                            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,2f,enemy);
                            Enemytype hitobject = hit.collider.GetComponent<Enemystats>().enemytype;

                           // Debug.Log("There is an enemy at right"+ hit.collider.gameObject.name);

                            enemydown = true;
                            if(player.attackvalue<hitobject.enemydefense){
                                print("this enemy too strong");
                                FightorBack.SetActive(true);
                                ExpectedDamage.text = "Expected Damage: Infinity" ;
                            }
                            
                            else{

                            FightorBack.SetActive(true);

                            
                            //DamageCalculation = Mathf.Ceil((float)hitobject.enemystartinghp/(float)(attackvalue-hitobject.enemydefense))*(hitobject.enemyattack-defensevalue);
                            dmgValue = Mathf.Ceil((float)hitobject.enemystartinghp/(float)(player.attackvalue -hitobject.enemydefense))*(hitobject.enemyattack-player.defensevalue);
                            if(dmgValue < 0) {dmgValue = 0;}
                            ExpectedDamage.text = "Expected Damage: " + dmgValue;
                            //Debug.Log("Consle output" + thisplayer.DamageCalculation);
                            }
                        }
                            
                        if(Input.GetKeyDown(KeyCode.Z)&&enemydown){
                          //  Debug.Log("fight enemy at right");

                            movePoint.position += new Vector3(0, -1f, 0f);
                            enemydown = !true;

                             FightorBack.SetActive(false);
                        }

                        if(Input.GetKeyDown(KeyCode.X)&&enemydown){
                            enemydown = !true;
                            FightorBack.SetActive(false);
                        }
                        
                }

                else
                {
                    movePoint.position += new Vector3(0f,Input.GetAxisRaw("Vertical"),0f);
                    FightorBack.SetActive(false);
                   // Debug.Log("Ignored");
                }
              

            }

        
        
        }

        
        
    }

    void animationcheck()
    {
        if(Input.GetAxisRaw("Horizontal") ==1){
            Debug.Log("move right");
            
            //anim.SetBool("right",true);
            //anim.SetBool("left",false);
            //anim.SetBool("up",false);
            //anim.SetBool("down",false);
            //anim.SetBool("idle",false);
            }
                    
                    
        if(Input.GetAxisRaw("Horizontal") == -1){
            Debug.Log("move left");
            /*anim.SetBool("right",false);
            anim.SetBool("left",true);
            anim.SetBool("up",false);
            anim.SetBool("down",false);
            anim.SetBool("idle",false);
            */
        }
        
        if(Input.GetAxisRaw("Vertical") == -1){
            Debug.Log("move down");
            /*anim.SetBool("right",false);
            anim.SetBool("left",false);
            anim.SetBool("up",false);
            anim.SetBool("down",true);
            anim.SetBool("idle",false);
            */
            
        }

        if(Input.GetAxisRaw("Vertical") == 1){
            Debug.Log("up");
            /*anim.SetBool("right",false);
            anim.SetBool("left",false);
            anim.SetBool("up",true);
            anim.SetBool("down",false);
            anim.SetBool("idle",false);
            */
        
        }
        else{
            Debug.Log("im in else");
            //anim.SetBool("idle",true);
            //anim.SetBool("right",false);
            //anim.SetBool("left",false);
        }
    }
}
