namespace Inlamningsuppgift_2_OOP
{
    class Fordon
    {
        public string Registreringsnummer { get; }
        public string Märke { get; }
        public string Modell { get; }
        public double Hyrespris { get; }

        public Fordon(string registreringsnummer, string märke, string modell, double hyrespris)
        {
            Registreringsnummer = registreringsnummer;
            Märke = märke;
            Modell = modell;
            Hyrespris = hyrespris;
        }

        public double BeräknaPris(int dagar)
        {
            return dagar * Hyrespris;
        }

        public override string ToString()
        {
            return $"{Märke} {Modell} (Reg.nr: {Registreringsnummer})";
        }
    }

    class Kund
    {
        public string Namn { get; }
        public string KontaktInfo { get; }

        public Kund(string namn, string kontaktInfo)
        {
            Namn = namn;
            KontaktInfo = kontaktInfo;
        }

        public Reservation BokaFordon(Fordon fordon, DateTime start, DateTime slut)
        {
            return new Reservation(this, fordon, start, slut);
        }

        public override string ToString()
        {
            return Namn;
        }
    }

    class Reservation
    {
        private Fordon Fordon { get; }
        private Kund Kund { get; }
        private DateTime StartDatum { get; }
        private DateTime SlutDatum { get; }
        private double TotaltPris { get; }

        public Reservation(Kund kund, Fordon fordon, DateTime startDatum, DateTime slutDatum)
        {
            Kund = kund;
            Fordon = fordon;
            StartDatum = startDatum;
            SlutDatum = slutDatum;
            TotaltPris = BeräknaTotaltPris();
        }

        public double BeräknaTotaltPris()
        {
            int hyresDagar = (SlutDatum - StartDatum).Days;
            return Fordon.BeräknaPris(hyresDagar);
        }

        public void VisaDetaljer()
        {
            Console.WriteLine($"Reservation för kund: {Kund}");
            Console.WriteLine($"Fordon: {Fordon}");
            Console.WriteLine($"Hyresperiod: {StartDatum} till {SlutDatum}");
            Console.WriteLine($"Totalt pris: {TotaltPris} SEK");
        }
    }

    class Biluthyrning
    {
        private List<Kund> Kunder { get; }
        private List<Fordon> Fordon { get; }
        private List<Reservation> Reservationer { get; }

        public Biluthyrning()
        {
            Kunder = new List<Kund>();
            Fordon = new List<Fordon>();
            Reservationer = new List<Reservation>();
        }

        public void LäggTillFordon(Fordon f)
        {
            Fordon.Add(f);
        }

        public void LäggTillKund(Kund k)
        {
            Kunder.Add(k);
        }

        public void LäggTillReservation(Reservation r)
        {
            Reservationer.Add(r);
        }

        public void VisaAllaReservationer()
        {
            foreach (var r in Reservationer)
            {
                r.VisaDetaljer();
                Console.WriteLine("-------------------");
            }
        }
    }
}
