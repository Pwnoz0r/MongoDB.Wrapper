#region

using MongoDB.Bson.Serialization.Attributes;

#endregion

namespace MongoDB.Wrapper.Models;

[BsonIgnoreExtraElements]
internal sealed class KeyValueEntity
{
    public string Key { get; set; }

    public string Value { get; set; }
}