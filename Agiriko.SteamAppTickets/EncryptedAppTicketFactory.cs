using Agiriko.SteamAppTickets.Native;

namespace Agiriko.SteamAppTickets
{
    /// <summary>
    /// Factory class for decrypting app tickets.
    /// </summary>
    public sealed class EncryptedAppTicketFactory
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
        /// Decrypts a ticket given its encrypted data.
        /// </summary>
        /// <param name="encryptedTicket">The encrypted ticket data.</param>
        /// <returns>The decrypted ticket.</returns>
        /// <exception cref="InvalidTicketException">Thrown whenever the supplied ticket is invalid.</exception>
        public EncryptedAppTicket Decrypt(byte[] encryptedTicket)
        {
            var ticketData = Wrappers.BDecryptTicket(encryptedTicket, _key);
            if (ticketData == null)
                throw new InvalidTicketException();

            return new EncryptedAppTicket(ticketData!);
        }
    }
}
