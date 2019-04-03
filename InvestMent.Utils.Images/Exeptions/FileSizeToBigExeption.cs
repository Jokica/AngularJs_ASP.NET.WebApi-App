using System;
using System.Runtime.Serialization;

namespace InvestMent.Utils.Images
{
    [Serializable]
    internal class FileSizeToBigExeption : Exception
    {
        public FileSizeToBigExeption()
        {
        }

        public FileSizeToBigExeption(string message) : base(message)
        {
        }

        public FileSizeToBigExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileSizeToBigExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}