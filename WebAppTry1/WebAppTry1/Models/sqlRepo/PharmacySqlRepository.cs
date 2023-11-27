using WebAppTry1.Models.Interfaces;

namespace WebAppTry1.Models.sqlRepo
{
    public class PharmacySqlRepository : IPharmacyRepository
    {
        private readonly ApplicationDbContext context;

        public PharmacySqlRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Pharmacy AddPharmacy(Pharmacy pharmacy)
        {
            context.Pharmacies.Add(pharmacy);
            context.SaveChanges();
            return pharmacy;
        }

        public Pharmacy DeletePharmacy(int id)
        {
           var pharmacy = context.Pharmacies.FirstOrDefault(ph => ph.Id == id);
            if (pharmacy != null)
            {
                context.Pharmacies.Remove(pharmacy);
                context.SaveChanges();
            }
            return pharmacy;
        }

        public IEnumerable<Pharmacy> GetAllPharmacy()
        {
            return context.Pharmacies;
        }

        public Pharmacy GetPharmacy(int id)
        {
            return context.Pharmacies.Find(id);
        }

        public Pharmacy UpdatePharmacy(Pharmacy pharmacy)
        {
            var modifiedPharmacy = context.Pharmacies.Attach(pharmacy);
            modifiedPharmacy.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return pharmacy;

        }
    }
}
