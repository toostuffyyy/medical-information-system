using System;

namespace MISPharmacy.Models;

public class Order
{
    public int Id { get; set; }

    public int MedicationId { get; set; }

    public int SupplierId { get; set; }

    public int StorageId { get; set; }

    public DateTime Date { get; set; }

    public double Amount { get; set; }
}