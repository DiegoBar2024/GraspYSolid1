//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    // Responsabilidades: Conocer todos los pasos de una receta, conocer el producto final, imprimir la receta, calcular costo total
    // Colaboraciones: Step (para conocer los pasos de la receta)
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            
            // Imprimo también el costo total de la receta
            Console.WriteLine($"Costo total: ${this.GetProductionCost()}");
        }

        // Implemento un método que calcule el Costo Total de un producto final (asumo que el tiempo está en minutos)
        public double GetProductionCost()
        {
            // Declaro la variable local en donde voy a almacenar el resultado
            double totalCost = 0;

            // Itero linea por linea calculando el costo en cada paso
            foreach (Step step in this.steps)
            {
                // Actualizo el valor del costo total con el costo asociado al paso llamado al método de la clase Step
                totalCost += step.GetStepCost();
            }

            // Devuelvo el costo total calculado
            return totalCost;
        }
    }
}

/* 
Se utilizó el patrón Expert para la asignación de la responsabilidad de calcular el costo de producción total.
En éste caso se tiene que la clase Recipe es la adecuada para llevar a cabo dicha responsabilidad debido que es la experta en información.
Es la única clase que tiene conocimiento de TODOS los pasos de la receta y por lo tanto la que tiene la facultad de calcular el costo asociado a cada paso y sumarlo para obtener el total
Por otro lado, mediante el patrón Expert también se asignó la responsabilidad de conocer el total de un paso a la clase Step
De éste modo, para computar el costo total de todos los pasos, la clase Recipe ahora tiene que colaborar con la clase Step para conocer el costo de cada paso.
*/