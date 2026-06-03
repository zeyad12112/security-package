# 🔐 Security Package — Cryptography Library (C#)

A comprehensive **cryptography library** implementing classical and modern encryption algorithms in C#. Includes full test suites for each algorithm.

---

## 🔑 Algorithms Implemented

### Classical Ciphers
| Algorithm | Type |
|-----------|------|
| Caesar Cipher | Substitution |
| Monoalphabetic | Substitution |
| Playfair | Polygraphic substitution |
| Vigenère | Polyalphabetic substitution |
| Hill Cipher | Matrix-based substitution |
| Rail Fence | Transposition |
| Columnar Transposition | Transposition |

### Modern Cryptography
| Algorithm | Type |
|-----------|------|
| DES / 3DES | Symmetric block cipher |
| AES | Symmetric block cipher |
| RSA | Asymmetric (public-key) encryption |
| RC4 | Stream cipher |
| ElGamal | Asymmetric encryption |
| Diffie-Hellman | Key exchange protocol |
| Extended Euclidean | Mathematical utility |
| MD5 | Hashing |

---

## 📁 Project Structure

```
SecurityPackage/
├── SecurityPackage.sln         # Visual Studio solution
├── securitylibrary/            # Core algorithm implementations
├── securitypackagetest/        # Unit tests for all algorithms
└── All security package testcases/
    ├── RSATest.cs
    ├── AESTest.cs
    ├── DES3DesTest.cs
    ├── ElGamalTest.cs
    ├── DeffieHelmanTest.cs
    ├── MD5Test.cs
    ├── HillCipherTest.cs
    ├── PlayfairTest.cs
    └── ... (16 test files total)
```

---

## 🚀 How to Run

### Prerequisites
- Visual Studio 2013+ (or any C# IDE)
- .NET Framework

### Steps
1. Open `SecurityPackage.sln` in Visual Studio
2. Build the solution (`Ctrl+Shift+B`)
3. Run tests via Test Explorer or:
```bash
dotnet test
```

---

## 💡 Example Usage

```csharp
// RSA Encryption
var rsa = new RSA();
string encrypted = rsa.Encrypt("Hello World", publicKey);
string decrypted = rsa.Decrypt(encrypted, privateKey);

// AES Encryption
var aes = new AES();
string cipher = aes.Encrypt("plaintext", "secretkey");
```

---

## 🛠️ Tech Stack

![CSharp](https://img.shields.io/badge/C%23-239120?style=flat&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=flat&logo=dotnet&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual_Studio-5C2D91?style=flat&logo=visualstudio&logoColor=white)

---

## 👤 Author

**Zeyad Aymen** — [github.com/zeyad12112](https://github.com/zeyad12112)
