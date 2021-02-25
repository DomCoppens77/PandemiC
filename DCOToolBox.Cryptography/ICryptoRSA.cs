using System;
using System.Collections.Generic;
using System.Text;

namespace DCOToolBox.Cryptography
{
    public interface ICryptoRSA
    {
        byte[] BinaryBothKeys { get; }
        byte[] BinaryPublicKey { get; }
        string XmlBothKeys { get; }
        string XmlPublicKey { get; }
        byte[] Crypter(string ACrypter);
        string Decrypter(byte[] ADecrypter);
        void ImportBinaryKeys(byte[] keys);
        void ImportXmlKeys(string xml);
    }
}
