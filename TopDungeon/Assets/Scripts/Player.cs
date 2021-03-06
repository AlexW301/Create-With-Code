using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    private SpriteRenderer spriteRenderer;
    private bool isAlive = true;
    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // DontDestroyOnLoad(gameObject);
    }
    protected override void RecieveDamage(Damage dmg)
    {
        if(!isAlive)
            return;
        base.RecieveDamage(dmg);
        GameManager.instance.OnHitPointChange();
    }
    protected override void Death()
    {
        isAlive = false;
        GameManager.instance.deathMenuAnim.SetTrigger("Show");
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if(isAlive)
        UpdateMotor(new Vector3(x, y, 0));
    }

    public void SwapSprite(int skinId)
    {
        spriteRenderer.sprite = GameManager.instance.playerSprites[skinId];
    }
    public void OnLevelUp()
    {
        maxHitpoint++;
        hitpoint = maxHitpoint;
    }

    public void SetLevel(int level)
    {
        for (int i = 0; i < level; i++)
            OnLevelUp();
    }
    public void Heal(int healingAmount)
    {
        if(hitpoint == maxHitpoint)
            return;
        hitpoint += healingAmount;
        if(hitpoint > maxHitpoint)
            hitpoint = maxHitpoint;
        GameManager.instance.ShowText("+" + healingAmount.ToString() + "hp", 25, Color.green, transform.position, Vector3.up * 30, 1.0f);
        GameManager.instance.OnHitPointChange();
    }

    public void Respawn()
    {
        Heal(maxHitpoint);
        isAlive = true;
        lastImmune = Time.time;
        pushDirection = Vector3.zero;
    }
}


//    //Make sure we can move in this direction by casting a box ther first, if the box returns null we are free to move
//         hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
//         if (hit.collider == null)
//         {
//             // Make this thing move!
//             transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
//         }

//         hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.x), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
//         if (hit.collider == null)
//         {
//             // Make this thing move!
//             transform.Translate(0, moveDelta.x * Time.deltaTime, 0);
//         }