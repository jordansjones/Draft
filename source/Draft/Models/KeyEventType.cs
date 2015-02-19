using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Models
{
    public enum KeyEventType
    {

        [EnumMember(Value = "compareAndDelete")]
        CompareAndDelete,

        [EnumMember(Value = "compareAndSwap")]
        CompareAndSwap,

        [EnumMember(Value = "create")]
        Create,

        [EnumMember(Value = "delete")]
        Delete,

        [EnumMember(Value = "expire")]
        Expire,

        [EnumMember(Value = "get")]
        Get,

        [EnumMember(Value = "set")]
        Set,

        [EnumMember(Value = "update")]
        Update,

    }
}
