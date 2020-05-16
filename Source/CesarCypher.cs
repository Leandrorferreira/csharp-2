using System;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        #region ICript, IDecrypt Implementations

        public string Crypt(string message)
        {
            ValidateIsNull(message);
            var cryptedMessage = string.Empty;

            foreach (var character in message.ToLower())
            {
                var cryptedChar = character;
                if (!IsNumberOrWhiteSpace(character))
                {
                    var asciiCode = (int)character;
                    ValidateIsSpecialChar(asciiCode);
                    cryptedChar = (char)(asciiCode + (GetKeyToCrypt(asciiCode) * 1));
                }

                cryptedMessage += cryptedChar;
            }

            return cryptedMessage;
        }

        public string Decrypt(string cryptedMessage)
        {
            ValidateIsNull(cryptedMessage);
            var message = string.Empty;

            foreach (var character in cryptedMessage.ToLower())
            {
                var decryptedChar = character;
                if (!IsNumberOrWhiteSpace(character))
                {
                    var asciiCode = (int)character;
                    ValidateIsSpecialChar(asciiCode);
                    decryptedChar = (char)(asciiCode + (GetKeyToDecrypt(asciiCode) * 1));
                }

                message += decryptedChar;
            }

            return message;
        }

        #endregion

        #region Validations

        private void ValidateIsNull(string message)
        {
            if (message is null)
            {
                throw new ArgumentNullException();
            }
        }

        private void ValidateIsSpecialChar(int asciiCode)
        {
            if (asciiCode < 97 || asciiCode > 122)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private bool IsNumberOrWhiteSpace(char character)
        {
            var asciiCode = (int) character;
            return char.IsWhiteSpace(character) || (asciiCode >= 48 && asciiCode <= 57);
        }

        #endregion

        #region Get Methods
        private int GetKeyToCrypt(int asciiCode)
        {
            return asciiCode + 3 > 122 ? -23 : 3;
        }

        private int GetKeyToDecrypt(int asciiCode)
        {
            return asciiCode - 3 < 97 ? +23 : -3;
        }

        #endregion
    }
}
