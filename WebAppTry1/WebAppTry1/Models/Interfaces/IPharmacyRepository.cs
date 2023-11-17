namespace WebAppTry1.Models.Interfaces
{
    public interface IPharmacyRepository
    {
        Pharmacy GetPharmacy(int id);
        IEnumerable<Pharmacy> GetAllPharmacy();
        Pharmacy AddPharmacy(Pharmacy pharmacy);
        Pharmacy UpdatePharmacy(Pharmacy pharmacy);
        Pharmacy DeletePharmacy(int id);
    }
}
