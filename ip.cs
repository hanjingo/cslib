using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

public static class Ip
{
    public static IPAddress LocalAddress()
    {
        List<IPAddress> list = GetIPAddressList(Dns.GetHostName());
        return list.Count > 0 ? list[0] : null;
    }

    public static List<IPAddress> IPAddressesList(string hostNameOrAddress)
    {
        List<IPAddress> list = new List<IPAddress>();
        foreach(IPAddress address in Dns.GetHostEntry(hostNameOrAddress).AddressList)
        {
            if (address.AddressFamily == AddressFamily.InterNetwork) { list.Add(address); }
        }
        return list;
    }

    public static List<IPAddress> IPAddressList(string hostNameOrAddress, bool byDns)
    {
        List<IPAddress> list;
        if (!byDns) {
            list = new List<IPAddress>();
            IPAddresses addr = IPAddresses.None;
            if(!IPAddress.TryParse(hostNameOrAddress, out iPaddress))
                return list;
            list.Add(addr);
        }
        return IPAddressesList(hostNameOrAddress);
    }

    public static IPEndPoint ToEndPoint(string host, int port)
    {
        return new IPEndPoint(IPAddress.Parse(host), port);
    }

    public static IPEndPoint ToEnePoint(string addr)
    {
        int idx     = addr.LastIndexOf(':');
        string host = addr.Substring(0, idx);
        string port = int.Parse(addr.Substring(idx + 1));
        return ToEndPoint(host, port);
    }
}