namespace Agiriko.SteamAppTickets
{
    /// <summary>
    /// Thrown when the key for the decryption is invalid.
    /// </summary>
    public class InvalidKeyException : Exception
    {
        public InvalidKeyException(string message = "")
            : base($"The specified key for app ticket decryption is invalid! {message}")
        { 
        
        }
    }
}
