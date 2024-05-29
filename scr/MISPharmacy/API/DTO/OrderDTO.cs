using System;
using System.Collections.Generic;

namespace API.DTO;

public partial class OrderDTO
{
    public int Id { get; set; }

    public int MedicationId { get; set; }

    public int SupplierId { get; set; }

    public int StorageId { get; set; }

    public DateTime Date { get; set; }

    public double Amount { get; set; }
}
