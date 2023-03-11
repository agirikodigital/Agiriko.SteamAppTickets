using System.Runtime.InteropServices;

namespace Agiriko.SteamAppTickets.Native
{
    /// <summary>
    /// Internal steamworks struct used for representing the steam id.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CSteamID
    {
        public ulong idBits;

        /// <summary>
        /// Checks whether this steam id is a null id.
        /// </summary>
        /// <returns>Whether this steam id is a null id.</returns>
        public bool IsNil() => idBits == 0;
    }
}
