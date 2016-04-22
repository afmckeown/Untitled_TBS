// TheLiquidFire.wordpress.com

using UnityEngine;
using System.Collections.Generic;
using FullInspector;

public class GameObjectPoolController : BaseBehavior
{
    private class PoolData
    {
        public GameObject Prefab { get; set; }
        public int MaxCount { get; set; }
        public Queue<Poolable> Pool { get; set; }
    }

    private static GameObjectPoolController Instance
    {
        get
        {
            if (_instance == null)
                CreateSharedInstance();
            return _instance;
        }
    }
    private static GameObjectPoolController _instance;

    private static Dictionary<string, PoolData> Pools { get; set; }
    
    protected override void Awake()
    {
        base.Awake();

        Pools = new Dictionary<string, PoolData>();

        if (_instance != null && _instance != this)
            Destroy(this);
        else
            _instance = this;
    }
   
    public static void SetMaxCount(string key, int maxCount)
    {
        if (!Pools.ContainsKey(key))
            return;
        PoolData data = Pools[key];
        data.MaxCount = maxCount;
    }

    public static bool AddEntry(string key, GameObject prefab, int prepopulate, int maxCount)
    {
        if (Pools.ContainsKey(key))
            return false;

        var data = new PoolData
        {
            Prefab = prefab,
            MaxCount = maxCount,
            Pool = new Queue<Poolable>(prepopulate)
        };
        Pools.Add(key, data);

        for (int i = 0; i < prepopulate; ++i)
            Enqueue(CreateInstance(key, prefab));

        return true;
    }

    public static void ClearEntry(string key)
    {
        if (!Pools.ContainsKey(key))
            return;

        PoolData data = Pools[key];
        while (data.Pool.Count > 0)
        {
            Poolable obj = data.Pool.Dequeue();
            GameObject.Destroy(obj.gameObject);
        }
        Pools.Remove(key);
    }

    public static void Enqueue(Poolable sender)
    {
        if (sender == null || sender.isPooled || !Pools.ContainsKey(sender.key))
            return;

        PoolData data = Pools[sender.key];
        if (data.Pool.Count >= data.MaxCount)
        {
            GameObject.Destroy(sender.gameObject);
            return;
        }

        data.Pool.Enqueue(sender);
        sender.isPooled = true;
        sender.transform.SetParent(Instance.transform);
        sender.gameObject.SetActive(false);
    }

    public static Poolable Dequeue(string key)
    {
        if (!Pools.ContainsKey(key))
            return null;

        PoolData data = Pools[key];
        if (data.Pool.Count == 0)
            return CreateInstance(key, data.Prefab);

        Poolable obj = data.Pool.Dequeue();
        obj.isPooled = false;
        return obj;
    }
  
    private static void CreateSharedInstance()
    {
        var obj = new GameObject("GameObject Pool Controller");
        DontDestroyOnLoad(obj);
        _instance = obj.AddComponent<GameObjectPoolController>();
    }

    private static Poolable CreateInstance(string key, GameObject prefab)
    {
        var instance = Instantiate(prefab) as GameObject;
        var p = instance.AddComponent<Poolable>();
        p.key = key;
        return p;
    }
  
}
