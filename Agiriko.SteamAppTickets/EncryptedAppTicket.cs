namespace Agiriko.SteamAppTickets
{
    /// <summary>
    /// A steam encrypted app ticket.
    /// </summary>
    public sealed class EncryptedAppTicket
    {
        /// <summary>
        /// Is this ticket for an app given by appId.
        /// </summary>
        /// <param name="appId">The app id.</param>
        /// <returns>Whether this ticket is for the app.</returns>
        public bool IsTicketForApp(ulong appId)
        {
            return false;
        }

        /// <summary>
        /// Checks whether the ticket owner owns a given app id.
        /// </summary>
        /// <param name="appId">The app id to check.</param>
        /// <returns>Whether the ticket owner owns a given app id.</returns>
        public bool UserOwnsAppInTicket(ulong appId)
        {
            return false;
        }

        /// <summary>
        /// Returns whether the owner of this app ticket is VAC banned.
        /// </summary>
        /// <returns>Whether the owner of this app ticket is VAC banned.</returns>
        public bool IsUserVACBanned()
        {
            return false;
        }

        /// <summary>
        /// Gets the app id associated with this ticket.
        /// </summary>
        /// <returns>The app id associated with this ticket.</returns>
        public ulong GetAppId()
        {
            return 0;
        }

        /// <summary>
        /// Returns the issuing time for this ticket.
        /// </summary>
        /// <returns>The issuing time for this ticket.</returns>
        public DateTime? GetIssueTime()
        {
            return null;
        }

        /// <summary>
        /// Gets the steam id associated with this ticket.
        /// </summary>
        /// <returns>The steam id associated with this ticket.</returns>
        public ulong? GetSteamId()
        {
            return null;
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