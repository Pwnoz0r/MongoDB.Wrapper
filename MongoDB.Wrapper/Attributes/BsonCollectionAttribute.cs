#region

using System;
using System.Linq;

#endregion

namespace MongoDB.Wrapper.Attributes;

// Idea from https://stackoverflow.com/a/58112092
[AttributeUsage(AttributeTargets.Class)]
public class BsonCollectionAttribute : Attribute
{
    public BsonCollectionAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
}

public static class BsonCollectionExtension
{
    public static string GetCollectionName<T>()
    {
        return ((BsonCollectionAttribute)typeof(T).GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault()).Name;
    }
}