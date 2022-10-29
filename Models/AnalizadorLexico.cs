using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAutomatas.Models
{
    public class AnalizadorLexico
    {

        public static List<Token> principal(string texto)
        {
            List<Token> lista = new();
            string TextoCompleto = texto;
            TextoCompleto = TextoCompleto.Replace(" ", "");
            char[] salto = { '\n' };

            string[] TextoEnLineas = TextoCompleto.Split(salto);

            for (int i = 0; i < TextoEnLineas.Length; i++)
            {
                int contador = 0;
                int contador2 = 1;
                for (int j = 0; j < TextoEnLineas[i].Length; j++)
                {
                    string porcion;
                    if (contador - j + 1 == 1) porcion = TextoEnLineas[i][j].ToString();
                    else
                        if (contador + contador2 <= TextoEnLineas[i].Length) porcion = TextoEnLineas[i].Substring(contador, contador2);
                        else return lista;
                    
                    string dato = Analizar(porcion);
                    if(dato != "")
                    {
                        if((dato == "Numero" || dato == "Numero Decimal") && j+1 < TextoEnLineas[i].Length)
                        {
                            string dato2 = Analizar(TextoEnLineas[i][j+1].ToString());
                            if (dato2 != "Numero" && dato2 != "Punto" && dato2 !="Numero Decimal")
                            {
                                contador = j+1;
                                Token t = new();
                                t.Contenido = porcion;
                                t.Tipo = dato;
                                lista.Add(t); contador2 = 1;
                            }
                            contador2++;
                        }
                        else
                        {
                            contador = j+1;
                            Token t = new();
                            t.Contenido = porcion;
                            t.Tipo = dato;
                            lista.Add(t); contador2 = 1;
                        } 
                    }
                    else
                    {
                        contador2++;
                    }
                }
            }
            

            return lista;
        }

        public static string Analizar(string analizado)
        {
            string dato = "";
            switch (analizado)
            {
                case "(" :
                    dato = "Parentesis Izquierdo";
                    break;
                case "{":
                    dato = "Corchete Izquierdo";
                    break;
                case "}":
                    dato = "Corchete Derecho";
                    break;
                case ")" :
                    dato = "Parentesis Derecho";
                    break;
                case "\\frac":
                    dato = "Fraccion";
                    break;
                case "\\Begin":
                    dato = "Inicio";
                    break;
                case "\\End":
                    dato = "Final";
                    break;
                case "*":
                    dato = "Multiplicacion";
                    break;
                case "+":
                    dato = "Suma";
                    break;
                case "-":
                    dato = "Resta";
                    break;
                case "=":
                    dato = "Igual";
                    break;
                case ".":
                    dato = "Punto";
                    break;
                case "\\sqrt":
                    dato = "RaizCuadrada";
                    break;
                case "^":
                    dato = "Potencia";
                    break;
                case "\\sin":
                    dato = "Seno";
                    break;
                case "\\cos":
                    dato = "Coseno";
                    break;
                case "\\pi":
                    dato = "Pi";
                    break;
                default:
                    int valor;
                    decimal valordecimal;
                    if (int.TryParse(analizado, out valor))
                        dato = "Numero";
                    else if (decimal.TryParse(analizado, System.Globalization.NumberStyles.AllowDecimalPoint, new CultureInfo("es-GT"), out valordecimal))
                        dato = "Numero Decimal";
                    else
                    {
                        if(analizado.StartsWith("\\"))
                        {
                            break;
                        }
                        else 
                        {
                            char c;
                            Char.TryParse(analizado, out c);
                            if (Char.IsLetter(c))
                            {
                                dato = "Variable";
                            }
                        }
                    }
                    break;
            }

            return dato;
        }
    }
}
