using System;
using System.Linq;

namespace Draft.Endpoints
{
    /// <summary>
    ///     Represents a verified etcd endpoint.
    /// </summary>
    public sealed class Endpoint : IEquatable<Endpoint>
    {

        /// <summary>
        ///     Initializes a new <see cref="Endpoint" /> class with the specified <paramref name="availability" /> and
        ///     <paramref name="uri" />.
        /// </summary>
        /// <param name="uri">The etcd endpoint uri.</param>
        /// <param name="availability">The etcd endpoint availability.</param>
        public Endpoint(Uri uri, EndpointAvailability availability)
        {
            Uri = uri;
            Availability = availability;
        }

        /// <summary>
        ///     <see cref="EndpointAvailability" /> value of this etcd endpoint.
        /// </summary>
        public EndpointAvailability Availability { get; private set; }

        /// <summary>
        ///     Is <c>true</c> when <see cref="Availability" /><c> == </c><see cref="EndpointAvailability.Online" />.
        /// </summary>
        public bool IsOnline
        {
            get { return Availability == EndpointAvailability.Online; }
        }

        /// <summary>
        ///     <see cref="Uri" /> value of this etcd endpoint.
        /// </summary>
        public Uri Uri { get; private set; }

        /// <summary>
        ///     Determines whether the specified <see cref="Endpoint" /> is equal to the current <see cref="Endpoint" />.
        /// </summary>
        public bool Equals(Endpoint other)
        {
            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            return Availability == other.Availability && Equals(Uri, other.Uri);
        }

        /// <summary>
        ///     Determines whether the specified object is equal to the current object.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) { return false; }
            if (ReferenceEquals(this, obj)) { return true; }
            return obj is Endpoint && Equals((Endpoint) obj);
        }

        /// <summary>
        ///     Serves as the default hash function.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked { return ((int) Availability * 397) ^ (Uri != null ? Uri.GetHashCode() : 0); }
        }

        /// <summary>
        ///     Determines whether two specified <see cref="Endpoint" /> have the same value.
        /// </summary>
        public static bool operator ==(Endpoint left, Endpoint right)
        {
            return Equals(left, right);
        }

        /// <summary>
        ///     Determines whether two specified <see cref="Endpoint" /> have different values.
        /// </summary>
        public static bool operator !=(Endpoint left, Endpoint right)
        {
            return !Equals(left, right);
        }

    }
}
