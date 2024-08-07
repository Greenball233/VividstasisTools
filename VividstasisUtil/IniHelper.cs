using System.Runtime.InteropServices;
using System.Text;

namespace VividstasisUtil;

public static class IniHelper
{
    [DllImport("kernel32", CharSet = CharSet.Unicode)]
    // ReSharper disable once UnusedMember.Local
    private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

    [DllImport("kernel32", CharSet = CharSet.Unicode)]
    private static extern int GetPrivateProfileString(string section, string key, string defaultValue,
        StringBuilder resultValue, int size, string filePath);

    public static string ReadStr(string section, string key, string defaultValue, string filePath)
    {
        var ret = new StringBuilder(255);
        GetPrivateProfileString(section, key, defaultValue, ret, ret.Capacity, filePath);
        return ret.ToString();
    }

    public static void WriteValue(string section, string key, string value, string filePath)
    {
        WritePrivateProfileString(section, key, value, filePath);
    }
}