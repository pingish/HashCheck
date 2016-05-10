using System.Security.Cryptography;

namespace HashCheck
{
    /// <summary>
    /// Creates concrete instances of HashAlgorithm.
    /// </summary>
    public static class HashAlgorithmFactory
    {
        /// <summary>
        /// Constructs HashAlgorithm given string representation of algorithm.
        /// </summary>
        /// <param name="algoName">Name of algorithm</param>
        /// <returns>CryptoServiceProvider that performs ComputeHash against a byte array.</returns>
        public static HashAlgorithm GetHashAlgorithm(string algoName)
        {

            switch (algoName.ToLower())
            {
                case "sha1":
                    return new SHA1CryptoServiceProvider();
                case "sha256":
                    return new SHA256CryptoServiceProvider();
                case "sha384":
                    return new SHA384CryptoServiceProvider();
                case "sha512":
                    return new SHA512CryptoServiceProvider();
                case "md5":
                default:
                    return new MD5CryptoServiceProvider();
            }
        }
    }
}
