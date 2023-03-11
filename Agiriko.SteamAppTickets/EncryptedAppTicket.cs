using Agiriko.SteamAppTickets.Native;

namespace Agiriko.SteamAppTickets
{
    /// <summary>
    /// A steam encrypted app ticket.
    /// </summary>
    public sealed class EncryptedAppTicket
    {
        /// <summary>
        /// The data for this ticket.
        /// </summary>
        private readonly byte[] _data;

        /// <summary>
        /// Creates a new encrypted app ticket from the decrypted data.
        /// </summary>
        /// <param name="data">The data.</param>
        internal EncryptedAppTicket(byte[] data)
        {
            _data = data;
        }

        /// <summary>
        /// Is this ticket for an app given by appId.
        /// </summary>
        /// <param name="appId">The app id.</param>
        /// <returns>Whether this ticket is for the app.</returns>
        public bool IsTicketForApp(uint appId)
        {
            return Wrappers.BIsTicketForApp(_data, appId);
        }

        /// <summary>
        /// Checks whether the ticket owner owns a given app id.
        /// </summary>
        /// <param name="appId">The app id to check.</param>
        /// <returns>Whether the ticket owner owns a given app id.</returns>
        public bool UserOwnsAppInTicket(uint appId)
        {
            return Wrappers.BUserOwnsAppInTicket(_data, appId);
        }

        /// <summary>
        /// Returns whether the owner of this app ticket is VAC banned.
        /// </summary>
        /// <returns>Whether the owner of this app ticket is VAC banned.</returns>
        public bool IsUserVACBanned()
        {
            return Wrappers.BUserIsVacBanned(_data);
        }

        /// <summary>
        /// Gets the app id associated with this ticket.
        /// </summary>
        /// <returns>The app id associated with this ticket.</returns>
        public uint GetAppId()
        {
            return Wrappers.GetTicketAppID(_data);
        }

        /// <summary>
        /// Returns the issuing time for this ticket (UTC).
        /// </summary>
        /// <returns>The issuing time for this ticket.</returns>
        public DateTimeOffset? GetIssueTime()
        {
            var timestamp = Wrappers.GetTicketIssueTime(_data);
            return DateTimeOffset.FromUnixTimeSeconds(timestamp);
        }

        /// <summary>
        /// Gets the steam id associated with this ticket.
        /// </summary>
        /// <returns>The steam id associated with this ticket.</returns>
        public ulong? GetSteamId()
        {
            return Wrappers.GetTicketSteamID(_data);
        }

        /// <summary>
        /// Returns the variable data supplied by the user.
        /// </summary>
        /// <returns>The variable data supplied by the user.</returns>
        public byte[]? GetVariableData()
        {
            return null;
        }
    }
}