namespace Agiriko.SteamAppTickets
{
    /// <summary>
    /// Exception thrown for when the given encrypted app ticket is invalid.
    /// </summary>
    public sealed class InvalidTicketException : Exception
    {
        public InvalidTicketException()
            : base("Tried to decrypt an invalid encrypted app ticket!")
        {

        }
    }
}
