using System.Runtime.InteropServices;

namespace Agiriko.SteamAppTickets.Native
{
    /// <summary>
    /// Wrappers for the Steamworks APIs.
    /// </summary>
    internal class Wrappers
    {
        private const string LIBRARY_NAME = "sdkencryptedappticket";

        [DllImport(LIBRARY_NAME)]
        private static extern bool SteamEncryptedAppTicket_BDecryptTicket(byte[] rgubTicketEncrypted, uint cubTicketEncrypted, ref byte[] rgubTicketDecrypted, ref uint pcubTicketDecrypted, byte[] rgubKey, int cubKey);

        /// <summary>
        /// Decrypt a ticket via its key and data.
        /// </summary>
        /// <param name="ticket">The ticket data.</param>
        /// <param name="key">The key.</param>
        /// <returns>The decrypted ticket if succeeded, null otherwise.</returns>
        internal static byte[]? BDecryptTicket(byte[] ticket, byte[] key)
        {
            var outTicket = new byte[1024];
            var outTicketSize = (uint)outTicket.Length;

            var success = SteamEncryptedAppTicket_BDecryptTicket(ticket, (uint)ticket.Length, ref outTicket, ref outTicketSize, key, key.Length);
            if (!success)
                return null;

            Array.Resize(ref outTicket, (int)outTicketSize);

            return outTicket;
        }
    }
}
