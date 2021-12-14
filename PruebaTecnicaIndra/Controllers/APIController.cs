using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaIndra.Model;

/*
 * Author : Diego Alexander Cárdenas Diaz
 * Fecha :  14-dic-2021
 */

namespace PruebaTecnicaIndra.Controllers
{
    [Route("api/")]
    [ApiController]
    public class APIController : ControllerBase
    {
        /* 
         * Implementación de la funcion Combinations tomada de: https://geus.wordpress.com/2010/10/26/algoritmo-de-combinaciones-con-clinq/ 
         * Creditos al autor original
        */
        public static IEnumerable<IEnumerable<T>> Combinations<T>(IEnumerable<T> elements, int setLenght)
        {
            int elementLenght = elements.Count();
            if (setLenght == 1)
                return elements.Select(e => Enumerable.Repeat(e, 1));
            else if (setLenght == elementLenght)
                return Enumerable.Repeat(elements, 1);
            else
            {
                return Combinations(elements.Skip(1), setLenght - 1)
                                .Select(tail => Enumerable.Repeat(elements.First(), 1).Union(tail))
                                .Union(Combinations(elements.Skip(1), setLenght));
            }
        }

        [HttpPost]
        [Route("casasCompiten")]
        public CasasResponse casasCompiten([FromBody] CasasDto casasDto)
        {
            List<int> entrada = new List<int>(casasDto.lstCasas);
            List<int> casasList = new List<int>(casasDto.lstCasas);
            for (int i = 0; i < casasDto.dias; i++)
            {
                for (int j = 0; j < casasDto.lstCasas.Count; j++)
                {
                    if (j == 0 && casasDto.lstCasas[j + 1] == 0) // primera casa del arreglo cambia a inactivo
                    {
                        casasList[j] = 0;
                    }
                    else if (j == 0 && casasDto.lstCasas[j + 1] == 1) // primera casa del arreglo cambia a activo
                    {
                        casasList[j] = 1;
                    }
                    else if (j < casasDto.lstCasas.Count - 1 && casasDto.lstCasas[j - 1] == casasDto.lstCasas[j + 1]) // casas en medio del arreglo cambian a inactivo
                    {
                        casasList[j] = 0;
                    }
                    else if (j < casasDto.lstCasas.Count - 1 && casasDto.lstCasas[j - 1] != casasDto.lstCasas[j + 1]) // casas en medio del arreglo cambian a activo
                    {
                        casasList[j] = 1;
                    }
                    else if (j == casasDto.lstCasas.Count - 1 && casasDto.lstCasas[j - 1] == 0) // ultima casa del arreglo cambia a inactivo
                    {
                        casasList[j] = 0;
                    }
                    else if (j == casasDto.lstCasas.Count - 1 && casasDto.lstCasas[j - 1] == 1) // ultima casa del arreglo cambia a activo
                    {
                        casasList[j] = 1;
                    }
                }
                casasDto.lstCasas = new List<int>(casasList);
                casasDto.diasTranscurridos++;
            }
            return new CasasResponse(casasDto.diasTranscurridos, entrada, casasDto.lstCasas);
        }

        [HttpPost]
        [Route("PaquetesMensajeria")]
        public List<int> PaquetesMensajeria([FromBody] PaquetesDto paquetesDto)
        {
            var pares = new List<IEnumerable<int>>();
            int tamañoAOcupar = paquetesDto.tamanioCamion - 30;
            List<int> paquetesLista = new List<int>(paquetesDto.lstPaquetes);
            var combinatorias = Combinations<int>(paquetesLista, 2);
            foreach (var pareja in combinatorias)
            {
                if (pareja.ElementAt(0) + pareja.ElementAt(1) == tamañoAOcupar)
                {
                    pareja.OrderByDescending(i => i);
                    if (pares.Count - 1 >= 0 && pareja.ElementAt(0) > pares[pares.Count - 1].ElementAt(0))
                    {
                        pares.Insert(0, pareja);
                    }
                    else
                    {
                        pares.Insert(0, pareja);
                    }
                }
            }
            return pares[0].ToList();
        }
    }
}
