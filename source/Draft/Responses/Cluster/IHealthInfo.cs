namespace Draft.Responses.Cluster
{
    /// <summary>
    ///     Represents a health check result for the etcd cluster.
    /// </summary>
    public interface IHealthInfo
    {
        
        /// <summary>
        ///     Health status value
        /// </summary>
        bool Value { get; }

    }
}