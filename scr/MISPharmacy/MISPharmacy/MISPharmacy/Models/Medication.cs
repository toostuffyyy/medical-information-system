using System.Collections.Generic;
using System.Linq;

namespace MISPharmacy.Models;

public class Medication
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Dosage { get; set; }

    public string Description { get; set; } = null!;

    public double SumAmount => Parties.Sum(a => a.Amount);

    public string Color => SumAmount < 100 ? "IndianRed" : "White";

    public virtual List<Party> Parties { get; set; } = new List<Party>();
}