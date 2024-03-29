﻿using System;
using System.Collections.Generic;
using System.Linq;
using Network_Analyzer.Interfaces;
using Network_Analyzer.Models.Decryptor;

namespace Network_Analyzer.Decryptors
{
	// TODO Переписать
    public class R2Decryptor : IDecryptor
    {
        public List<DecryptorModel> Parse(byte[] data)
        {
            byte[] packetData = new byte[data.Length];
            Array.Copy(data, 0, packetData, 0, packetData.Length);

            List<byte[]> packets = new List<byte[]>();
            List<byte[]> decryptPackets = new List<byte[]>();

            do
            {
                byte[] destinationArray = new byte[2];
                Array.Copy(packetData, 0, destinationArray, 0, destinationArray.Length);

                short lengthPacket = BitConverter.ToInt16(destinationArray, 0);

                if (lengthPacket > packetData.Length)
                {
                    return null;
                }

                byte[] arr = new byte[lengthPacket];
                Array.Copy(packetData, 0, arr, 0, arr.Length);

                packets.Add(arr);
                packetData = packetData.Skip(lengthPacket).ToArray();
            } while (packetData.Length != 0);

            foreach (byte[] packet in packets)
            {
                byte[] newData = CheckingCrypt(packet) ? Cryptographer(GetDataCrypt(packet)) : GetDataCrypt(packet);

                byte[] destinationArray = new byte[3];
                Array.Copy(packet, 0, destinationArray, 0, destinationArray.Length);

                byte[] newArray = new byte[destinationArray.Length + newData.Length];
                Array.Copy(destinationArray, 0, newArray, 0, destinationArray.Length);
                Array.Copy(newData, 0, newArray, destinationArray.Length, newData.Length);

                decryptPackets.Add(newArray);
            }

            List<DecryptorModel> result = new List<DecryptorModel>();
            foreach (byte[] decryptPacket in decryptPackets)
            {
                DecryptorModel decryptModel = new DecryptorModel();
                decryptModel.Opcode = GetOpcode(decryptPacket);
                decryptModel.Data = decryptPacket;

                result.Add(decryptModel);
            }

            return result;
        }

        private static bool CheckingCrypt(byte[] data)
        {
            return data[2] == 1 ? true : false;
        }

        private static byte[] GetDataCrypt(byte[] data)
        {
            byte[] buffer = new byte[data.Length - 3];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = data[i + 3];
            }

            return buffer;
        }

        private byte[] Cryptographer(byte[] packet)
        {
            byte[] key =
            {
                0x00, 0x00, 0x90, 0x9A, 0xE2, 0xF4, 0x51, 0xBB, 0xB2, 0x13, 0xD6, 0x48, 0x0E, 0xE3, 0x59, 0x04,
                0x07, 0x03, 0xDA, 0x19, 0x47, 0xCF, 0x81, 0xA4, 0x41, 0x37, 0x40, 0xAB, 0xA6, 0xDC, 0xE1, 0x0A,
                0x63, 0x4D, 0x20, 0x53, 0xFD, 0x15, 0xFB, 0x11, 0xF3, 0x79, 0xA1, 0x10, 0xF5, 0x58, 0x38, 0x5C,
                0x69, 0x0B, 0xC6, 0x4A, 0x5A, 0x6E, 0x72, 0x9B, 0x87, 0x1C, 0x7E, 0x82, 0xF8, 0x71, 0x62, 0x14,
                0x6A, 0x39, 0xAF, 0x73, 0x30, 0x86, 0x61, 0x93, 0xB8, 0x05, 0x92, 0x9C, 0x77, 0xE9, 0x6C, 0x0F,
                0x2B, 0x89, 0xDB, 0x6D, 0xA8, 0xA3, 0x24, 0x12, 0xB5, 0x4C, 0x97, 0x02, 0xCE, 0x88, 0x57, 0xDD,
                0xBE, 0x8A, 0x50, 0x6F, 0x7A, 0x2D, 0x8C, 0x3C, 0x22, 0x9F, 0xFA, 0x3E, 0xD3, 0x52, 0xCC, 0x91,
                0xC0, 0x31, 0x08, 0xD0, 0x74, 0xB3, 0x43, 0x46, 0x2C, 0x4B, 0x95, 0x16, 0x9E, 0xB6, 0xB9, 0x00,
                0x5F, 0xB0, 0x1F, 0x8F, 0x25, 0xA5, 0xAC, 0xC7, 0xC4, 0xBC, 0x83, 0x45, 0x99, 0x5B, 0xA2, 0xFC,
                0x34, 0xED, 0x6B, 0x7C, 0xEA, 0xF1, 0xAD, 0x27, 0xFF, 0xB4, 0x26, 0x5D, 0xC5, 0x7B, 0x56, 0xB7,
                0xE6, 0xD7, 0x67, 0xA7, 0x1E, 0x60, 0xC8, 0xA0, 0x80, 0x3F, 0x4F, 0x98, 0x2E, 0x8B, 0x5E, 0x21,
                0xEB, 0x49, 0xCD, 0x0C, 0x3D, 0x1D, 0xBD, 0xD1, 0x64, 0xCA, 0x9D, 0xE8, 0x28, 0xC9, 0xD9, 0x01,
                0xBF, 0xC3, 0xE5, 0xE7, 0x06, 0x96, 0x3A, 0x29, 0x8E, 0x42, 0xF9, 0x8D, 0x94, 0x17, 0x32, 0xDF,
                0x36, 0x1B, 0xCB, 0x7F, 0x1A, 0x33, 0x84, 0x2A, 0x44, 0xF7, 0x0D, 0x7D, 0xE4, 0x35, 0xEC, 0x68,
                0x4E, 0xF6, 0xF0, 0x66, 0x3B, 0x70, 0xE0, 0xA9, 0xD4, 0x76, 0x18, 0xD5, 0x09, 0x2F, 0xD2, 0xC1,
                0xDE, 0xC2, 0x85, 0xB1, 0xF2, 0xEE, 0x54, 0xFE, 0xAE, 0xD8, 0x78, 0x55, 0xBA, 0x23, 0x65, 0xEF,
                0x75, 0xAA, 0x00, 0x00
            };

            byte[] resultPacket = new byte[packet.Length];
            Array.Copy(packet, resultPacket, packet.Length);

            byte[] result; // eax
            byte pointerKey; // esi
            byte v6; // edi
            byte v7; // edx
            byte v8; // ecx

            result = key;
            pointerKey = key[0];
            v6 = key[1];
            if (resultPacket.Length > 0)
            {
                for (int i = 0; i < resultPacket.Length; i++)
                {
                    pointerKey = (byte) (pointerKey + 1);
                    v7 = key[pointerKey + 2];
                    v6 = (byte) (v7 + v6);
                    v8 = key[v6 + 2];
                    key[pointerKey + 2] = v8;
                    resultPacket[i] ^= key[(byte) (v7 + v8) + 2];
                    key[v6 + 2] = v7;
                }
            }

            key[1] = v6;
            //key = pointerKey;

            return resultPacket;
        }

        public string GetOpcode(byte[] dataPackage)
        {
            byte[] destinationArray = new byte[2];
            Array.Copy(dataPackage, 4, destinationArray, 0, destinationArray.Length);

            short number = BitConverter.ToInt16(destinationArray, 0);

            return number.ToString();
        }
    }
}