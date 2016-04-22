//using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;

//public class MyGui : MonoBehaviour
//{
//    [SerializeField]
//    private GameObject _panel;
//    [SerializeField]
//    private Text _actionPointsRemaining;
//    [SerializeField]
//    private Text _moveRange;
//    [SerializeField]
//    private Text _selectedUnitHealth;
//    [SerializeField]
//    private Text _selectedUnitName;

//    private const string NoUnitSelectedText = "Select Unit";
//    private const string EmptyField = "-";




//    // [SerializeField] private Button _endTurnButton;

//    private Text MoveRange
//    {
//        get { return _moveRange; }
//        set { _moveRange = value; }
//    }

//    private Text ActionPointsRemaining
//    {
//        get { return _actionPointsRemaining; }
//        set { _actionPointsRemaining = value; }
//    }

//    //private Button EndTurnButton
//    //{
//    //    get { return _endTurnButton; }
//    //    set { _endTurnButton = value; }
//    //}



//    private Text SelectedUnitHealth
//    {
//        get { return _selectedUnitHealth; }
//        set { _selectedUnitHealth = value; }
//    }

//    private Text SelectedUnitName
//    {
//        get { return _selectedUnitName; }
//        set { _selectedUnitName = value; }
//    }

//    public GameObject Panel
//    {
//        get { return _panel; }
//        set { _panel = value; }
//    }


//    void Awake()
//    {
//        Panel.SetActive(false);
//    }

//    // Use this for initialization
//    void Start()
//    {
//        PointSelectedEvent.PawnSelected += OnPawnSelected;
//        PointSelectedEvent.SelectedPawnMoved += OnPawnMoved;
//        PointSelectedEvent.PawnDeselected += OnPawnDeselected;
//    }

//    public void UpdatePawnPanel(Pawn pawn)
//    {
//        if (pawn == null) return;

//        SelectedUnitName.text =
//           pawn.Name;

//        SelectedUnitHealth.text =
//            pawn.HealthRemaining.ToString();

//        MoveRange.text =
//            pawn.Movement.Range.ToString();

//        ActionPointsRemaining.text =
//            pawn.ActionPoint.PointsRemaining.ToString();
//    }


//    private void OnPawnDeselected(Pawn pawn)
//    {
//        if (pawn == null) return;

//        SelectedUnitName.text = NoUnitSelectedText;

//        SelectedUnitHealth.text = EmptyField;

//        MoveRange.text = EmptyField;

//        ActionPointsRemaining.text = EmptyField;
//    }

//    private void OnPawnMoved(Pawn pawn)
//    {
//        RefreshSelected(pawn);
//    }

//    private void OnPawnSelected(Pawn pawn)
//    {
//        RefreshSelected(pawn);
//    }

//    private void RefreshSelected(Pawn pawn)
//    {
//        if (pawn == null) return;

//        SelectedUnitName.text =
//           pawn.Name;

//        SelectedUnitHealth.text =
//            pawn.HealthRemaining.ToString();

//        MoveRange.text =
//            pawn.Movement.Range.ToString();

//        ActionPointsRemaining.text =
//            pawn.ActionPoint.PointsRemaining.ToString();

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}
