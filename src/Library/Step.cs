//-------------------------------------------------------------------------------
// <copyright file="Step.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------------

namespace Full_GRASP_And_SOLID.Library
{
    // Responsabilidades: Conocer el producto, conocer el equipamiento, conocer el tiempo, conocer la cantidad
    // Colaboraciones: Con la clase Product (para conocer el producto) y con la clase Equipment (para conocer el equipamiento)
    public class Step
    {
        public Step(Product input, double quantity, Equipment equipment, int time)
        {
            this.Quantity = quantity;
            this.Input = input;
            this.Time = time;
            this.Equipment = equipment;
        }

        public Product Input { get; set; }

        public double Quantity { get; set; }

        public int Time { get; set; }

        public Equipment Equipment { get; set; }

        // Creo un método que me permita obtener el costo asociado al paso
        public double GetStepCost()
        {
            // Costo del producto en cada paso = Cantidad * Costo Unitario
            // Costo del equipamiento en cada paso = Costo por hora * Tiempo en horas
            return this.Quantity * this.Input.UnitCost + this.Equipment.HourlyCost * (this.Time / 60);
        }
    }
}