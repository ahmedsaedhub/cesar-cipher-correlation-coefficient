using System;
using System.Collections.Generic;
using System.Linq;
using caesar_cipher_igsr.helpers;

namespace caesar_cipher_igsr.lib {
    public class CaesarCypherEncyption {

        /// <summary>
        /// Encrypt Text
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string EncryptText (string plainText, int key) {
            string encryptedText = "";
            for (int i = 0; i < plainText.Length; i++) {
                char ciphered = this.CipherLetterShifter(plainText[i], key);
                encryptedText += ciphered;
            }
            return encryptedText;
        }

         /// <summary>
        /// Decrypt text based on known key
        /// </summary>
        /// <param name="encryptedText">encrypted text</param>
        /// <param name="key">singed key</param>
        /// <returns>orignial text</returns>
        public string DecryptText (string encryptedText, int key) {
            string originalText = "";
            foreach (char character in encryptedText) {
                // reserving shiting to original character by substitue from original langauge character count
                char resolvedChar = this.CipherLetterShifter(character, StaticData.EnglishLanguageFrequencies.Count - key);
                originalText += resolvedChar;
            }
            return originalText;
        }

        /// <summary>
        /// Detect Cypher Key based on Correlation Coefficient
        /// </summary>
        /// <param name="encryptedText">encryptedText</param>
        /// <returns>expected key</returns>
        public int DetectCypherKey(string encryptedText) {
            var characterCounts = new List<CharacterWithValue<int>>();
            var characterFrequencies = new List<CharacterWithValue<double>>();
            foreach (var item in StaticData.EnglishLanguageFrequencies) {
                // calculate character existing count
                int count = encryptedText.Select (i => i).Count (i => i == item.Character);
                characterCounts.Add (new CharacterWithValue<int>() {
                    Character = item.Character,
                    Value = count
                });
                // calculate frequency of each character on the phrase (percentage)
                float frequency = (float) count / (float) encryptedText.Length;
                characterFrequencies.Add (new CharacterWithValue<double>() {
                    Character = item.Character,
                    Value = frequency
                });
            }

            double bestCorrelation = -1;
            int bestShiftIndexKey = -1;
            int shiftIndexKey = 0;
            // get basic language characters frequencies
            double[] basicLangauageFrequencies = StaticData.EnglishLanguageFrequencies.Select(i=> i.Value).ToArray ();
            // try all possibillities for shiting index 
            while (shiftIndexKey < basicLangauageFrequencies.Count() - 1) {
                // shift frequencies
                double[] shiftedFrequencies = ArrayManupilation.ShiftByIndex<double>(characterFrequencies.Select(i=> i.Value).ToArray(), shiftIndexKey);
                // calculate new correlation
                double correlation = CorrelationCoefficient.Calculate (basicLangauageFrequencies, shiftedFrequencies, basicLangauageFrequencies.Count());
                // find best correlation exist (best correlation is the expected key)
                if(correlation > bestCorrelation) {
                    bestCorrelation = correlation;
                    bestShiftIndexKey = shiftIndexKey;
                }
                shiftIndexKey++;
            }
            return basicLangauageFrequencies.Count() - bestShiftIndexKey;
        }

        private char CipherLetterShifter (char character, int shiftIndexKey) {
            if (char.IsLetter (character)) {
                // detrmine range of shift based on character case (upper or lower case starting from A)
                 char characterStartingRange = char.IsUpper (character) ? 'A' : 'a';
                return (char) ((((character + shiftIndexKey) - characterStartingRange) % 26) + characterStartingRange);
            }
            return character;
        }
       
    }
}