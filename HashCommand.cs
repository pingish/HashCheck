using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
namespace HashCheck
{
    /// <summary>
    /// HashCommand computes the has given an algorithm and input bytes.
    /// </summary>
    public class HashCommand
    {
        private readonly HashAlgorithm _algo;
        public byte[] outputBytes;

        #region Constructor
        /// <summary>
        /// HashCommand depends on a HashAlgorithm.
        /// </summary>
        /// <param name="hashAlgo">HashAlgorithm dependency</param>
        public HashCommand(HashAlgorithm hashAlgo)
        {
            _algo = hashAlgo;
        }

        #endregion

        #region Properties
        /// <summary>
        /// InputBytes encoded as UTF8 string.
        /// </summary>
        public string InputString
        {
            get { return Encoding.UTF8.GetString(InputBytes); }
            set { InputBytes = Encoding.UTF8.GetBytes(value); }
        }
        /// <summary>
        /// Byte Array to be hashed.
        /// </summary>
        public byte[] InputBytes { get; set; }

        /// <summary>
        /// OutputBytes encoded as UTF8 string.
        /// </summary>
        public string OutputString => Encoding.UTF8.GetString(OutputBytes);

        /// <summary>
        /// Computed hash as byte array
        /// </summary>
        public byte[] OutputBytes => outputBytes;

        /// <summary>
        /// Computed hash has hex string.
        /// </summary>
        public string OutputStringAsHex => bytesToHexString(outputBytes);

        private static string bytesToHexString(IReadOnlyCollection<byte> bytes)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < bytes.Count; i++)
                sb.Append(i.ToString("X2"));

            return sb.ToString().ToLower();
        }
        #endregion

        /// <summary>
        /// Execute() is the only method of Command pattern.
        /// </summary>
        public void Execute()
        {
            outputBytes = _algo.ComputeHash(InputBytes);
        }
        
    }
}
