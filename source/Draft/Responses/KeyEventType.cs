using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses
{
    /// <summary>
    ///     The types of actions on an <see cref="IKeyEvent" />.
    /// </summary>
    [DataContract]
    public enum KeyEventType
    {

        /// <summary>
        ///     A compare and delete action.
        /// </summary>
        [EnumMember(Value = "compareAndDelete")]
        CompareAndDelete,

        /// <summary>
        ///     A compare and swap action.
        /// </summary>
        [EnumMember(Value = "compareAndSwap")]
        CompareAndSwap,

        /// <summary>
        ///     A create action.
        /// </summary>
        [EnumMember(Value = "create")]
        Create,

        /// <summary>
        ///     A delete action.
        /// </summary>
        [EnumMember(Value = "delete")]
        Delete,

        /// <summary>
        ///     An expiration action.
        /// </summary>
        [EnumMember(Value = "expire")]
        Expire,

        /// <summary>
        ///     A retrieval action.
        /// </summary>
        [EnumMember(Value = "get")]
        Get,

        /// <summary>
        ///     A set action.
        /// </summary>
        [EnumMember(Value = "set")]
        Set,

        /// <summary>
        ///     An update action.
        /// </summary>
        [EnumMember(Value = "update")]
        Update

    }
}
