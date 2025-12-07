## This file is created by Ceasar128 Author of Multron File Guardian software to verify wikipedia page requeest of Cryptexpertsar wikipedia user.
``\\ Yes these are true. programm codebase is under c# .net framework 4.7.2``  
Multron File Guardian is an open source file encryption software for Windows. It supports many configurations. Programmed in C#, .NET Framework 4.7.2 by Ceasar128.

---
``\\ I created this program to provide flexible as much as possible and secure, true. First release date also true too as you can see in readme.md = https://github.com/Ceasar128/MultronFguardian/blob/mfgr1595p/README.md``  
Main purpose of it is provide flexible encryption securely

First release date is September 24, 2024.

---
``\\ Default settings are made by this way below, so it's true`` 
Default Settings
AES-256 CBC (Encrypt-then-MAC)

Argon2id parameters: 4 Iteration, 256 MB Memory, 2 Parallelizm.

---
``\\ Block cipher runs in CBC mode as their padding way is PKCS7 as you can see it inside source code (example: aesprocesses function in form1.cs = https://github.com/Ceasar128/MultronFguardian/blob/mfgr1595p/multronfileguardian1595r/Form1.cs``  
Block Cipher Parameters
CBC-PKCS7

---
``\\Yes these are true too, example source code (aesprocesses) = https://github.com/Ceasar128/MultronFguardian/blob/mfgr1595p/multronfileguardian1595r/Form1.cs | i must mention Encrypt-then-MAC is default mode. But i see Cryptexpertsar mentioned that in other way.``  
Cipher Mode
Application provides two choice as Cipher Mode:

No-AUTH (No authentication mode)
Encrypt-then-MAC
Implementation of Encrypt-then-MAC:

HMAC-SHA512 is used in Encrypt-then-MAC

Creating two key from provided master key by doubling size of symmetric key length. Derived key splitted to two key.

First half of key is for encryption/decryption operation

Other half is used for HMAC-SHA512

Symmetric algorithm settings added to derived key's salt (Example: Random salt + Serpent-192) to make auth more secure.

---
``\\ Yes these true too, Some example referencne is at form1.cs and form3.cs (argmemrate integer value as memory rate setting, raes.argonkdf() function) = https://github.com/Ceasar128/MultronFguardian/blob/mfgr1595p/multronfileguardian1595r/Form1.cs``  
Key Derivation
Application uses argon2id which is a version of Argon2.

Default parameters: 4 Iteration, 256 MB of Memory, 2 Parallelizm.

Users can choose parameters of argon2id: 256, 512, 1024 MB of Memory Choices.

Iteration can be set from text box in settings section by user. No limitation applies. Recommended Iteration rate is 4 to 12.

Parallelizm Parameter is fixed, Cant be set by user.

---

``\\ True, Example references is (raes.generaterandomkey() function in aesprocesses function and its using way) = https://github.com/Ceasar128/MultronFguardian/blob/mfgr1595p/multronfileguardian1595r/Form1.cs)``  
IV/Salt Handling
Random IV/Salt for each file by RandomNumberGenerator class in .NET Framework 4.7.2

---

``\\ This feature is true (I must mention that user must not rely on this feature, Windows's drm flag can be bypassed by some advanced viruses, Always check your system for viruses, and only works in windows 10/11) as you can see (example reference at form1: SetWindowDisplayAffinity() function is windows API function (ref: https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowdisplayaffinity) which controls how window will be displayed. 0x00000011 is WDA_EXCLUDEFROMCAPTURE drm flag as you can see it in microsoft document.) = https://github.com/Ceasar128/MultronFguardian/blob/mfgr1595p/multronfileguardian1595r/Form1.cs``  
Screen Protection
This property prevents Application from catched in captures. It uses WDA_EXCLUDEFROMCAPTURE Windows DRM Flag. Using this may prevent unwanted data leaks. Also Prevents Windows Recall from capturing application.

---

``\\ These are true as you can see in form1.cs at event of comboBox1_SelectedValueChanged = https://github.com/Ceasar128/MultronFguardian/blob/mfgr1595p/multronfileguardian1595r/Form1.cs``  
Supported Symmetric Algorithms
AES
Serpent
Twofish
ThreeFish
Camellia
ChaCha20
SM4
HC
Algorithm Key Lengths changes upon Algorithm, Application supports key lengths as much as algorithm allow

---

``\\ True, RSA runs in OAEP Mode as you can see at raes.cs in functions rsaencrypt/rsadecrypt = https://github.com/Ceasar128/MultronFguardian/blob/mfgr1595p/multronfileguardian1595r/raes.cs``  
Supported Asymmetric Algorithms
RSA (OAEP)
Algorithm Key Lengths changes upon Algorithm, Application supports key lengths as much as algorithm allow

---

``\\ True, as  you can see in applied approach at aesrsaprocesses in form1.cs = https://github.com/Ceasar128/MultronFguardian/blob/mfgr1595p/multronfileguardian1595r/Form1.cs``  
Hybrid Mode Logic
Application uses Hybrid Mode to provide asymmetric encryption.

It creates a random symmetric key, Encrypt/Decrypt file with created key, (Correcting: On encryption mode: Encrypt created key with provided Public key. Writing it to file.)

Logic is based on Key encapsulation method (Correcting: mechanism)  (wikipedia ref: https://en.wikipedia.org/wiki/Key_encapsulation_mechanism#:~:text=In%20cryptography%2C%20a%20key%20encapsulation,of%20eavesdropping%20and%20intercepting%20adversaries.)
