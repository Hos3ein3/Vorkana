using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Enumeration
{
    class MyEnum
    {
    }
    public enum Region : byte
    {

    }
    public enum BanksName : byte
    {

    }
    public enum FileType : byte
    {
        Image,
        Video,
        Sound,
        Document,
        Zip,
        Other
    }
    public enum MessageType : byte
    {
        Success = 0,
        Danger = 1,
        Warning = 2,
        Info = 3,
    }
}
