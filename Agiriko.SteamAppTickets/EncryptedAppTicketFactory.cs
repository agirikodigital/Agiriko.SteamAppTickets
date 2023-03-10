namespace Agiriko.SteamAppTickets
{
    /// <summary>
    /// Factory class for decrypting app tickets.
    /// </summary>
    public class EncryptedAppTicketFactory
    {
        /// <summary>
        /// The encrypted app ticket decryption key.
        /// </summary>
        private readonly byte[] _key;

        /// <summary>
        /// Creates a new encrypted app ticket factory from the key.
        /// </summary>
        /// <param name="key">The key.</param>
        public EncryptedAppTicketFactory(byte[] key)
        {
            _key = key;
        }

        /// <summary>
        /// Decrypt an encrypted app ticket.
        /// </summary>
        /// <returns></returns>
        public EncryptedAppTicket Decrypt()
        {
            return new EncryptedAppTicket();
        }
    }
}
