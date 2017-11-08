﻿using System.Text;

namespace RocamERP.Presentation.Web.Extensions
{
    public static class FormattingHelpers
    {
        public static string FormatCEP(this string cep)
        {
            if (cep == null)
                return null;

            return cep.Insert(2, ".").Insert(6, "-");
        }

        public static string FormatCurrency(this string value)
        {
            if (value == null)
                return null;

            return $"R${value}";
        }

        public static string FormatCadastroNacional(this string value)
        {
            if (value == null)
                return null;

            int cpfLenght = 11;
            int cnpjLenght = 14;
            StringBuilder sb = new StringBuilder();

            if (value.Length == cpfLenght)
            {
                sb.Append(value.Substring(0, 3));
                sb.Append(".");
                sb.Append(value.Substring(3, 3));
                sb.Append(".");
                sb.Append(value.Substring(6, 3));
                sb.Append("-");
                sb.Append(value.Substring(9, 2));
            }
            else if(value.Length == cnpjLenght)
            {
                sb.Append(value.Substring(0, 2));
                sb.Append(".");
                sb.Append(value.Substring(2, 3));
                sb.Append(".");
                sb.Append(value.Substring(5, 3));
                sb.Append("/");
                sb.Append(value.Substring(8, 4));
                sb.Append("-");
                sb.Append(value.Substring(12, 2));
            }
            else
            {
                return value;
            }

            return sb.ToString();
        }

        public static string FormatCadastroEstadual(this string value)
        {
            if (value == null)
                return null;

            int rgLenght = 10;
            int inscricaoEstadualLenght = 12;
            StringBuilder sb = new StringBuilder();

            if(value.Length == rgLenght)
            {
                sb.Append(value.ToUpper().Substring(0, 2));
                sb.Append("-");
                sb.Append(value.Substring(2, 3));
                sb.Append(".");
                sb.Append(value.Substring(5, 5));
            }
            else if(value.Length == inscricaoEstadualLenght)
            {
                sb.Append(value.Substring(0, 3));
                sb.Append(".");
                sb.Append(value.Substring(3, 3));
                sb.Append(".");
                sb.Append(value.Substring(6, 3));
                sb.Append(".");
                sb.Append(value.Substring(9, 3));
            }
            else
            {
                return value;
            }

            return sb.ToString();
        }
    }
}