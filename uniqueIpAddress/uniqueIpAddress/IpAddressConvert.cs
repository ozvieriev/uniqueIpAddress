using System.Net;

namespace uniqueIpAddress
{
    internal class IpAddressConvert
    {
        internal static uint IpAddressToUint(string ipAddress)
        {
            var address = IPAddress.Parse(ipAddress);
            var bytes = address.GetAddressBytes();

            Array.Reverse(bytes);

            return BitConverter.ToUInt32(bytes, 0);
        }

        internal static IPAddress UintToIpAddress(uint ipAddress)
        {
            var bytes = BitConverter.GetBytes(ipAddress);

            Array.Reverse(bytes);

            return new IPAddress(bytes);
        }
    }
}
