﻿using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int MedicationId { get; set; }

    public int SupplierId { get; set; }

    public int StorageId { get; set; }

    public DateTime Date { get; set; }

    public double Amount { get; set; }

    public virtual Medication Medication { get; set; } = null!;

    public virtual Storage Storage { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
