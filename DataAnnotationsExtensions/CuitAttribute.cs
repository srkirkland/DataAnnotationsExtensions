using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions.Resources;

namespace DataAnnotationsExtensions
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CuitAttribute : DataTypeAttribute
    {
        public CuitAttribute()
            : base("cuit")
        {
        }

        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                ErrorMessage = ValidatorResources.CuitAttribute_Invalid;
            }

            return base.FormatErrorMessage(name);
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            try
            {
                string cuit = (string)value;
                List<int> prefijosValidos = new List<int>(new[] { 20, 22, 23, 27, 30 });

                int preFijo = 0;
                int dni = 0;
                int control = 0;
                if (cuit.Length == 11 || cuit.Length == 13)
                {
                    if (cuit.Contains("-"))
                    {
                        string[] aCuit = cuit.Split('-');
                        preFijo = int.Parse(aCuit[0]);
                        dni = int.Parse(aCuit[1]);
                        control = int.Parse(aCuit[2]);
                    }
                    else
                    {
                        preFijo = int.Parse(cuit.Substring(0, 2));
                        dni = int.Parse(cuit.Substring(2, 8));
                        control = int.Parse(cuit.Substring(10, 1));
                    }
                }

                string prefijoDni = preFijo + dni.ToString().PadLeft(8, '0');
                int suma = 0;
                int n;

                if (!prefijosValidos.Contains(preFijo))
                    return false;

                //Algoritmo de calculo del digito verificador
                const string coef = "5432765432";
                for (n = 0; n < 10; n++)
                    suma += int.Parse(prefijoDni.Substring(n, 1)) * int.Parse(coef.Substring(n, 1));

                int resto = suma % 11;
                int digitoVerificador;

                if (resto == 0)
                    digitoVerificador = 0;

                else if (resto == 10)
                    digitoVerificador = 1;

                else
                    digitoVerificador = 11 - resto;

                return (digitoVerificador == control);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
