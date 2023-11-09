using System.Collections.Generic;
using UnityEngine;

public class MapObjectManager : MonoBehaviour
{
    protected Dictionary<MapObjectTypes, MapObjectProvider> providers = new Dictionary<MapObjectTypes, MapObjectProvider>();

    protected virtual void Awake()
    {
        var providerArray = GetComponentsInChildren<MapObjectProvider>();
        foreach (var provider in providerArray)
        {
            if (providers.ContainsKey(provider.ObjectType)) continue;
            providers[provider.ObjectType] = provider;
        }
    }

    public virtual GameObject GetObject(MapObjectTypes type)
    {
        if (!providers.ContainsKey(type)) return null;
        return providers[type].GetObject();
    }

    public virtual float GetProviderMaxSize(MapObjectTypes type)
    {
        if (!providers.ContainsKey(type)) return -1f;
        return providers[type].MaxSize;
    }
    public virtual float GetProviderMinSize(MapObjectTypes type)
    {
        if (!providers.ContainsKey(type)) return -1f;
        return providers[type].MinSize;
    }
    public virtual float GetProviderPadding(MapObjectTypes type)
    {
        if (!providers.ContainsKey(type)) return -1f;
        return providers[type].Padding;
    }
    public virtual float GetProviderYValueOffset(MapObjectTypes type)
    {
        if (!providers.ContainsKey(type)) return -1f;
        return providers[type].YValueOffset;
    }
}
