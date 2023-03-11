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

        [DllImport(LIBRARY_NAME)]
        private static extern bool SteamEncryptedAppTicket_BIsTicketForApp(byte[] rgubTicketDecrypted, uint cubTicketDecrypted, uint nAppID);

        /// <summary>
        /// Checks whether a ticket is for an app.
        /// </summary>
        /// <param name="ticket">The decrypted ticket data.</param>
        /// <param name="appId">The checked app id.</param>
        /// <returns>Whether this ticket is for an app.</returns>
        internal static bool BIsTicketForApp(byte[] ticket, uint appId)
        {
            return SteamEncryptedAppTicket_BIsTicketForApp(ticket, (uint)ticket.Length, appId);
        }

        [DllImport(LIBRARY_NAME)]
        private static extern bool SteamEncryptedAppTicket_BUserIsVacBanned(byte[] rgubTicketDecrypted, uint cubTicketDecrypted);

        /// <summary>
        /// Checks whether the owner of this ticket is VAC banned.
        /// </summary>
        /// <param name="ticket">The decrypted ticket data.</param>
        /// <returns>Whether the owner of this ticket is VAC banned.</returns>
        internal static bool BUserIsVacBanned(byte[] ticket)
        {
            return SteamEncryptedAppTicket_BUserIsVacBanned(ticket, (uint)ticket.Length);
        }

        [DllImport(LIBRARY_NAME)]
        private static extern bool SteamEncryptedAppTicket_BUserOwnsAppInTicket(byte[] rgubTicketDecrypted, uint cubTicketDecrypted, uint nAppID);

        /// <summary>
        /// Checks whether the owner of the ticket owns an app id.
        /// </summary>
        /// <param name="ticket">The decrypted ticket data.</param>
        /// <param name="appId">The app id to check.</param>
        /// <returns>Whether the owner of the ticket owns an app id.</returns>
        internal static bool BUserOwnsAppInTicket(byte[] ticket, uint appId)
        {
            return SteamEncryptedAppTicket_BUserOwnsAppInTicket(ticket, (uint)ticket.Length, appId);
        }

        [DllImport(LIBRARY_NAME)]
        private static extern uint SteamEncryptedAppTicket_GetTicketAppID(byte[] rgubTicketDecrypted, uint cubTicketDecrypted);

        /// <summary>
        /// Gets the app id of this ticket.
        /// </summary>
        /// <param name="ticket">The decrypted ticket data.</param>
        /// <returns>The app id of this ticket.</returns>
        internal static uint GetTicketAppID(byte[] ticket)
        {
            return SteamEncryptedAppTicket_GetTicketAppID(ticket, (uint)ticket.Length);
        }

        [DllImport(LIBRARY_NAME)]
        private static extern uint SteamEncryptedAppTicket_GetTicketIssueTime(byte[] rgubTicketDecrypted, uint cubTicketDecrypted);

        /// <summary>
        /// Gets this ticket's issue time as the number of seconds since the unix epoch (UTC).
        /// </summary>
        /// <param name="ticket">The decrypted ticket data.</param>
        /// <returns>The timestamp of the issue time.</returns>
        internal static uint GetTicketIssueTime(byte[] ticket)
        {
            return SteamEncryptedAppTicket_GetTicketIssueTime(ticket, (uint)ticket.Length);
        }

        [DllImport(LIBRARY_NAME)]
        private static extern void SteamEncryptedAppTicket_GetTicketSteamID(byte[] rgubTicketDecrypted, uint cubTicketDecrypted, out CSteamID psteamID);

        /// <summary>
        /// Gets the steam id associated with this ticket.
        /// </summary>
        /// <param name="ticket">The decrypted ticket data.</param>
        /// <returns>The steam id if the call succeeded, null otherwise.</returns>
        internal static ulong? GetTicketSteamID(byte[] ticket)
        {
            SteamEncryptedAppTicket_GetTicketSteamID(ticket, (uint)ticket.Length, out CSteamID steamId);
            if (steamId.IsNil())
                return null;

            return steamId.idBits;
        }
    }
}
