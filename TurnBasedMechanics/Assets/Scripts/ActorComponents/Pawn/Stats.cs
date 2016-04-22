//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using FullInspector;

//public class Stats : BaseBehavior
//{
//    static Dictionary<StatTypes, string> _willChangeNotifications = new Dictionary<StatTypes, string>();
//    static Dictionary<StatTypes, string> _didChangeNotifications = new Dictionary<StatTypes, string>();

//    public int this[StatTypes s, bool allowExceptions = true]
//    {
//        get { return Data[s]; }
//        set { SetValue(s, value, allowExceptions); }
//    }

//    private Dictionary<StatTypes, int> Data { get; set; }
//    //int[] _data = new int[(int)StatTypes.Count];

//    private void Awake()
//    {
//        base.Awake();
//        Data = new Dictionary<StatTypes, int>
//        {
//            {StatTypes.MHP, 0},
//            {StatTypes.HP,  0},
//            {StatTypes.ATK, 0},
//            {StatTypes.AP,  0},
//            {StatTypes.DEF, 0},
//            {StatTypes.EVD, 0},
//            //{StatTypes.EXP, 0},
//            //{StatTypes.LVL, 0},
//            {StatTypes.MOV, 0},
//            //{StatTypes.SPD, 0}
//        };
//    }

//    public static string WillChangeNotification (StatTypes type)
//	{
//		if (!_willChangeNotifications.ContainsKey(type))
//			_willChangeNotifications.Add(type, string.Format("Stats.{0}WillChange", type.ToString()));
//		return _willChangeNotifications[type];
//	}
	
//	public static string DidChangeNotification (StatTypes type)
//	{
//		if (!_didChangeNotifications.ContainsKey(type))
//			_didChangeNotifications.Add(type, string.Format("Stats.{0}DidChange", type.ToString()));
//		return _didChangeNotifications[type];
//	}
	
//	private void SetValue (StatTypes type, int value, bool allowExceptions)
//	{
//		int oldValue = this[type];
//		if (oldValue == value)
//			return;
		
//		if (allowExceptions)
//		{
//			// Allow exceptions to the rule here
//			var exc = new ValueChangeException( oldValue, value );
			
//			// The notification is unique per stat type
//			this.PostNotification(WillChangeNotification(type), exc);
			
//			// Did anything modify the value?
//			value = Mathf.FloorToInt(exc.GetModifiedValue());
			
//			// Did something nullify the change?
//			if (exc.toggle == false || value == oldValue)
//				return;
//		}
		
//		Data[type] = value;
//		this.PostNotification(DidChangeNotification(type), oldValue);
//	}
	
//}