using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenNetDeveloper
{
    public class MoneyParts
    {
        private double[][] matrizFinal;
        private double[] vectorMonedas;

        public double[][] build(double entrada)
        {
            vectorMonedas = new double[12] { 0.05, 0.1, 0.2, 0.5, 1, 2, 5, 10, 20, 50, 100, 200 };
            matrizFinal = calcularCombinacion(entrada, vectorMonedas);
            return matrizFinal;
        }

        private double[][] calcularCombinacion(double cantidad, double[] monedas)
        {
            int valorMax = 0;
            //
            for (int i = 0; i < monedas.Count(); i++)
            {
                if (monedas[i] > cantidad)
                {
                    valorMax = i - 1;
                    break;
                }
            }
            //
            double[][] matrizFinal = new double[valorMax + 1][];
            //
            for (int i = 0; i <= valorMax; i++)
            {
                string sTexto = string.Empty;
                double valor = monedas[i];
                double suma = 0;
                double division = cantidad / valor;
                string[] numero = division.ToString().Split('.');
                int entero = int.Parse(numero[0]);
                double decim = 0;

                if (numero.Count() > 1)
                    decim = double.Parse(numero[1]);

                for (int l = 0; l < entero; l++)
                {
                    sTexto += valor + "/";
                    suma += valor;
                }

                if (cantidad > suma)
                {
                    for (int h = 0; h < monedas.Count(); h++)
                    {
                        if (cantidad == suma + monedas[h])
                        {
                            sTexto += monedas[h] + "/";
                            suma += monedas[h];
                            break;
                        }
                    }
                }

                string[] temp = sTexto.Split('/');
                double[] arrayTemp = new double[temp.Count() - 1];
                //
                for (int a = 0; a < temp.Count() - 1; a++)
                {
                    arrayTemp[a] = double.Parse(temp[a]);
                }
                //
                matrizFinal[i] = arrayTemp;
            }
            //
            return matrizFinal;
        }
    }

}
