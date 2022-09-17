using System;
using System.Text.RegularExpressions;
using Domain.Enums;

namespace Domain.ValueObjects
{
    public class Document
    {
        private const string CpfRegex = @"^\d{3}\.\d{3}\.\d{3}\-\d{2}$";
        private const string CnpjRegex = @"(^\d{3}\.\d{3}\.\d{3}\-\d{2}$)|(^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$)";

        public DocumentType Type { get; }
        public string Number { get; }

        public Document(string documentNumber)
        {
            Number = documentNumber;
            Type = CheckDocumentType();
        }

        private DocumentType CheckDocumentType()
        {
            if (IsValid(CpfRegex))
                return DocumentType.CPF;
            
            if(IsValid(CnpjRegex))
                return DocumentType.CNPJ;

            throw new Exception();
        }
        
        private bool IsValid(string pattern) => Regex.IsMatch(Number, pattern, RegexOptions.IgnoreCase);
    }
}