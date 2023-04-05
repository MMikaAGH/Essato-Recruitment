using System;
using System.Runtime.Serialization;

namespace Essato_Recruitment_task
{
    [Serializable]
    internal class VatException : Exception
    {
        public VatException()
        {
        }

        public VatException(string message) : base(message)
        {
        }

        public VatException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected VatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}