using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class AES_Encryption
{
    private static readonly string Key = "XCTjxapuQjWnHEtKs3RMvedw2Fv6Gaee"; // 32 characters for AES-256
    private static readonly string IV = "vUkx8JjjyGrT8jmg"; // 16 characters for AES block size
    public static string Encrypt(string plainText)
    {
        //將秘鑰轉為byte後面使用
        byte[] keyBytes = Encoding.UTF8.GetBytes(Key); 
        byte[] ivBytes = Encoding.UTF8.GetBytes(IV);
        using (Aes aes = Aes.Create())
        {
            aes.Key = keyBytes;
            aes.IV = ivBytes;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV); // 建立加密器

            using (MemoryStream ms = new MemoryStream())// 建立記憶體流來存放加密後的資料
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))// 建立加密流，將加密器與記憶體流連接
                {
                    using (StreamWriter sw = new StreamWriter(cs))// 建立 StreamWriter 來寫入JSON字串到加密流中
                    {
                        sw.Write(plainText);
                    }
                }
                // 將加密後的位元組陣列轉成 Base64 字串，方便存成文字檔
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }
    public static string Decrypt(string cipherText)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(Key);
        byte[] ivBytes = Encoding.UTF8.GetBytes(IV);
        byte[] cipherBytes = Convert.FromBase64String(cipherText);

        using (Aes aes = Aes.Create())
        {
            aes.Key = keyBytes;
            aes.IV = ivBytes;

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream(cipherBytes))
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
    }

}
