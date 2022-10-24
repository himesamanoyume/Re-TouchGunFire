using System.Collections;
using System.Collections.Generic;
using System;
using SocketProtocol;
using Google.Protobuf;
using UnityEngine;
using System.Linq;

public class Message
{
    private byte[] buffer = new byte[1024];
    private int startIndex;

    public byte[] Buffer
    {
        get { return buffer; }
    }

    public int StartIndex
    {
        get { return startIndex; }
    }

    public int Remsize
    {
        get { return buffer.Length - startIndex; }
    }

    public void ReadBuffer(int length, Action<MainPack> handleResponse)
    {
        startIndex += length;
        if (startIndex <= 4) return;
        int count = BitConverter.ToInt32(buffer, 0);
        while (true)
        {
            if (startIndex >= count + 4)
            {
                MainPack mainPack = (MainPack)MainPack.Descriptor.Parser.ParseFrom(buffer, 4, count);
                handleResponse(mainPack);
                Array.Copy(buffer, count + 4, buffer, 0, startIndex - count - 4);
                startIndex -= (count + 4);
            }
            else
            {
                break;
            }
        }

    }

    public static byte[] PackData(MainPack mainPack)
    {
        byte[] data = mainPack.ToByteArray();
        byte[] head = BitConverter.GetBytes(data.Length);
        return head.Concat(data).ToArray();
    }

}
