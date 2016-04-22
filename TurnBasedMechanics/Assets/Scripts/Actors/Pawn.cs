using System;
using UnityEngine;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Permissions;

public class Pawn : Actor
{
    public bool IsDead { get; set; }

    //TODO
    private Directions _facing;

    // Allows you to queue up facing while moving
    // for smoother UX
    public Directions FacingAfterMove
    {
        get { return _facingAfterMove; }
        set
        {
            if(IsMoving)
                _facingAfterMove = value;
            else
            {
                Facing = value;
            }
        }
    }

    [SerializeField]
    private GameObject _facingIndicator;

    private Directions _facingAfterMove;

    [SerializeField]
    public int MoveAPCost { get; private set; }

    public ActionPoint ActionPoint { get; private set; }

    public Movement Movement { get; private set; }

    public Defenses Defenses { get; private set; }

    public Health Health { get; private set; }
    public Armor  Armor  { get; private set; }
    public Block  Block  { get; private set; }
    public Evade  Evade  { get; private set; }
    
    public Allegiances Allegiance { get; set; }

    public int APRemaining
    {
        get { return ActionPoint.PointsRemaining; }
    }

    public bool HasEnoughAPToMove
    {
        get { return APRemaining <= MoveAPCost; }
    }

    public List<Point> PointsInRange
    {
        get
        {
            if (ActionPoint.PointsRemaining < MoveAPCost)
                return new List<Point>();
            return Movement.PointsInRange;
        }
    } 

    public int HealthRemaining
    {
        get { return Health.Remaining; }
    }

    public Directions Facing
    {
        get { return _facing; }
        set
        {
            if (value == Directions.None) return;
            _facing = value;
            if (_facing == Directions.West)
                SpriteRenderer.flipX = true;
            if (_facing == Directions.East)
                SpriteRenderer.flipX = false;
            
            DeathEvent.OnFacingChanged(value);
            
        }
    }

    private DeathEvent DeathEvent { get; set; }

    public GameObject FacingIndicator
    {
        get { return _facingIndicator; }
    }

    public bool IsMoving
    {
        get { return Movement.IsMoving; }
    }

    public bool IsEngaged { get; set; }

    public Point Engage
    {
        get
        {
            return Position.Cardinal(Facing);
        }
    }

    private SpriteRenderer SpriteRenderer { get; set; }

    public bool TakeDamage(DamageData damage)
    {
        Defenses.ModDamage(damage);

        if (damage.Amount <= 0) return false;

        Health.TakeDamage(damage.Amount);
        Debug.Log(Name + " took " + damage.Amount + " damage!");
        Debug.Log(Name + " has " + HealthRemaining + " health left!");

        if (HealthRemaining <= 0)
        {
            Debug.Log(Name + " Died!");
            SpriteRenderer.color = Color.black;
            this.PostNotification(Notifications.ACTOR_LEFT_POINT, Position);
            IsDead = true;
            SpriteRenderer.sortingLayerName = "Actors";
            FacingIndicator.SetActive(false);
            if(BattleController.Instance.Enemy.Pawns.Contains(this))
                BattleController.Instance.Enemy.Pawns.Remove(this);
        }
            

        return true;
    }

    public DamageData Attack()
    {
        var damage = new DamageData
        {
            Amount = 5,
            ArmorPierce = 1,
            Type = DamageTypes.Direct
        };

        return damage;
    }

    public void Refresh()
    {
        ActionPoint.Fill();
    }

   

    public void UpdatePathingData()
    {
        Movement.UpdatePathingData();
    }

    public bool Move(Point point)
    {
        if (ActionPoint.PointsRemaining < MoveAPCost) return false;
        if (!Movement.Move(point)) return false;

        ActionPoint.Use(MoveAPCost);

        return true;
    }

    public void SetFacingIndicator(Directions direction)
    {
        _facing = direction;
        if (_facing == Directions.West)
            SpriteRenderer.flipX = true;
        if (_facing == Directions.East)
            SpriteRenderer.flipX = false;
        FacingIndicator.transform.localEulerAngles = _facing.ToEuler();
    }

   
    private void HurtMyself()
    {
        if (Input.GetKeyDown("space"))
        {
            Health.TakeDamage(1);
        }
    }

    private void OnDeath()
    {
        Debug.Log("I DIED!");
    }

    private void OnDoneMoving(object sender, object args)
    {
        if (FacingAfterMove == Directions.None) return;
        Facing = FacingAfterMove;
        FacingAfterMove = Directions.None;
    }

    protected new void InitAwake()
    {
        base.InitAwake();
        ActionPoint = GetComponent<ActionPoint>();
        Movement = GetComponent<Movement>();
        Health = GetComponent<Health>();
        DeathEvent = GetComponent<DeathEvent>();

        Armor = GetComponent<Armor>();
        Block = GetComponent<Block>();
        Evade = GetComponent<Evade>();
        Defenses = GetComponent<Defenses>();

        SpriteRenderer = GetComponent<SpriteRenderer>();

        Allegiance = Allegiances.None;

        FacingAfterMove = Directions.None;

        //PointPosition = GetComponent<PointPosition>();

        DeathEvent.Death += OnDeath;
        DeathEvent.FacingChanged += SetFacingIndicator;
    }
    // Use this for initialization
    protected new void Awake()
    {
        base.Awake();
        InitAwake();
    }

    protected void Start()
    {
        
        if(UnityEngine.Random.Range(0, 1) == 0)
            Facing = Directions.East;
        else
            Facing = Directions.West;
    }

    private void OnEnable()
    {
        this.AddObserver(OnDoneMoving, Movement.DONE_MOVING, Movement);
    }

    private void OnDisable()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        HurtMyself();
    }
}